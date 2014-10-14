namespace OnlineMarket
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using Wintellect.PowerCollections;
    
    // 100 points
    public class OnlineMarket
    {
        private static ProductsRepository repository = new ProductsRepository();
        private static StringBuilder output = new StringBuilder();

        private const string AddCommand = "add";
        private const string FilterByTypeCommand = "filter by type";
        private const string FilterByPriceFromCommand = "filter by price from";
        private const string FilterByPriceToCommand = "filter by price to";
        private const string EndCommand = "end";
        private const double MaxPrice = 5000;
        private const int ProductsLimit = 10;

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string command = null;
            while (command != EndCommand)
            {
                command = Console.ReadLine();
                ProcessCommand(command);
            }

            Console.WriteLine(output.ToString().TrimEnd());
        }

        private static void ProcessCommand(string command)
        {
            string commandName = string.Empty;
            List<string> commandArguments = new List<string>();

            if (command.StartsWith(AddCommand))
            {
                commandName = AddCommand;

                var commandArgumentsString = command.Substring(commandName.Length + 1);
                commandArguments = commandArgumentsString.Split(' ').ToList();
            }
            else if (command.StartsWith(FilterByTypeCommand))
            {
                commandName = FilterByTypeCommand;

                var commandArgumentsString = command.Substring(commandName.Length + 1);
                commandArguments = commandArgumentsString.Split(' ').ToList();
            }
            else if (command.StartsWith(FilterByPriceFromCommand))
            {
                commandName = FilterByPriceFromCommand;

                var commandArgumentsString = command.Substring(commandName.Length + 1);
                commandArguments = commandArgumentsString.Split(
                    new string[] { "to" },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }
            else if (command.StartsWith(FilterByPriceToCommand))
            {
                commandName = FilterByPriceToCommand;

                var commandArgumentsString = command.Substring(commandName.Length + 1);
                commandArguments = commandArgumentsString.Split(' ').ToList();
            }
            else if (command.StartsWith(EndCommand))
            {
                commandName = EndCommand;
            }

            double fromPrice;
            double toPrice;

            switch (commandName)
            {
                case AddCommand:
                    var name = commandArguments[0];
                    var price = double.Parse(commandArguments[1]);
                    var type = commandArguments[2];
                    ProcessAddProductCommand(name, price, type);

                    break;
                case FilterByTypeCommand:
                    name = commandArguments[0];
                    ProcessFindProductsByTypeCommand(name);

                    break;
                case FilterByPriceFromCommand:
                    fromPrice = double.Parse(commandArguments[0]);

                    if (commandArguments.Count == 2)
                    {
                        toPrice = double.Parse(commandArguments[1]);
                    }
                    else
                    {
                        toPrice = MaxPrice;
                    }

                    ProcessFindProductsByPriceRangeCommand(fromPrice, toPrice);

                    break;
                case FilterByPriceToCommand:
                    fromPrice = 0;
                    toPrice = double.Parse(commandArguments[0]);
                    ProcessFindProductsByPriceRangeCommand(fromPrice, toPrice);

                    break;
                case EndCommand:
                    break;
                default:
                    throw new InvalidOperationException("Invalid command: " + command);
            }
        }

        private static void ProcessAddProductCommand(string name, double price, string type)
        {
            var product = new Product(name, price, type);
            var result = repository.Add(product);

            if (result == true)
            {
                output.AppendFormat("Ok: Product {0} added successfully", name).AppendLine();
            }
            else
            {
                output.AppendFormat("Error: Product {0} already exists", name).AppendLine();
            }
        }

        private static void ProcessFindProductsByTypeCommand(string type)
        {
            var typeExists = repository.TypeExists(type);
            if (!typeExists)
            {
                output.AppendFormat("Error: Type {0} does not exists", type).AppendLine();

                return;
            }

            var products = repository.FindByType(type);
            AddFoundProductsToOutput(products, ProductsLimit);
        }

        private static void ProcessFindProductsByPriceRangeCommand(double fromPrice, double toPrice)
        {
            var products = repository.FindByPriceRange(fromPrice, toPrice);
            AddFoundProductsToOutput(products, ProductsLimit);
        }

        private static void AddFoundProductsToOutput(ICollection<Product> products, int limit)
        {
            var productsCount = products.Count;

            if (productsCount > 0)
            {
                List<Product> sortedProducts = new List<Product>(products);
                sortedProducts.Sort();

                var productsToDisplay = sortedProducts.Take(limit).ToList();

                StringBuilder builder = new StringBuilder();
                builder.Append("Ok: ");
                foreach (var product in productsToDisplay)
                {
                    builder.Append(product.ToString()).Append(", ");
                }
                builder.Length = builder.Length - 2; // remove last ", "

                output.AppendLine(builder.ToString());
            }
            else
            {
                output.AppendLine("Ok: ");
            }
        }
    }

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
            int result = this.Price.CompareTo(other.Price);

            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }

            if (result == 0)
            {
                result = this.Type.CompareTo(other.Type);
            }

            return result;
        }

        public override string ToString()
        {
            string toString = this.Name + "(" + this.Price + ")";

            return toString;
        }
    }

    public class ProductsRepository
    {
        private readonly Dictionary<string, Product> productsByName;
        private readonly MultiDictionary<string, Product> productsByType;
        private readonly OrderedMultiDictionary<double, Product> productsByPrice;

        public ProductsRepository()
        {
            this.productsByName = new Dictionary<string, Product>();
            this.productsByType = new MultiDictionary<string, Product>(true);
            this.productsByPrice = new OrderedMultiDictionary<double, Product>(true);
        }

        public bool Add(Product product)
        {
            if (productsByName.ContainsKey(product.Name))
            {
                return false;
            }

            this.productsByName.Add(product.Name, product);
            this.productsByType.Add(product.Type, product);
            this.productsByPrice.Add(product.Price, product);

            return true;
        }

        public ICollection<Product> FindByType(string type)
        {
            return this.productsByType[type];
        }

        public ICollection<Product> FindByPriceRange(double fromPrice, double toPrice)
        {
            return this.productsByPrice.Range(fromPrice, true, toPrice, true).Values;
        }

        public bool TypeExists(string type)
        {
            return this.productsByType.ContainsKey(type);
        }
    }
}