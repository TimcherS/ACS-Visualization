using ACSVisualization.Models;
using ACSVisualization.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;

namespace ACSVisualization.Algorithms
{
    public class ACS
    {
        private readonly Graph _graph;
        private readonly IDictionary<Vertex, int> _distances;
        private readonly IDictionary<Vertex, ICollection<Vertex>> _visitLog;
        private readonly ICollection<Vertex> _verticesToVisit;
        private readonly IDictionary<Vertex, Vertex> _shortestPaths;

        double PathLengthParam;
        double PathEfficiencyParam;

        int Times;
        int PopSize;
        double LearningRate;
        double EvaporationRate;
        double PheromoneInitial;

        double HeuristicsParam;
        double eps;
        int HillClimbIters;
        double ElitistWayPropability;

        public ACS(Graph graph,
            double PathLengthParam,
            double PathEfficiencyParam,
            int Times,
            int PopSize,
            double LearningRate,
            double EvaporationRate,
            double PheromoneInitial,
            double HeuristicsParam,
            double eps,
            int HillClimbIters,
            double ElitistWayPropability)
        {
            this.PathLengthParam = PathLengthParam;
            this.PathEfficiencyParam = PathEfficiencyParam;
            this.Times = Times;
            this.PopSize = PopSize;
            this.LearningRate = LearningRate;
            this.EvaporationRate = EvaporationRate;
            this.PheromoneInitial = PheromoneInitial;
            this.HeuristicsParam = HeuristicsParam;
            this.eps = eps;
            this.HillClimbIters = HillClimbIters;
            this.ElitistWayPropability = ElitistWayPropability;

            _graph = graph;
            _distances = new Dictionary<Vertex, int>();
            _visitLog = new Dictionary<Vertex, ICollection<Vertex>>();
            _verticesToVisit = new List<Vertex>();
            _shortestPaths = new Dictionary<Vertex, Vertex>();
        }

        private void Initialize(Vertex source)
        {
            _distances.Clear();
            _verticesToVisit.Clear();
            _visitLog.Clear();
            _shortestPaths.Clear();

            _distances[source] = 0;

            foreach (var vertex in _graph.GetAllVertices())
            {
                if (!Equals(vertex, source))
                {
                    _distances[vertex] = int.MaxValue;
                }
                _verticesToVisit.Add(vertex);
            }
        }

        public double DesirabilityF(Edge edge)
        {
            return (1 / edge.Distance);
        }

        private double FitnessF(List<Edge> Path, double PathLengthParam, double PathEfficiencyParam)
        {
            // PathLengthParam - Param for increase in number of visited cities
            // PathEfficiencyParam - Param for decrease in covered distance
            int TotalCities = this._graph.GetVerticesCount();
            int VisitedCities = Path.Count();
            double LengthTotal = 0;
            double PathLength = 0;
            foreach (Edge edge in this._graph.GetAllEdges())
            {
                LengthTotal += edge.Distance;
            }
            foreach (Edge edge in Path)
            {
                PathLength += edge.Distance;
            }
            double F = 0;
            if (LengthTotal != 0) // YOU CAN START ALGO WITH ONE VERTEX AND NO EDGES
                F = PathLengthParam * (VisitedCities / TotalCities) - PathEfficiencyParam * (PathLength / LengthTotal); // PathLength / TotalCities is intentional 
            return F;
        }
        private int RandomChoiceWithProbability(List<double> Probabilities) // ROULETTE METHOD
        {
            List<double> Temp = new List<double>();
            Random rnd = new Random();
            double thresh = rnd.NextDouble();
            double c = 0;
            foreach (var x in Probabilities)
            {
                c += x;
                Temp.Add(c);
            }
            for (int i = 0; i < Probabilities.Count; i++)
            {
                if (Temp[i] >= thresh)
                    return i;
            }
            return 0;
        }
        private int LNN()
        {
            int Result = 1;
            //int N = this._graph.GetVerticesCount();
            //bool isFullyConnected = true; // May be useful for future reinditions of LNN function
            //foreach (Vertex v in this._graph.GetAllVertices())
            //{
            //    if (this._graph.GetNeighbours(v) != (N-1))
            //    {
            //        ifFullyConnected = false;
            //        break;
            //    }
            //}
            List<Vertex> Vertexes = this._graph.GetAllVertices();
            Random rnd = new Random();
            string StartVertexId = Vertexes[rnd.Next(0, this._graph.GetVerticesCount())].Id;
            HashSet<string> VisitedIds = new HashSet<string>();

            while (true)
            {
                int minDistance = int.MaxValue;
                string NextVectorId = StartVertexId;
                List<Edge> Edges = this._graph.GetVertexEdges(this._graph.GetVertexById(StartVertexId)); 
                foreach (Edge e in Edges)
                {
                    if (e.Distance < minDistance && VisitedIds.Contains(e.To.Id) == false)
                    {
                        minDistance = e.Distance;
                        NextVectorId = e.To.Id;
                    }
                }
                if (minDistance == int.MaxValue)
                    break;

                Result += minDistance;
                VisitedIds.Add(StartVertexId);
                StartVertexId = NextVectorId;
            }
            return Result;
        }

