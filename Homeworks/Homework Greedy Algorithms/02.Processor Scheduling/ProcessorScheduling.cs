using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Processor_Scheduling
{
    public class ProcessorScheduling
    {
        static void Main()
        {
            int tasksCount = int.Parse(Console.ReadLine().Substring(7));
            Dictionary<int, List<Task>> tasks = new Dictionary<int, List<Task>>();
            int maxDeadline = 0;

            for (int i = 1; i <= tasksCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] {" - "}, StringSplitOptions.RemoveEmptyEntries);
                int value = int.Parse(parameters[0]);
                int deadline = int.Parse(parameters[1]);
                if (deadline > maxDeadline)
                {
                    maxDeadline = deadline;
                }

                Task task = new Task(i , value, deadline);
                if (!tasks.ContainsKey(deadline))
                {
                    tasks.Add(deadline, new List<Task>());
                }

                tasks[deadline].Add(task);
            }

            BinaryHeap<Task> nextTasks = new BinaryHeap<Task>();
            List<Task> result = new List<Task>();

            for (int i = maxDeadline; i >= 1; i--)
            {
                if (tasks.ContainsKey(i))
                {
                    foreach (var task in tasks[i])
                    {
                        nextTasks.Insert(task);
                    }
                }

                if (nextTasks.Count() == 0)
                {
                    continue;
                }

                result.Add(nextTasks.ExtractMax());
            }

            var exit = result.OrderBy(d => d.Deadline).ThenByDescending(v => v.Value).Select(n => n.Number);
            Console.WriteLine($"Optimal schedule: {string.Join(" -> ", exit)}");
            Console.WriteLine($"Total value: {result.Sum(r => r.Value)}");
        }
    }
}
