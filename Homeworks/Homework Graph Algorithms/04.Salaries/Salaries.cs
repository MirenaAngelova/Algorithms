using System;
using System.Collections.Generic;

namespace _04.Salaries
{
    public class Salaries
   {
       private static Dictionary<int, List<int>> graph;
       private static Dictionary<int, long> salaries;
         
        public static void Main()
        {
            graph = new Dictionary<int, List<int>>();
            salaries = new Dictionary<int, long>();

            int employees = int.Parse(Console.ReadLine());
            for (int employee = 0; employee < employees; employee++)
            {
                graph.Add(employee, new List<int>());
                string subordinates = Console.ReadLine();
                for (int subordinate = 0; subordinate < subordinates.Length; subordinate++)
                {
                    if (subordinates[subordinate] == 'Y')
                    {
                        graph[employee].Add(subordinate);
                    } 
                }
            }

            long totalSalary = 0;
            foreach (var employee in graph.Keys)
            {
                totalSalary += CalculateSalary(employee);
            }

            Console.WriteLine(totalSalary);
        }

       private static long CalculateSalary(int employee)
       {
           if (graph[employee].Count == 0)
           {
               return 1;
           }

           if (salaries.ContainsKey(employee))
           {
               return salaries[employee];
           }

           long salary = 0;
           foreach (var subordinate in graph[employee])
           {
               salary += CalculateSalary(subordinate);
           }

           salaries.Add(employee, salary);
           return salary;
       }
   }
}
