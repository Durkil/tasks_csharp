using System;

namespace Task1
{
    public class MyAccessModifiers
    {
        private int birthYear;
        protected string personalInfo;
        internal string IdNumber;

        public MyAccessModifiers(int birthYear, string idNumber, string personalInfo)
        {
            this.birthYear = birthYear;
            IdNumber = idNumber;
            this.personalInfo = personalInfo;
        }

        public int Age => DateTime.Now.Year - birthYear;

        public static byte averageMiddleAge { get; set; } = 50;

        public string Name { get; set; }

        public string NickName { get; internal set; }

        protected internal bool HasLivedHalfOfLife()
        {
            return Age >= averageMiddleAge;
        }

        public static bool operator ==(MyAccessModifiers obj1, MyAccessModifiers obj2)
        {
            if (ReferenceEquals(obj1, obj2))
                return true;
            if (obj1 is null || obj2 is null)
                return false;
            return obj1.Name == obj2.Name && obj1.Age == obj2.Age && obj1.personalInfo == obj2.personalInfo;
        }

        public static bool operator !=(MyAccessModifiers obj1, MyAccessModifiers obj2)
        {
            return !(obj1 == obj2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyAccessModifiers[] objects = new MyAccessModifiers[]
            {
                new MyAccessModifiers(1995, "654321", "Michael Peretyatko") { Name = "Michael", NickName = "Mickey" },
                new MyAccessModifiers(1985, "987654", "John Dolinski") { Name = "John", NickName = "Johnny" },
                new MyAccessModifiers(2005, "723410", "Kris Sabadosh") {Name = "Kris", NickName = "KrisSab"},
                new MyAccessModifiers(1950, "848356", "Vadim Ishuk") {Name = "Vadim", NickName = "Vadick"},
                new MyAccessModifiers(1964, "335295", "Ronnie Coleman") {Name = "Ronnie", NickName = "Yeah Buddy"},
                new MyAccessModifiers(1950, "848356", "Vadim Ishuk") {Name = "Vadim", NickName = "Vadick"}
            };

            foreach (MyAccessModifiers obj in objects)
            {
                Console.WriteLine($"Name: {obj.Name}");
                Console.WriteLine($"Nickname: {obj.NickName}");
                Console.WriteLine($"Age: {obj.Age}\n");
            }

            Console.WriteLine("What objects do you want to compare?\nEnter a num of the first object:");
            int objectNumber1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a num of the second object:");
            int objectNumber2 = int.Parse(Console.ReadLine());

            if (objectNumber1 >= 1 && objectNumber1 <= objects.Length &&
                objectNumber2 >= 1 && objectNumber2 <= objects.Length)
            {
                bool areEqual = objects[objectNumber1 - 1] == objects[objectNumber2 - 1];
                if (areEqual)
                {
                    Console.WriteLine("Objects are same");
                }
                else
                {
                    Console.WriteLine("Objects are NOT same");
                }
            }
            else
            {
                Console.WriteLine("Num of an object is wrong.");
            }
        }
    }
}
