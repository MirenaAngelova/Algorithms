using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Fast_and_Furious
{
    public class FastAndFurious
    {
        public static void Main()
        {
            Dictionary<string, Node> graph = new Dictionary<string, Node>();

            Console.ReadLine();
            string inputRoads = Console.ReadLine();
            while (inputRoads != "Records:")
            {
                string[] parameters = inputRoads.Split();
               
                string startRoad = parameters[0];
                string endRoad = parameters[1];
                decimal distance = decimal.Parse(parameters[2]);
                decimal speedLimit = decimal.Parse(parameters[3]);
                decimal travelingHours = distance / speedLimit;

                Edge edge = new Edge(startRoad, endRoad, travelingHours);
                Edge reverse = new Edge(endRoad, startRoad, travelingHours);
                if (!graph.ContainsKey(startRoad))
                {
                    graph.Add(startRoad, new Node(startRoad, decimal.MaxValue));
                }

                if (!graph.ContainsKey(endRoad))
                {
                    graph.Add(endRoad, new Node(endRoad, decimal.MaxValue));
                }

                graph[startRoad].Edges.Add(edge);
                graph[endRoad].Edges.Add(reverse);

                inputRoads = Console.ReadLine();

            }

            var cars = new SortedDictionary<string, List<KeyValuePair<DateTime, string>>>();
           
            string inputRecords = Console.ReadLine();
            while (inputRecords != "End")
            {
                string[] parameters = inputRecords.Split();
                string road = parameters[0];
                string carNumber = parameters[1];
                DateTime time = DateTime.Parse(parameters[2]);
                KeyValuePair<DateTime, string> observation = 
                    new KeyValuePair<DateTime, string>(time, road);
                if (!cars.ContainsKey(carNumber))
                {
                    cars.Add(carNumber, new List<KeyValuePair<DateTime, string>>());
                }

                cars[carNumber].Add(observation);
                inputRecords = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                if (IsSpeeding(car, graph))
                {
                    Console.WriteLine(car.Key);
                }
            }
        }

        private static bool IsSpeeding
            (KeyValuePair<string, List<KeyValuePair<DateTime, string>>> car, 
            Dictionary<string, Node> graph)
        {
            List<KeyValuePair<DateTime, string>> observation = car
                .Value
                .OrderByDescending(date => date.Key).ToList();
            for (int i = 0; i < observation.Count; i++)
            {
                for (int j = i + 1; j < observation.Count; j++)
                {
                    TimeSpan travelTime = observation[i].Key.Subtract(observation[j].Key);
                    TimeSpan allowedTime = Dijkstra(
                        observation[j].Value,
                        observation[i].Value,
                        graph);
                    TimeSpan difference = travelTime.Subtract(allowedTime);

                    if (difference.TotalSeconds < 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static TimeSpan Dijkstra(string start, string end, Dictionary<string, Node> graph)
        {
            foreach (var road in graph)
            {
                road.Value.TravelTime = decimal.MaxValue;
            }

            HashSet<string> added = new HashSet<string>();
            HashSet<string> visited = new HashSet<string>();

            graph[start].TravelTime = 0;
            BinaryHeap<Node> priorityQueue = new BinaryHeap<Node>();
            priorityQueue.Insert(graph[start]);
            visited.Add(start);

            while (priorityQueue.Count > 0)
            {
                Node currentNode = priorityQueue.ExtractMin();
                visited.Add(currentNode.Name);
                if (currentNode.Name == end)
                {
                    break;
                }

                foreach (var edge in currentNode.Edges)
                {
                    if (!visited.Contains(edge.Child))
                    {
                        if (!added.Contains(edge.Child))
                        {
                            priorityQueue.Insert(graph[edge.Child]);
                            added.Add(edge.Child);
                        }

                        decimal currentTravelTime = currentNode.TravelTime + edge.TravelTime;
                        if (graph[edge.Child].TravelTime > currentTravelTime)
                        {
                            graph[edge.Child].TravelTime = currentTravelTime;
                            priorityQueue.Reorder(graph[edge.Child]);
                        }
                    }
                }
            }

            if (graph[end].TravelTime == decimal.MaxValue)
            {
                return new TimeSpan(0, 0, 0);
            }

            int hours = (int)graph[end].TravelTime;
            decimal rest = (graph[end].TravelTime - hours) * 60;
            int minutes = (int)rest;
            rest = rest - minutes;
            int seconds = (int)Math.Round(rest * 60);
            TimeSpan timeTraveled = new TimeSpan(hours, minutes, seconds);
            return timeTraveled;
        }
    }
}
