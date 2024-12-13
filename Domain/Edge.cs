namespace ACSVisualization.Models
{
    public class Edge
    {
        public Edge(Vertex from, Vertex to, int distance, double pheromone)
        {
            From = from;
            To = to;
            Distance = distance;
            Pheromone = pheromone;
        }

        public Vertex From { get; }

        public Vertex To { get; }

        public int Distance { get; }

        public double Pheromone { get; }

        //REMOVE???
        public override string ToString()
        {
            return $"{From} -> {To} = {Distance}";
        }
        //
    }
}