        public List<List<Edge>> Find_Ant_Paths(Vertex From)
        {
            int Vertex_N = this._graph.GetVerticesCount();
            // SETTING DEFAULT PHEROMONE VALUES
            foreach (Edge edge in _graph.GetAllEdges())
            {
                this._graph.UpdatePheromone(edge.From, edge.To, this.PheromoneInitial);
            }
            List<List<Edge>> Best_Paths = new List<List<Edge>>();
            for (int paths = 0; paths < this.Times; paths++) {

                List<Edge> Best_Path = new List<Edge>();
                double Best_Fitness = double.MinValue;

                for (int iter = 0; iter < this.PopSize; iter++)
                {
                    List<Edge> Path = new List<Edge>();
                    HashSet<string> VisitedIDs = new HashSet<string>();
                    VisitedIDs.Add(From.Id);
                    Vertex Pos = From;

                    while (true)
                    {
                        double Sum = 0;
                        foreach (Edge edge in this._graph.GetVertexEdges(Pos))
                        {
                            if (VisitedIDs.Contains(edge.To.Id))
                                continue;

                            if (edge.Pheromone == 0)
                                Sum += Math.Pow(DesirabilityF(edge), this.HeuristicsParam);
                            else
                                Sum += Math.Pow(edge.Pheromone, this.LearningRate) * Math.Pow(DesirabilityF(edge), this.HeuristicsParam);
                        }

                        if (Sum == 0)
                            break;

                        List<string> NextIds = new List<string>();
                        List<double> NextIdProbabilites = new List<double>();

                        foreach (Edge edge in this._graph.GetVertexEdges(Pos))
                        {
                            if (VisitedIDs.Contains(edge.To.Id))
                                continue;

                            double value;
                            if (edge.Pheromone == 0)
                                value = Math.Pow(DesirabilityF(edge), this.EvaporationRate);
                            else
                                value = Math.Pow(edge.Pheromone, this.LearningRate) * Math.Pow(DesirabilityF(edge), this.EvaporationRate);

                            NextIds.Add(edge.To.Id);
                            NextIdProbabilites.Add(value / Sum);

                        }
                        string NextVertexId = Pos.Id; // IN THIS CASE IT WILL ALWAYS CHANGE (Sum != 0) - SURE?
                        double max = 0;

                        List<double> ElitistRuleOrNot = new List<double>{ this.ElitistWayPropability, 1 - this.ElitistWayPropability};
                        if (true)
                        {
                            // CHOOSING BEST ROUTE - ELITIST RULE
                            for (int i = 0; i < NextIds.Count; i++)
                            {
                                if (max < NextIdProbabilites[i])
                                {
                                    max = NextIdProbabilites[i];
                                    NextVertexId = NextIds[i];
                                }
                            }
                        }
                        else
                        {
                            // CHOOSING PATH BY THEIR PROBABLILITY
                            NextVertexId = NextIds[RandomChoiceWithProbability(NextIdProbabilites)];                       
                        }
                        if (NextVertexId == Pos.Id)
                            break;

                        Vertex New_Pos = this._graph.GetVertexById(NextVertexId);
                        Path.Add(_graph.GetEdge(Pos, New_Pos));

                        // LOCAL PHEROMONE UPDATE

                        this._graph.UpdatePheromone(Pos, New_Pos, (1 - this.eps) * this._graph.GetEdge(Pos, New_Pos).Pheromone
                            + this.PheromoneInitial * this.eps);

                        VisitedIDs.Add(New_Pos.Id);
                        Pos = New_Pos;
                    }

                    // ADD FINAL EDGE WHICH LEADS TO START POSITION IF IT IS HAMILTONIAN CYCLE
                    if (Path.Count() > 1)
                    {
                        List<Vertex> neighbors = this._graph.GetNeighbours(Pos);
                        foreach (Vertex neighbor in neighbors)
                        {
                            if (neighbor.Id == From.Id) 
                            {
                                Path.Add(this._graph.GetEdge(Pos, neighbor));
                                break;
                            }
                        }
                    }

                    double New_Fitness = FitnessF(Path, this.PathLengthParam, this.PathEfficiencyParam);
                    if (New_Fitness > Best_Fitness)
                    {
                        Best_Fitness = New_Fitness;
                        Best_Path.Clear(); // D
                        foreach (Edge edge in Path)
                            Best_Path.Add(new Edge(edge.From, edge.To, edge.Distance, edge.Pheromone));
                    }
                }
                // GLOBAL UPDATE RULE

                // EVAPORATING OLD PHEROMONES
                foreach (Edge edge in _graph.GetAllEdges())
                {
                    this._graph.UpdatePheromone(edge.From, edge.To, (1 - this.EvaporationRate) * edge.Pheromone);
                }

                // ADDING PHEROMONES ALONG NEW TRAIL
                // RULE FOR DEALING WITH DEAD ENDS
                if (Best_Path.Count() <= Math.Max(Vertex_N * 0.05, 3))
                {
                    for (int i = 0; i < Best_Path.Count; i++)
                    {
                        this._graph.UpdatePheromone(Best_Path[i].From, Best_Path[i].To,
                            this._graph.GetEdge(Best_Path[i].From, Best_Path[i].To).Pheromone * 0.001); // ABS cause FitnessF might be negative
                    }
                }
                else
                {
                    for (int i = 0; i < Best_Path.Count; i++)
                    {
                        this._graph.UpdatePheromone(Best_Path[i].From, Best_Path[i].To,
                            this._graph.GetEdge(Best_Path[i].From, Best_Path[i].To).Pheromone + this.LearningRate * Math.Abs(FitnessF(Best_Path, this.PathLengthParam, this.PathEfficiencyParam))); // ABS cause FitnessF might be negative
                    }
                }
                Best_Paths.Add(Best_Path);
            }
            foreach (List<Edge> path in Best_Paths)
            {
                foreach (Edge edge in path)
                {
                    Console.Write($"[{edge.From.Id}, {edge.To.Id}, {edge.Pheromone}], ");
                }
                Console.WriteLine("END of PATH");
            }
            Console.WriteLine("ALGO-END");
            return Best_Paths;
        }
    }
}
