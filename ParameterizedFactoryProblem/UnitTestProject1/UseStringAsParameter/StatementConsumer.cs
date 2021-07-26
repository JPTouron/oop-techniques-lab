using NUnit.Framework;
using ProblemStatements.UseEnumerationAsParamter.Solution.LowLevelModules;

namespace UnitTestProject1.UseStringAsParameter
{
    [TestFixture]
    public class StatementConsumer
    {
        [Test]
        public void Invoke_calculator_divide()
        {
            var f = new CalculatorClient();

            var result = f.DoCalculate(4, 2, AnEnumeration.TypeDivide);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void Invoke_calculator_multiply()
        {
            var f = new CalculatorClient();

            var result = f.DoCalculate(4, 1, AnEnumeration.TypeMultiply);

            Assert.AreEqual(4, result);
        }

        [Test]
        public void Invoke_calculator_subtract()
        {
            var f = new CalculatorClient();

            var result = f.DoCalculate(4, 1, AnEnumeration.TypeSubtract);

            Assert.AreEqual(3, result);
        }

        /// <summary>
        /// to see the problem statement in action, add a new calculating type and you
        /// will be forced to change the consuming code (CalculatorClient) which is expected
        /// BUT you will also have to change the consumed code (AFactoryClass)
        /// which should be isolated from such changes.
        ///
        /// here's why simply put:
        /// AFactoryClass is a higher level construct than CalculatorClient, and since
        /// details depends on abstractions, this AFactoryClass is an abstraction over CalculatorClient
        /// therefore, AFactoryClass should not be affected by the changes in CalculatorClient
        /// </summary>
        [Test]
        public void Invoke_calculator_sum()
        {
            var f = new CalculatorClient();

            var result = f.DoCalculate(4, 1, AnEnumeration.TypeSum);

            Assert.AreEqual(5, result);
        }
    }
}