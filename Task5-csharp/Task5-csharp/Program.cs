using System;
using System.Threading.Tasks;

public class ParallelUtils<T, TR>
{
    private readonly Func<T, T, TR> operation;
    private readonly T operand1;
    private readonly T operand2;

    public TR Result { get; private set; }

    public ParallelUtils(Func<T, T, TR> operation, T operand1, T operand2)
    {
        this.operation = operation;
        this.operand1 = operand1;
        this.operand2 = operand2;
    }

    public void StartEvaluation()
    {
        Task.Run(() => ExecuteOperation());
    }

    public void Evaluate()
    {
        ExecuteOperation().Wait();
    }

    private async Task ExecuteOperation()
    {
        Result = operation(operand1, operand2);
        await Task.CompletedTask;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Func<int, int, int> addFunc = (a, b) => a + b;
        ParallelUtils<int, int> parallelUtils = new ParallelUtils<int, int>(addFunc, 10, 20);
        parallelUtils.StartEvaluation();
        parallelUtils.Evaluate();
        Console.WriteLine($"Result: {parallelUtils.Result}");
    }
}
