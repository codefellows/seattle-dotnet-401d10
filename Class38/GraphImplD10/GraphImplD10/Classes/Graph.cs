using System;
using System.Collections.Generic;
using System.Text;

namespace GraphImplD10.Classes
{
    class Graph<T>
    {
        public Dictionary<Vertex<T>, List<Edge<T>>> AdjacencyList { get; set; }

        private int _size;

        public Graph()
        {
            AdjacencyList = new Dictionary<Vertex<T>, List<Edge<T>>>();
        }

        // Add Node/Vertex to the graph/adjacency List
        public Vertex<T> AddNode(T value)
        {
            Vertex<T> node = new Vertex<T>(value);
            AdjacencyList.Add(node, new List<Edge<T>>());
            _size++;
            return node;
        }

        // add edge
        public void AddDirectedEdge(Vertex<T> a, Vertex<T> b, int weight)
        {
            AdjacencyList[a].Add(
                new Edge<T>
                {
                    Vertex = b,
                    Weight = weight
                   
                }
                );
        }

        public void AddUndirectedEdge(Vertex<T> a, Vertex<T> b, int weight)
        {
            AddDirectedEdge(a, b, weight);
            AddDirectedEdge(b, a, weight);
        }

        public List<Vertex<T>> GettAllVertices()
        {
            List<Vertex<T>> vertices = new List<Vertex<T>>();

            foreach (var vertex in AdjacencyList)
            {
                vertices.Add(vertex.Key);
            }

            return vertices;
        }

        // Get Neighbors
        public List<Edge<T>> GetNeighbors(Vertex<T> vertex)
        {
            // get all edges connected to a vertex
            return AdjacencyList[vertex];
        }

        public int Size()
        {
            return _size;
        }

        public void Print()
        {
            foreach (var vertex in AdjacencyList)
            {
                Console.Write($"{vertex.Key.Value}: ");

                foreach (var edge in vertex.Value)
                {
                    Console.Write($"{edge.Vertex.Value}, {edge.Weight} ->");
                }
                Console.WriteLine("null");
            }
        }

    }
}
