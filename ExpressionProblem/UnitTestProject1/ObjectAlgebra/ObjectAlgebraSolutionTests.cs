using NUnit.Framework;
using ProblemSolutions.ObjectAlgebraSolution;

namespace UnitTestProject1
{
    /// <summary>
    /// Here we have the same 2 meths as in the problemStatement tests
    /// plus the added method: OperateOnTwoInts; one for each class (hello + goodbye)
    ///
    /// Conclusions for this design:
    /// + can effectively add a method to already compiled code: IActionsPerformer (concretely, SayGoodByeAction and SayHelloAction)
    /// + newly added behavior can be isolated easily in their own classes and file structure
    /// + newly added behavior would be "mounted" or extend the existing class hiearchy from any desired leaf
    /// + 
    ///
    /// - we are FORCED to add actions to all existing implementations of IActionsPerformer
    /// - new class hierarchy is rather convoluted and not so easily followed
    /// </summary>

    [TestFixture]
    public class ObjectAlgebraSolutionTests
    {
        private IActionsWrapper<INewActionPerformer> actionsFactory;
        private INewActionPerformer actionsPerformer;

        [Test]
        public void SayByeGreetTest()
        {
            actionsPerformer = actionsFactory.CreateSayGoodByePerformer();

            var result = actionsPerformer.Greet("juan");

            Assert.AreEqual("bye juan", result);
        }

        [Test]
        public void SayByeOperateOnTwoIntsTest()
        {
            actionsPerformer = actionsFactory.CreateSayGoodByePerformer();

            var result = actionsPerformer.OperateOnTwoInts(3, 2);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void SayByeTest()
        {
            actionsPerformer = actionsFactory.CreateSayGoodByePerformer();

            var result = actionsPerformer.Execute();

            Assert.AreEqual("bye world", result);
        }

        [Test]
        public void SayHelloGreetTest()
        {
            actionsPerformer = actionsFactory.CreateSayHelloPerformer();

            var result = actionsPerformer.Greet("juan");

            Assert.AreEqual("hello juan", result);
        }

        [Test]
        public void SayHelloOperateOnTwoIntsTest()
        {
            actionsPerformer = actionsFactory.CreateSayHelloPerformer();

            var result = actionsPerformer.OperateOnTwoInts(3, 2);

            Assert.AreEqual(5, result);
        }

        [Test]
        public void SayHelloTest()
        {
            actionsPerformer = actionsFactory.CreateSayHelloPerformer();

            var result = actionsPerformer.Execute();

            Assert.AreEqual("hello world", result);
        }

        [SetUp]
        public void Setup()
        {
            actionsFactory = new NewActionPerformerFactory();
        }
    }
}