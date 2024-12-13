using ACSVisualization.Common;
using ACSVisualization.Events;
using ACSVisualization.Extensions;
using ACSVisualization.Models;
using ACSVisualization.Models.Dto;
using ACSVisualization.Models.Enums;
using ACSVisualization.Services;
using ACSVisualization.Util;
using ACSVisualization.Views; //M
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace ACSVisualization.ViewModels
{
    public class ParamData
    {
        public double PathLengthParam;
        public double PathEfficiencyParam;

        public int Times;
        public int PopSize;
        public double LearningRate;
        public double EvaporationRate;
        public double InitialPheromone;

        public double HeuristicsParam;
        public double Eps;
        public int HillClimbIters;
        public double ElitistWayProbability;

        public ParamData()
        {

            this.PathLengthParam = 10;
            this.PathEfficiencyParam = 0;

            this.Times = 5;
            this.PopSize = 30;
            this.LearningRate = 0.05;
            this.EvaporationRate = 0.5;

            this.InitialPheromone = 0.1;
            this.HeuristicsParam = 1;
            this.Eps = 0.9;
            this.HillClimbIters = 1;
            this.ElitistWayProbability = 0.05;
        }
        public ParamData(ParamData _)
        {
            this.PathLengthParam = _.PathLengthParam;
            this.PathEfficiencyParam = _.PathEfficiencyParam;

            this.Times = _.Times;
            this.PopSize = _.PopSize;
            this.LearningRate = _.LearningRate;
            this.EvaporationRate = _.EvaporationRate;

            this.InitialPheromone = _.InitialPheromone;
            this.HeuristicsParam = _.HeuristicsParam;
            this.Eps = _.Eps;
            this.HillClimbIters = _.HillClimbIters;
            this.ElitistWayProbability = _.ElitistWayProbability;
        }
    }

    public class ShellViewModel : BaseViewModel
    {
        private readonly Graph _graph;
        private readonly VertexPersistenceManager _vertexPersistenceManager;
        private readonly CollectionView _views;

        private ActiveView _activeView;

        public ParamData Params;

        public ShellViewModel()
        {
            _graph = Graph.Instance;
            _vertexPersistenceManager = new VertexPersistenceManager();
            ActiveView = ActiveView.Graph;

            ViewAdjacencyMatrixCommand = new RelayCommand(
                obj => ActiveView = ActiveView.AdjacencyMatrix,
                obj => ActiveView != ActiveView.AdjacencyMatrix);

            ViewAdjacencyListCommand = new RelayCommand(
                obj => ActiveView = ActiveView.AdjacencyList,
                obj => ActiveView != ActiveView.AdjacencyList);

            ViewGraphCommand = new RelayCommand(
                obj => ActiveView = ActiveView.Graph,
                obj => ActiveView != ActiveView.Graph);

            SaveGraphCommand = new RelayCommand(
                obj => SaveToFile(),
                obj => _graph.GetVerticesCount() > 0);

            LoadGraphCommand = new RelayCommand(
                obj => LoadFromFile(),
                obj => true);

            OpenParamCommand = new RelayCommand(
                obj => OpenParam(),
                obj => true);



            //ACSParamsCommand = new RelayCommand(
            //    obj => OpenParamWindow(),
            //    obj => true);

            Params = new ParamData();
        }

        public ICommand ViewAdjacencyMatrixCommand { get; }

        public ICommand ViewAdjacencyListCommand { get; }

        public ICommand ViewGraphCommand { get; }

        public ICommand SaveGraphCommand { get; }

        public ICommand LoadGraphCommand { get; }

        public ICommand OpenParamCommand { get; }

        public ActiveView ActiveView
        {
            get => _activeView;
            set
            {
                _activeView = value;
                OnPropertyChanged();
            }
        }

        private void SaveToFile()
        {
            var exportObject = new IOGraphData
            {
                Vertices = _vertexPersistenceManager.GetPersistedVertices().ToList(),
                AdjacencyList = _graph.ToAdjacencyList()
            };

            var json = JsonConvert.SerializeObject(exportObject);
            File.WriteAllText("savedData.json", json);
        }

        private void LoadFromFile()
        {
            var json = File.ReadAllText("savedData.json");
            var importObject = JsonConvert.DeserializeObject<IOGraphData>(json);
            EventAggregator.Instance.Publish(new OnLoadGraphMessage(importObject));
        }

        private void OpenParam()
        {
            var Page = new ParamView(this.Params);
            Page.Show();
        }
        //private void OpenParamWindow()
        //{
        //    ParamViewModel paramview = new ParamViewModel();
        //    paramview.Show();
        //}
    }
}
