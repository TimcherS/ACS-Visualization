namespace ACSVisualization.Events
{
    public class OnCostChanged
    {
        public OnCostChanged(string sourceId, string destinationId, int distance)
        {
            Distance = distance;
            SourceId = sourceId;
            DestinationId = destinationId;
        }

        public int Distance { get; }

        public string SourceId { get; }

        public string DestinationId { get; }
    }
}
