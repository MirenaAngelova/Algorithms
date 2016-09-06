using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _03.Online_Market
{
    class OnlineMarket
    {
        private const int MaxElementsCount = 10;

        private static HashSet<Product> products;
        private static Dictionary<string, SortedSet<Product>> productsByType;
        private static OrderedDictionary<double, SortedSet<Product>> productsByPrice;

        static void Main(string[] args)
        {
            InitializeData();
            ProcessInput();
        }

        private static void ProcessInput()
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] parameters = input.Split();
                string command = parameters[0];

                ExecuteCommand(command, parameters);

                input = Console.ReadLine();
            }
        }

        private static void ExecuteCommand(string command, string[] parameters)
        {
            switch (command)
            {
                case "add":
                    string name = parameters[1];
                    double price = double.Parse(parameters[2]);
                    string type = parameters[3];

                    AddProduct(name, price, type);
                    break;
                //filter by type dairy
                //filter by price from 1.00 to 2.00
                //filter by price from 1.50
                //filter by price to 2.00

                case "filter":
                    string priceType = parameters[2];
                    if (priceType == "type")
                    {
                        type = parameters[3];
                        FilterByType(type);
                    }
                    else
                    {
                        string fromTo = parameters[3];
                        double first = double.Parse(parameters[4]);
                        if (fromTo == "to")
                        {
                            FilterByMaxPrice(first);
                        }
                        else
                        {
                            if (parameters.Length == 7)
                            {
                                double second = double.Parse(parameters[6]);
                                FilterByMinMax(first, second);
                            }
                            else
                            {
                                FilterByMinPrice(first);
                            }
                        }
                    }

                    break;
            }
        }

        private static void FilterByMinPrice(double min)
        {
            int count = 0;
            List<Product> outputProducts = new List<Product>();
            var view = productsByPrice.RangeFrom(min, true);

            foreach (var priceProduct in view)
            {
                if (count >= MaxElementsCount)
                {
                    break;
                }

                foreach (var product in priceProduct.Value)
                {
                    if (count >= MaxElementsCount)
                    {
                        break;
                    }

                    outputProducts.Add(product);
                    count++;
                }
            }

            PrintListOfProducts(outputProducts);
        }

        private static void FilterByMinMax(double min, double max)
        {
            int count = 0;
            List<Product> outputProducts = new List<Product>();
            var view = productsByPrice.Range(min, true, max, true);
            foreach (var priceProduct in view)
            {
                if (count >= MaxElementsCount)
                {
                    break;
                }

                foreach (var product in priceProduct.Value)
                {
                    if (count >= MaxElementsCount)
                    {
                        break;
                    }

                    outputProducts.Add(product);
                    count++;
                }
            }

            PrintListOfProducts(outputProducts);
        }

        private static void FilterByMaxPrice(double maxPrice)
        {
            int count = 0;
            List<Product> outputProducts = new List<Product>();

            foreach (var priceProduct in productsByPrice)
            {
                if (count >= MaxElementsCount || priceProduct.Key > maxPrice)
                {
                    break;
                }

                foreach (var product in priceProduct.Value)
                {
                    if (count >= MaxElementsCount)
                    {
                        break;
                    }

                    outputProducts.Add(product);
                    count++;
                }
            }

            PrintListOfProducts(outputProducts);
        }

        private static void FilterByType(string type)
        {
            if (!productsByType.ContainsKey(type))
            {
                PrintErrorNotFoundTypeMessage(type);
                return;
            }

            List<Product> outputProducts = new List<Product>();
            int count = 0;
            foreach (var product in productsByType[type])
            {
                if (count >= MaxElementsCount)
                {
                    break;
                }

                outputProducts.Add(product);
                count++;
            }

            PrintListOfProducts(outputProducts);
        }

        private static void AddProduct(string name, double price, string type)
        {
            Product product = new Product(name, price, type);
            if (!products.Contains(product))
            {
                products.Add(product);
                PrintAddedSuccessfullyMessage(product.Name);

                if (!productsByPrice.ContainsKey(product.Price))
                {
                    productsByPrice[product.Price] = new SortedSet<Product>();
                }

                productsByPrice[product.Price].Add(product);

                if (!productsByType.ContainsKey(product.Type))
                {
                    productsByType[product.Type] = new SortedSet<Product>();
                }

                productsByType[product.Type].Add(product);
            }
            else
            {
                PrintErrorNotExistingMessage(product.Name);
            }

        }

        private static void PrintListOfProducts(List<Product> outputProducts)
        {
            Console.WriteLine($"Ok: {string.Join(", ", outputProducts)}");
        }

        private static void PrintErrorNotFoundTypeMessage(string type)
        {
            Console.WriteLine($"Error: Type {type} does not exists");
        }

        private static void PrintErrorNotExistingMessage(string name)
        {
            Console.WriteLine($"Error: Product {name} already exists");
        }

        private static void PrintAddedSuccessfullyMessage(string name)
        {
            Console.WriteLine($"Ok: Product {name} added successfully");
        }

        private static void InitializeData()
        {
            products = new HashSet<Product>();
            productsByType = new Dictionary<string, SortedSet<Product>>();
            productsByPrice = new OrderedDictionary<double, SortedSet<Product>>();
        }
    }
}
