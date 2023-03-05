namespace FizzBuzz.Logic.Interfaces;

public interface INumericLogic
{
    bool IsMultipleOf(int numberToEvaluate, int multiple);
    int StringToNumber(string input, int defaultValue);
}
