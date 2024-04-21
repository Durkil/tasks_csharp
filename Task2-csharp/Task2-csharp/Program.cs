using System;

public class Employee
{
    internal string name;
    private DateTime hiringDate;

    public Employee(string name, DateTime hiringDate)
    {
        this.name = name;
        this.hiringDate = hiringDate;
    }

    public int Experience()
    {
        DateTime currentDate = DateTime.Now;
        int experienceYears = currentDate.Year - hiringDate.Year;
        if (currentDate.Month < hiringDate.Month || (currentDate.Month == hiringDate.Month && currentDate.Day < hiringDate.Day))
        {
            experienceYears--;
        }
        return experienceYears;
    }

    public void ShowInfo()
    {
        if (Experience() < 2)
        {
            Console.WriteLine($"{name} has {Experience()} year of experience");
        }
        else
        {
            Console.WriteLine($"{name} has {Experience()} years of experience");
        }
    }
}

public class Developer : Employee
{
    private string programmingLanguage;

    public Developer(string name, DateTime hiringDate, string programmingLanguage) : base(name, hiringDate)
    {
        this.programmingLanguage = programmingLanguage;
    }

    public new void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"{name} is {programmingLanguage} programmer\n");
    }
}

public class Tester : Employee
{
    private bool isAutomation;

    public Tester(string name, DateTime hiringDate, bool isAutomation) : base(name, hiringDate)
    {
        this.isAutomation = isAutomation;
    }

    public new void ShowInfo()
    {
        base.ShowInfo();
        if (isAutomation)
        {
            Console.WriteLine($"{name} is automated tester\n");
        }
        else
        {
            Console.WriteLine($"{name} is manual tester\n");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Developer dev1 = new Developer("Mikey", new DateTime(2021, 1, 12), "C++");
        dev1.ShowInfo();

        Tester tester1 = new Tester("Johnny", new DateTime(2018, 5, 7), true);
        tester1.ShowInfo();

        Developer dev2 = new Developer("Serhii", new DateTime(2019, 12, 25), "Python");
        dev2.ShowInfo();

        Tester tester2 = new Tester("Andrew", new DateTime(2022, 8, 10), false);
        tester2.ShowInfo();

        Developer dev3 = new Developer("Vadim", new DateTime(2015, 11, 21), "Java");
        dev3.ShowInfo();

        Tester tester3 = new Tester("Danylo", new DateTime(2020, 6, 5), true);
        tester3.ShowInfo();
    }
}
