using ACSVisualization.ViewModels;
using System.Windows;
using System;
using System.Globalization;

namespace ACSVisualization.Views
{
    public partial class ParamView : Window
    {
        private ParamData Params;

        public ParamView(ParamData _Params)
        {
            Params = _Params;

            DataContext = new ParamViewModel();
            InitializeComponent();

            PathLengthParam.Text = Params.PathLengthParam.ToString();
            PathEfficiencyParam.Text = Params.PathEfficiencyParam.ToString();

            Times.Text = Params.Times.ToString();
            PopSize.Text = Params.PopSize.ToString();
            LearningRate.Text = Params.LearningRate.ToString();
            EvaporationRate.Text = Params.EvaporationRate.ToString();
            InitialPheromone.Text = Params.InitialPheromone.ToString();

            HeuristicsParam.Text = Params.HeuristicsParam.ToString();
            Eps.Text = Params.Eps.ToString();
            HillClimbIters.Text = Params.HillClimbIters.ToString();
            ElitistWayProbability.Text = Params.ElitistWayProbability.ToString();
        }
        public void UpdateParams(object sender, RoutedEventArgs e)
        {
            Params.PathLengthParam = double.TryParse(PathLengthParam.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var pathLengthParam) ? pathLengthParam : 0;
            Params.PathEfficiencyParam = double.TryParse(PathEfficiencyParam.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var pathEfficiencyParam) ? pathEfficiencyParam : 0;

            Params.Times = double.TryParse(Times.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var times) ? (int)Math.Round(times) : 0;
            Params.PopSize = double.TryParse(PopSize.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var popSize) ? (int)Math.Round(popSize) : 0;
            Params.LearningRate = double.TryParse(LearningRate.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var learningRate) ? learningRate : 0;
            Params.EvaporationRate = double.TryParse(EvaporationRate.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var evaporationRate) ? evaporationRate : 0;
            Params.InitialPheromone = double.TryParse(InitialPheromone.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var inintialPheromone) ? inintialPheromone : 0;

            Params.HeuristicsParam = double.TryParse(HeuristicsParam.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var heuristicsParam) ? heuristicsParam : 0;
            Params.Eps = double.TryParse(Eps.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var eps) ? eps : 0;
            Params.HillClimbIters = double.TryParse(HillClimbIters.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var hillClimbIters) ? (int)Math.Round(hillClimbIters) : 0;
            Params.ElitistWayProbability = double.TryParse(ElitistWayProbability.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out var elitistWayProbability) ? elitistWayProbability : 0;

            this.Close();

        }
        public void ResetParams(object sender, RoutedEventArgs e)
        {
            Params.PathLengthParam = 10;
            Params.PathEfficiencyParam = 0;

            Params.Times = 5;
            Params.PopSize = 30;
            Params.LearningRate = 0.05;
            Params.EvaporationRate = 0.5;
            Params.InitialPheromone = 0.1;

            Params.HeuristicsParam = 1;
            Params.Eps = 0.9;
            Params.HillClimbIters = 1;
            Params.ElitistWayProbability = 0.05;

            this.Close();

        }

    }
}