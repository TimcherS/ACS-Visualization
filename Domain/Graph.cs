using System;
using System.Collections.Generic;
using System.Linq;

namespace ACSVisualization.Models
{
    public class Graph
    {
        private readonly IDictionary<Vertex, ICollection<Edge>> _adjacencyList;

        public Graph()
        {
            _adjacencyList = new Dictionary<Vertex, ICollection<Edge>>();
        }

        static Graph _instance;
        public static Graph Instance => _instance ??= new Graph();

        public void AddVertex(Vertex vertex)
        {
            Validate(() => !_adjacencyList.ContainsKey(vertex));

            _adjacencyList.Add(vertex, new List<Edge>());
        }

        public void RemoveVertex(Vertex vertex)
        {
            Validate(() => _adjacencyList.ContainsKey(vertex));

            foreach (var adjacent in _adjacencyList)
            {
                var edge = GetEdge(adjacent.Key, vertex);
                if (edge != null)
                {
                    adjacent.Value.Remove(edge);
                }
            }

            _adjacencyList.Remove(vertex);
        }

        public void AddEdge(Vertex from, Vertex to, int distance, double pheromone)
        {
            Validate(() => _adjacencyList.ContainsKey(from));
            Validate(() => _adjacencyList.ContainsKey(to));

            var srcEdge = new Edge(from, to, distance, pheromone);
            var destEdge = new Edge(to, from, distance, pheromone);

            _adjacencyList[from].Add(srcEdge);
            _adjacencyList[to].Add(destEdge);
        }

        public void RemoveEdge(Vertex from, Vertex to)
        {
            Validate(() => _adjacencyList.ContainsKey(from));
            Validate(() => _adjacencyList.ContainsKey(to));

            var srcEdge = _adjacencyList[from]
                .First(e => Equals(e.To, to));

            var destEdge = _adjacencyList[to]
                .First(e => Equals(e.To, from));

            _adjacencyList[from].Remove(srcEdge);
            _adjacencyList[to].Remove(destEdge);
        }

        public void UpdateDistance(Vertex from, Vertex to, int distance) //NOT MINE - MAYBE REMOVE
        {
            Validate(() => _adjacencyList.ContainsKey(from));
            Validate(() => _adjacencyList.ContainsKey(to));
            Validate(() => distance > 0 && distance <= 99);

            RemoveEdge(from, to);
            AddEdge(from, to, distance, 0); //0???
        }
        public void UpdatePheromone(Vertex from, Vertex to, double pheromone) //MINE
        {
            Validate(() => _adjacencyList.ContainsKey(from));
            Validate(() => _adjacencyList.ContainsKey(to));
            //Validate(() => cost > 0 && cost <= 99);

            int distance = GetEdge(from, to).Distance;
            RemoveEdge(from, to);
            AddEdge(from, to, distance, pheromone);
        }


        public Edge GetEdge(Vertex from, Vertex to)
        {
            Validate(() => _adjacencyList.ContainsKey(from));

            return _adjacencyList[from].FirstOrDefault(v
                => v.From.Equals(from)
                && v.To.Equals(to));
        }
        public List<Edge> GetVertexEdges(Vertex from)
        {
            var result = new List<Edge>();
            foreach (var edge in this._adjacencyList[from])
            {
                result.Add(new Edge(edge.From, edge.To, edge.Distance, edge.Pheromone));
            }
            return result;  
        }

        public int GetVerticesCount()
            => _adjacencyList.Keys.Count;

        public List<Vertex> GetAllVertices()
            => _adjacencyList?.Keys?.ToList() ?? new List<Vertex>();

        public List<Edge> GetAllEdges()
        {
            var result = new List<Edge>();

            foreach (var vertex in _adjacencyList)
                foreach (var adjacent in vertex.Value)
                    result.Add(
                        new Edge(
                            vertex.Key,
                            adjacent.To,
                            adjacent.Distance, adjacent.Pheromone));

            return result;
        }

        public List<Vertex> GetNeighbours(Vertex from)
        {
            var result = new List<Vertex>();

            foreach (var edge in this._adjacencyList.Values.SelectMany(e => e))
                if (Equals(from, edge.From) && !Equals(from, edge.To))
                    result.Add(edge.To);

            return result;
        }

        public int GetDistance(Vertex from, Vertex to)
            => _adjacencyList[from].First(e => Equals(to, e.To)).Distance;

        public Vertex GetVertexById(string id)
            => _adjacencyList.Keys.Single(k => Equals(id, k.Id));

        private void Validate(Func<bool> condition)
        {
            if (!condition())
                throw new InvalidOperationException();
        }
    }
}
