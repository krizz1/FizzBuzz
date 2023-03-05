using FizzBuzz.Logic;
using FizzBuzz.Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    private readonly IFizzBuzzLogic _fizzBuzzLogic;
    private readonly INumericLogic _numericLogic;

    public Program(IFizzBuzzLogic fizzBuzzLogic, INumericLogic numericLogic)
    {
        _numericLogic = numericLogic;
        _fizzBuzzLogic = fizzBuzzLogic;
    }

    public string[] Invoke(string startNumber, string endNumber)
    {
        var numericStartNumber = _numericLogic.StringToNumber(startNumber, 1);
        var numericEndNumber = _numericLogic.StringToNumber(endNumber, 100);

        int[] rangeToEvaluate = GenerateSequence(numericStartNumber, numericEndNumber);

        return _fizzBuzzLogic.Evaluate(rangeToEvaluate);
    }

    public static void Main(string[] args) {
        string startNumber = GetInput("Enter the first number in the sequence to evaluate (default 1)", "1");
        string endNumber = GetInput("Enter the last (inclusive number in the sequence to evaluate (default 100)", "100");

        var serviceProvider = new ServiceCollection()
           .AddSingleton<IFizzBuzzLogic, FizzBuzzLogic>()
           .AddSingleton<INumericLogic, NumericLogic>()
           .BuildServiceProvider();

        var program = new Program(serviceProvider.GetRequiredService<IFizzBuzzLogic>(),serviceProvider.GetRequiredService<INumericLogic>());

        var evaluationResult = program.Invoke(startNumber, endNumber);

        OutputResults(evaluationResult);
    }

    private static string GetInput(string messge, string defaultValue)
    {
        Console.WriteLine($"{messge}:");
        return Console.ReadLine() ?? defaultValue;
    }

    private static int[] GenerateSequence(int startNumber, int endNumber)
    {
        bool isInvertedSequence = startNumber > endNumber;
        int[] result = isInvertedSequence ? new int[(startNumber - endNumber) + 1] : new int[(endNumber - startNumber) + 1];

        if (isInvertedSequence)
        {
            for (int i = result.Length-1; i >= 0; i--)
                result[i] = startNumber - i;
        }
        else
        {
            for (int i = 0; i < result.Length; i++)
                result[i] = startNumber + i;

        }

        return result;
    }

    private static void OutputResults(string[] evaluationResult)
    {
        Console.WriteLine("Results:");
        for (int i = 0; i < evaluationResult.Length; i++)
            Console.WriteLine(evaluationResult[i]);
    }
}




    
