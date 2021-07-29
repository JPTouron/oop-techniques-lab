using NUnit.Framework;
using ProblemStatements.ClassicStatement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{

    /*
       public static class ExampleOne
    {

    }

     */
    [TestFixture]
    public class ClassicStatementTests
    {
        [Test]
        public void ExampleOne() {

            IEvalExp AddOneAndTwo() => new Add(new Lit(1), new Lit(2));

            int EvaluateTheSumOfOneAndTwo() => AddOneAndTwo().Eval();

            Assert.AreEqual(3,EvaluateTheSumOfOneAndTwo() );
        }
    }
}
