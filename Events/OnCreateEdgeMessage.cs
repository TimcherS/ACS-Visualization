namespace ACSVisualization.Events
{
    public class OnCreateEdgeMessage
    {
        public OnCreateEdgeMessage(string sourceId, string destinationId, int distance)
        {
            SourceId = sourceId;
            DestinationId = destinationId;
            Distance = distance;
        }

        public string SourceId { get; }

        public string DestinationId { get; }

        public int Distance { get; }
    }
}
