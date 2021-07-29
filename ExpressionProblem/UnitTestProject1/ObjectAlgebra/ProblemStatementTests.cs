using NUnit.Framework;
using ProblemStatements.Statement;

namespace UnitTestProject1
{
    [TestFixture]
    public class ProblemStatementTests
    {
        private IActionsPerformer act;

        [Test]
        public void SayByeTest()
        {
            act = new SayGoodByeAction();

            Assert.AreEqual("bye world", act.Execute());
        }

        [Test]
        public void SayHelloTest()
        {
            act = new SayHelloAction();

            Assert.AreEqual("hello world", act.Execute());
        }
    }
}