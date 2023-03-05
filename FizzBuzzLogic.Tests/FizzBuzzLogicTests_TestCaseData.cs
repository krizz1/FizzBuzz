namespace FizzBuzz.Logic.Tests
{
    public partial class FizzBuzzLogicTests
    {
        private static IEnumerable<TestCaseData> EvaluateOneTestData()
        {
            yield return new TestCaseData(6, "Fizz").SetName("Fizz").SetCategory("Evaluate One");
            yield return new TestCaseData(10, "Buzz").SetName("Buzz").SetCategory("Evaluate One");
            yield return new TestCaseData(15, "Fizzbuzz").SetName("Fizzbuzz").SetCategory("Evaluate One");
            yield return new TestCaseData(7, "7").SetName("Numeric").SetCategory("Evaluate One");
        }

        private static IEnumerable<TestCaseData> EvaluateManyTestData()
        {
            yield return new TestCaseData(new int[] { 6, 5, 7 }, new string[] { "Fizz", "Buzz", "7" }).SetName("FizzBuzz7").SetCategory("Evaluate Many");
            yield return new TestCaseData(new int[] { 10, 9, 15 }, new string[] { "Buzz", "Fizz", "Fizzbuzz" }).SetName("BuzzFizzFizzbuzz").SetCategory("Evaluate Many");
            yield return new TestCaseData(new int[] { 2, 7, 11 }, new string[] { "2", "7", "11" }).SetName("2711").SetCategory("Evaluate Many");
        }

        private static IEnumerable<TestCaseData> WhollyDivisibleNumberToStringData()
        {
            yield return new TestCaseData(6, 3, "Fizz", new KeyValuePair<bool, string>(true, "Fizz")).SetName("6 3 - Fizz").SetCategory("Private - Wholly Divisible Number To StringData");
            yield return new TestCaseData(10, 5, "Buzz", new KeyValuePair<bool, string>(true, "Buzz")).SetName("10 5 - Buzz").SetCategory("Private - Wholly Divisible Number To StringData");
            yield return new TestCaseData(7, 5, "Buzz", new KeyValuePair<bool, string>(false, "")).SetName("7 5 - 7").SetCategory("Private - Wholly Divisible Number To StringData");
        }

        private static IEnumerable<TestCaseData> FizzBuzzOutputData()
        {
            yield return new TestCaseData("fizz", "buzz", "Fizzbuzz").SetName("fizz buzz - Fizzbuzz").SetCategory("Private - FizzBuzzOutput");
            yield return new TestCaseData("hello", "world", "Helloworld").SetName("hello world - Helloworld").SetCategory("Private - FizzBuzzOutput");
            yield return new TestCaseData("TEST", "CASE", "Testcase").SetName("TEST CASE - Testcase").SetCategory("Private - FizzBuzzOutput");
        }
    }
}
