using System;

namespace _03.Online_Market
{
    public class Product : IComparable<Product>
    {
        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public int CompareTo(Product other)
        {
            if (this.Price.CompareTo(other.Price) == 0)
            {
                if (this.Name.CompareTo(other.Name) == 0)
                {
                   return this.Type.CompareTo(other.Type);
                }

                return this.Name.CompareTo(other.Name);
            }

            return this.Price.CompareTo(other.Price);
        }

        public override bool Equals(object obj)
        {
            return this.Name == ((Product)obj).Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.Name}({this.Price})";
        }
    }
}