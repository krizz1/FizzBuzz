using FizzBuzz.Logic.Interfaces;

namespace FizzBuzz.Logic.Tests
{
    public class NumericLogicTests
    {
        private INumericLogic _numericLogic;

        [SetUp]
        public void Setup()
        {
            _numericLogic = new NumericLogic();
        }

        private static IEnumerable<TestCaseData> IsMultipleOfTestData()
        {
            yield return new TestCaseData(6, 3, true).SetName("Successful Multiple of 3").SetCategory("Is Multiple Of");
            yield return new TestCaseData(7, 3, false).SetName("Unsuccessful Multiple of 3").SetCategory("Is Multiple Of"); ;
            yield return new TestCaseData(20, 5, true).SetName("Successful Multiple of 5").SetCategory("Is Multiple Of"); ;
            yield return new TestCaseData(21, 5, false).SetName("Unsuccessful Multiple of 5").SetCategory("Is Multiple Of"); ;
            yield return new TestCaseData(0, 5, true).SetName("Evaluate zero");
        }

        [Test, TestCaseSource(nameof(IsMultipleOfTestData))]
        public void IsMultipleOf(int number, int multipleOf, bool expectedResult)
        {
            bool result = _numericLogic.IsMultipleOf(number, multipleOf);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}