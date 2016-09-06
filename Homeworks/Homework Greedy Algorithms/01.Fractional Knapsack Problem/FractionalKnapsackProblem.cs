using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _01.Fractional_Knapsack_Problem
{
    public class FractionalKnapsackProblem
    {
        public static void Main()
        {
            double capacity = double.Parse(Console.ReadLine().Substring(10));
            int items = int.Parse(Console.ReadLine().Substring(7));
            double totalPrice = 0;
            List<Item> itemsByCostEfficiency = new List<Item>();

            for (int i = 0; i < items; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                int price = int.Parse(parameters[0]);
                int weight = int.Parse(parameters[1]);
                Item newItem = new Item(price, weight);
                itemsByCostEfficiency.Add(newItem);
            }

            itemsByCostEfficiency = itemsByCostEfficiency
                .OrderByDescending(i => i.CostEfficiency).ToList();
            while (capacity > 0)
            {
                Item item = itemsByCostEfficiency[0];
                if (capacity - item.Weight >= 0)
                {
                    capacity -= item.Weight;
                    totalPrice += item.Price;
                    Console.WriteLine(
                        $"Take 100% of item with price {item.Price:F2} and weight {item.Weight:F2}");
                }
                else if (capacity - item.Weight < 0)
                {
                    double percentage = capacity/item.Weight;
                    capacity -= item.Weight;
                    totalPrice += percentage*item.Price;
                    percentage *= 100;
                    Console.WriteLine(
                        $"Take {percentage:F2}% of item with price {item.Price:F2} and weight {item.Weight:F2}");
                }

                itemsByCostEfficiency.Remove(item);
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
