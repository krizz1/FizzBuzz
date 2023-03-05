using FizzBuzz.Logic.Interfaces;

namespace FizzBuzz.Logic;

public class NumericLogic : INumericLogic
{
    public bool IsMultipleOf(int numberToEvaluate, int multiple) =>
        numberToEvaluate%multiple == 0;

    public int StringToNumber(string input, int defaultValue)
    {
        bool parseResult = int.TryParse(input, out int result);
        if (parseResult)
            return result;

        return defaultValue;
    }
}
