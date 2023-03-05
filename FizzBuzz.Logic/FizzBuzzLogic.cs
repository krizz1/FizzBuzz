using FizzBuzz.Logic.Interfaces;
using System.Globalization;

namespace FizzBuzz.Logic;

public class FizzBuzzLogic : IFizzBuzzLogic
{
    private readonly INumericLogic _numericLogic;
    public FizzBuzzLogic(INumericLogic numericLogic)
    {
        _numericLogic = numericLogic;
    }
    public string Evaluate(int number)
    {
        var fizzEvaluation = WhollyDivisibleNumberToString(number, 3, "fizz");
        var buzzEvaluation = WhollyDivisibleNumberToString(number, 5, "buzz");

        if (!fizzEvaluation.Key && !buzzEvaluation.Key)
            return number.ToString();

        return FizzBuzzOutput(fizzEvaluation.Value, buzzEvaluation.Value);
    }

    public string[] Evaluate(int[] numbers)
    {
        string[] result = new string[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
            result[i] = Evaluate(numbers[i]);

        return result;
    }

    #region Internal Methods

    private KeyValuePair<bool, string> WhollyDivisibleNumberToString(int number, int multipleOf, string successOutput) =>
        _numericLogic.IsMultipleOf(number, multipleOf) ? EvaluationResult(true, successOutput) : EvaluationResult();

    private static KeyValuePair<bool, string> EvaluationResult(bool key = false, string value = "") =>
        new (key, value);

    private string FizzBuzzOutput(string fizz, string buzz)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        return textInfo.ToTitleCase($"{fizz.ToLower()}{buzz.ToLower()}");
    }

    #endregion
}
