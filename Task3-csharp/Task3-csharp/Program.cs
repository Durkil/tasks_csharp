using System;

public delegate double CalcDelegate(double num1, double num2, char operation);

public class CalcProgram
{
    public static double Calc(double num1, double num2, char operation)
    {
        switch (operation)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':
                if (num2 != 0)
                {
                    return num1 / num2;
                }
                else
                {
                    return 0;
                }
            default:
                Console.WriteLine("Error: Invalid operation.");
                return 0;
        }
    }
    public CalcDelegate funcCalc = new CalcDelegate(Calc);
}

class Program
{
    static void Main(string[] args)
    {
        CalcProgram calcProgram = new CalcProgram();

        double result1 = calcProgram.funcCalc(7, 3, '+');
        double result2 = calcProgram.funcCalc(110, 4, '-');
        double result3 = calcProgram.funcCalc(6, 5, '*');
        double result4 = calcProgram.funcCalc(18, 0, '/');

        Console.WriteLine($"7 + 3 = {result1}");
        Console.WriteLine($"110 - 4 = {result2}");
        Console.WriteLine($"6 * 5 = {result3}");
        Console.WriteLine($"18 / 0 = {result4}");
    }
}
