using NUnit.Framework;
using ProblemSolutions.CompositionSolution;
using ProblemSolutions.ObjectAlgebraSolution;
using ProblemStatements.Statement;

namespace UnitTestProject1
{
    /// <summary>
    /// Here we have the same 2 meths as in the problemStatement tests
    /// plus the added method: OperateOnTwoInts; one for each class (hello + goodbye)
    ///
    /// Conclusions for this design:
    /// + Easily extend existing code without re-compiling
    /// + no need to be forced to implement multiple actions when only one has to be extended
    /// + favor composition over inheritance
    /// + simpler implementation than object algebra
    /// 
    /// - actions that do not need modification have to be re-implemented by calling the composing action
    /// </summary>

    [TestFixture]
    public class CompositionSolutionTests
    {

        IActionsPerformer originalHelloAction;
        IGreetAction greetAction;
        IGreetHelloAction greetHelloAction;

        [Test]
        public void GreetTest()
        {

            var result = greetAction.Greet("juan");

            Assert.AreEqual("greetings juan", result);
        }


        [Test]
        public void GreetHelloTest()
        {

            var result = greetHelloAction.GreetHello("pepe");

            Assert.AreEqual("hello pepe", result);
        }


        [Test]
        public void ExecuteActionTest()
        {

            var result = greetHelloAction.Execute();
            var result2 = greetAction.Execute();

            Assert.AreEqual("hello world", result);
            Assert.AreEqual("hello world", result2);
        }



        [SetUp]
        public void Setup()
        {
            originalHelloAction = new SayHelloAction();
            greetAction = new GreetAction(originalHelloAction);
            greetHelloAction = new GreetAction(originalHelloAction);
        }
    }
}