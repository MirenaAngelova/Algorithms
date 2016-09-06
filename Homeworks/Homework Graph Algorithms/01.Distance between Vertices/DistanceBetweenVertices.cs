using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _01.Distance_between_Vertices
{
    public class DistanceBetweenVertices
    {
        static void Main()
        {
            Node g1Element1 = new Node(1);
            Node g1Element2 = new Node(2);

            g1Element1.Children.Add(g1Element2);
            var graph1 = new List<Node>() { g1Element1, g1Element2};

            Node g2Element1 = new Node(1);
            Node g2Element2 = new Node(2);
            Node g2Element3 = new Node(3);
            Node g2Element4 = new Node(4);
            Node g2Element5 = new Node(5);
            Node g2Element6 = new Node(6);
            Node g2Element7 = new Node(7);
            Node g2Element8 = new Node(8);

            g2Element1.Children.Add(g2Element4);
            g2Element2.Children.Add(g2Element4);
            g2Element3.Children = new List<Node>() {g2Element4, g2Element5};
            g2Element4.Children.Add(g2Element6);
            g2Element5.Children = new List<Node>() { g2Element3, g2Element7, g2Element8 };
            g2Element7.Children.Add(g2Element8);
            var graph2 = new List<Node>()
            {
                g2Element1, g2Element2, g2Element3, g2Element4,
                g2Element5, g2Element6, g2Element7, g2Element8
            };

            Node g3Element1 = new Node(11);
            Node g3Element2 = new Node(4);
            Node g3Element3 = new Node(1);
            Node g3Element4 = new Node(7);
            Node g3Element5 = new Node(12);
            Node g3Element6 = new Node(19);
            Node g3Element7 = new Node(21);
            Node g3Element8 = new Node(14);
            Node g3Element9 = new Node(31);

            g3Element1.Children.Add(g3Element2);
            g3Element2.Children= new List<Node>() {g3Element5, g3Element3};
            g3Element3.Children= new List<Node>() {g3Element5, g3Element7, g3Element4};
            g3Element4.Children.Add(g3Element7);
            g3Element5.Children = new List<Node>() { g3Element2, g3Element6 };
            g3Element6.Children = new List<Node>() { g3Element3, g3Element7 };
            g3Element7.Children = new List<Node>() { g3Element8, g3Element9 };
            g3Element8.Children.Add(g2Element8);

           var graph3 = new List<Node>()
           {
               g3Element1, g3Element2, g3Element3, g3Element4,
               g3Element5, g3Element6, g3Element7, g3Element8, g3Element9
           };

            Console.WriteLine("Test1:");
            BreadthFirstSearch(graph1, 1, 2);
            BreadthFirstSearch(graph1, 2, 1);
            Console.WriteLine();

            Console.WriteLine("Test2:");
            BreadthFirstSearch(graph2, 1, 6);
            BreadthFirstSearch(graph2, 1, 5);
            BreadthFirstSearch(graph2, 5, 6);
            BreadthFirstSearch(graph2, 5, 8);
            Console.WriteLine();

            Console.WriteLine("Test3:");
            BreadthFirstSearch(graph3, 11, 7);
            BreadthFirstSearch(graph3, 11, 21);
            BreadthFirstSearch(graph3, 21, 4);
            BreadthFirstSearch(graph3, 19, 14);
            BreadthFirstSearch(graph3, 1, 4);
            BreadthFirstSearch(graph3, 1, 11);
            BreadthFirstSearch(graph3, 31, 21);
            BreadthFirstSearch(graph3, 11, 14);
            Console.WriteLine();
        }

        private static void BreadthFirstSearch(List<Node> graph, int startValue, int endValue)
        {
            // reset distances
            foreach (var node in graph)
            {
                node.Distance = -1;
            }

            var queue = new Queue<Node>();
            Node start = graph.First(x => x.Value == startValue);
            start.Distance = 0;
            Node end = graph.First(x => x.Value == endValue);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == end)
                {
                    break;
                }

                foreach (var child in node.Children)
                {
                    if (child.Distance == -1)
                    {
                        child.Distance = node.Distance + 1;
                        queue.Enqueue(child);
                    }
                }
            }

            Console.WriteLine($"{{{startValue},{endValue}}} -> {end.Distance}");
        }
    }
}
