using System;

namespace task4
{
    public interface ISwimmable
    {
        int MaxDepth { get; }
        void Swim()
        {
            Console.WriteLine($"I can swim at {MaxDepth} meters underwater!");
        }
    }

    public interface IFlyable
    {
        int MaxHeight { get; }

        void Fly()
        {
            Console.WriteLine($"I can fly at {MaxHeight} meters height!");
        }
    }

    public interface IRunnable
    {
        int MaxSpeed { get; }

        void Run()
        {
            Console.WriteLine($"I can run up to {MaxSpeed} kilometers per hour!");
        }
    }

    public interface IAnimal
    {
        int LifeDuration { get; }

        void Voice()
        {
            Console.WriteLine("No voice!");
        }

        void ShowInfo()
        {
            Console.WriteLine($"I am a {GetType().Name} and I live approximately {LifeDuration} years.");
        }
    }

    public class Cat : IAnimal, IRunnable
    {
        public int LifeDuration { get; } = 15;
        public int MaxSpeed { get; } = 48;
        public void Voice()
        {
            Console.WriteLine("Meow!");
        }

        public void Run()
        {
            Console.WriteLine($"I can run up to {MaxSpeed} kilometers per hour!");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"I am a {GetType().Name} and I live approximately {LifeDuration} years.");
        }
    }

    public class Eagle : IAnimal, IFlyable
    {
        public int LifeDuration { get; } = 20;
        public int MaxHeight { get; } = 3000;

        public void Voice()
        {
            Console.WriteLine("RAAAH, WHAT IS A KILOMETER!");
        }

        public void Fly()
        {
            Console.WriteLine($"I can fly at {MaxHeight} meters height!");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"I am an {GetType().Name} and I live approximately {LifeDuration} years.");
        }
    }

    public class Shark : IAnimal, ISwimmable
    {
        public int LifeDuration { get; } = 25;

        public int MaxDepth { get; } = 2000;

        public void Voice()
        {
            Console.WriteLine("No voice!");
        }

        public void Swim()
        {
            Console.WriteLine($"I can swim at {MaxDepth} meters underwater!");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"I am a {GetType().Name} and I live approximately {LifeDuration} years.");
        }
    }

    class Program
    {
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
        }

        public static void TotalPrice(ILookup<string, Product> lookup)
        {
            foreach (var categoryGroup in lookup)
            {
                Console.WriteLine($"{categoryGroup.Key}:");
                decimal totalCategoryPrice = 0;
                foreach (var product in categoryGroup)
                {
                    Console.WriteLine($"{product.Name} {product.Price:C}");
                    totalCategoryPrice += product.Price;
                }
                Console.WriteLine($"Total price for {categoryGroup.Key}: {totalCategoryPrice:C}");
            }
        }

        static void Main(string[] args)
        {
            var cat = new Cat();
            var eagle = new Eagle();
            var shark = new Shark();

            cat.ShowInfo();
            cat.Voice();
            cat.Run();
            Console.WriteLine();

            eagle.ShowInfo();
            eagle.Fly();
            Console.WriteLine();

            shark.ShowInfo();
            shark.Swim();
            Console.WriteLine('\n');

            var products = new List<Product>
            {
                new Product { Name = "SmartTV", Price = 400, Category = "Electronics" },
                new Product { Name = "Lenovo ThinkPad", Price = 1000, Category = "Electronics" },
                new Product { Name = "iPhone", Price = 700, Category = "Electronics" },
                new Product { Name = "Orange", Price = 2, Category = "Fruits" },
                new Product { Name = "Banana", Price = 3, Category = "Fruits" }
            };

            ILookup<string, Product> lookup = products.ToLookup(prod => prod.Category);

            TotalPrice(lookup);
        }
    }
}
