using NUnit.Framework;
using ProblemStatements.UseEnumerationAsParamter.Statement.HighLevelModules;
using ProblemStatements.UseEnumerationAsParamter.Statement.LowLevelModules;

namespace UnitTestProject1.UseEnumerationAsParamter
{
    [TestFixture]
    public class StatementConsumer
    {
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

            var result = f.DoCalculate(4, 1, AnEnumeration.Sum);

            Assert.AreEqual(5, result);
        }
        [Test]
        public void Invoke_calculator_subtract()
        {
            var f = new CalculatorClient();

            var result = f.DoCalculate(4, 1, AnEnumeration.Subtract);

            Assert.AreEqual(3, result);
        }

        //[Test]
        //public void Invoke_calculator_multiply()
        //{
        //    var f = new CalculatorClient();

        //    var result = f.DoCalculate(4, 1, AnEnumeration.Multiply);

        //    Assert.AreEqual(4, result);
        //}
    }
}