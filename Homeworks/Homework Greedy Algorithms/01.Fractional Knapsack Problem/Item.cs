using System;

namespace _01.Fractional_Knapsack_Problem
{
    public class Item : IComparable<Item>
    {
        public Item(int price, int weight)
        {
            this.Price = price;
            this.Weight = weight;
            this.CostEfficiency = price/(double) weight;
        }

        public double CostEfficiency { get; set; }

        public int Weight { get; set; }

        public int Price { get; set; }

        public int CompareTo(Item other)
        {
            return this.CostEfficiency.CompareTo(other.CostEfficiency);
        }
    }
}