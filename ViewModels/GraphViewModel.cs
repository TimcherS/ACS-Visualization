using ACSVisualization.Algorithms;
using ACSVisualization.Common;
using ACSVisualization.Events;
using ACSVisualization.Models;
using ACSVisualization.Models.Enums;

namespace ACSVisualization.ViewModels
{
    public class GraphViewModel : BaseViewModel,
        IHandle<OnCreateVertexMessage>,
        IHandle<OnCreateEdgeMessage>,
        IHandle<OnDeleteVertexMessage>,
        IHandle<OnCostChanged>,
        IHandle<OnRemoveEdgeMessage>,
        IHandle<OnRunAlgorithmMessage>
    {
        private readonly Graph _graph;

        public GraphViewModel()
        {
            _graph = Graph.Instance;
        }

        public void Handle(OnCreateVertexMessage message)
        {
            var vertex = new Vertex(message.Id);
            _graph.AddVertex(vertex);
        }

        public void Handle(OnDeleteVertexMessage message)
        {
            var vertex = _graph.GetVertexById(message.Id);
            _graph.RemoveVertex(vertex);
        }

        public void Handle(OnCreateEdgeMessage message)
        {
            var source = _graph.GetVertexById(message.SourceId);
            var destination = _graph.GetVertexById(message.DestinationId);
            _graph.AddEdge(source, destination, message.Distance, 0);
        }

        public void Handle(OnCostChanged message)
        {
            var source = _graph.GetVertexById(message.SourceId);
            var destination = _graph.GetVertexById(message.DestinationId);
            _graph.UpdateDistance(source, destination, message.Distance);
        }

        public void Handle(OnRemoveEdgeMessage message)
        {
            var source = _graph.GetVertexById(message.SourceId);
            var destination = _graph.GetVertexById(message.DestinationId);
            _graph.RemoveEdge(source, destination);
        }

        public void Handle(OnRunAlgorithmMessage message)
        {
            switch (message.Algorithm)
            {
                case Algorithm.ACS:

                    var startFrom1 = _graph.GetVertexById(message.SourceId);
                    var _params = message.Params;
                    var Best_Paths = new ACS(
                        _graph,
                        _params.PathLengthParam,
                        _params.PathEfficiencyParam,
                        _params.Times,
                        _params.PopSize,
                        _params.LearningRate,
                        _params.EvaporationRate,
                        _params.InitialPheromone,
                        _params.HeuristicsParam,
                        _params.Eps,
                        _params.HillClimbIters,
                        _params.ElitistWayProbability).Find_Ant_Paths(startFrom1);

                    EventAggregator.Instance.Publish(new OnCompletedACSMessage(Best_Paths));

                    break;

                default: break;

            }
        }
    }
}
