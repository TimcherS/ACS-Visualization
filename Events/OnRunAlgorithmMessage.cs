using ACSVisualization.Models.Enums;
using ACSVisualization.ViewModels;

namespace ACSVisualization.Events
{
    public class OnRunAlgorithmMessage
    {
        public OnRunAlgorithmMessage(string sourceId, Algorithm algorithm, ParamData _params)
        {
            Algorithm = algorithm;
            SourceId = sourceId;
            Params = _params;
        }

        public string SourceId { get; }

        public Algorithm Algorithm { get; }

        public ParamData Params { get; }
    }
}
