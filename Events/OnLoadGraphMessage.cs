using ACSVisualization.Models.Dto;

namespace ACSVisualization.Events
{
    public class OnLoadGraphMessage
    {
        public OnLoadGraphMessage(IOGraphData data)
        {
            Data = data;
        }

        public IOGraphData Data { get; }
    }
}
