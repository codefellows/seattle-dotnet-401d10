using GraphImplD10.Classes;
using System;

namespace GraphImplD10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GraphExample();
        }

        static void GraphExample()
        {
            // add a bunch of nodes to our graph

            Graph<string> graph = new Graph<string>();

            var nd = graph.AddNode("North Dakota");
            var mt = graph.AddNode("Montana");
            var ca = graph.AddNode("California");
            var ga = graph.AddNode("Georgia");
            var wa = graph.AddNode("Washington");

            graph.AddDirectedEdge(wa, nd, 125);
            graph.AddDirectedEdge(ca, mt, 100);
            graph.AddUndirectedEdge(ga, mt, 72);
            graph.AddDirectedEdge(wa, ca, 11);
            graph.AddUndirectedEdge(nd, mt, 7);

            graph.Print();


            var neighbors = graph.GetNeighbors(wa);
            var getAll = graph.GettAllVertices();
        }

        // Get Nodes

        // Get Neighbors
    }
}
