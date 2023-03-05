using FizzBuzz.Logic.Interfaces;
using System.Reflection;

namespace FizzBuzz.Logic.Tests
{
    public partial class FizzBuzzLogicTests
    {
        private IFizzBuzzLogic _fizzBuzzLogic;

        [SetUp]
        public void Setup()
        {
            _fizzBuzzLogic = new FizzBuzzLogic(new NumericLogic());
        }

        

        [Test, TestCaseSource(nameof(EvaluateOneTestData))]
        public void EvaluateOne(int number, string expectedResult)
        {
            string result = _fizzBuzzLogic.Evaluate(number);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test, TestCaseSource(nameof(EvaluateManyTestData))]
        public void EvaluateMany(int[] numbers, string[] expectedResult)
        {
            string[] result = _fizzBuzzLogic.Evaluate(numbers);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test, TestCaseSource(nameof(WhollyDivisibleNumberToStringData))]
        public void PrivateWhollyDivisibleNumberToString(int number, int multipleOf, string successOutput, KeyValuePair<bool, string> expectedResult)
        {
            var res = CallPrivateMethod<IFizzBuzzLogic, KeyValuePair<bool, string>>(_fizzBuzzLogic, "WhollyDivisibleNumberToString", new object[] { number, multipleOf, successOutput });
            Assert.That(res.Key, Is.EqualTo(expectedResult.Key));
            Assert.That(res.Value, Is.EqualTo(expectedResult.Value));
        }

        [Test, TestCaseSource(nameof(FizzBuzzOutputData))]
        public void Private_FizzBuzzOutput(string fizz, string buzz, string expectedResult)
        {
            var res = CallPrivateMethod<IFizzBuzzLogic, string>(_fizzBuzzLogic, "FizzBuzzOutput", new object[] { fizz, buzz });
            Assert.That(res, Is.EqualTo(expectedResult));
        }

        // Ideally we wouldn't want to do this as if the code is clean then any internal functions would be tested by public function tests
        private static TReturn CallPrivateMethod<TInstance, TReturn>(TInstance instance, string methodName, object[] parameters)
        {
            if (instance == null)
                throw new Exception("Unable to create an instace of the class");

            Type type = instance.GetType();
            BindingFlags bindingAttr = BindingFlags.NonPublic | BindingFlags.Instance;
            MethodInfo method = type.GetMethod(methodName, bindingAttr);

            if (method == null)
                throw new Exception($"Unable to get private method named {methodName}");

            return (TReturn)method.Invoke(instance, parameters);
        }
    }
}