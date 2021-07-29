using NUnit.Framework;
using ProblemSolutions.ClassicSolutionWithObjectAlgebra;
using ProblemStatements.ClassicStatement;
using ProblemStatements.ClassicStatement.RedesignForExtensibility;

namespace UnitTestProject1
{
    [TestFixture]
    public class ClassicObjectAlgebraSolutionTests
    {

        /// <summary>
        /// this test is just the same as <seealso cref="ClassicStatementTests.ExampleOne"
        /// but after the refactoring applies in <seealso cref="ProblemSolutions.ClassicSolutionWithObjectAlgebra.ExpAlgebra{T}"/>
        /// </summary>
        [Test]
        public void ClientCodeTwoTests()
        {
            var factory = new ExpFactory();
            var result = new ClientCodeTwo<IEvalExp>().AddOneToTwo(factory).Eval();

            Assert.AreEqual(3, result);
        }

        /// <summary>
        /// this tests that a new action (print) can be added using the object algebra and without recompiling and based on example two client code
        /// </summary>
        [Test]
        public void ClientCodeThreeTests()
        {
            var factory = new PrintFactory();

            var evalResult = new ClientCodeThree().Evaluate(factory);
            var printResult = new ClientCodeThree().Print(factory);

            Assert.AreEqual(3, evalResult);
            Assert.AreEqual("1 + 2", printResult);
        }


    }
}