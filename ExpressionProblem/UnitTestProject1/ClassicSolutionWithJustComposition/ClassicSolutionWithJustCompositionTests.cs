using NUnit.Framework;
using ProblemSolutions.ClassicSolutionWithJustComposition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.ClassicSolutionWithJustComposition
{
    [TestFixture]
    public class ClassicSolutionWithJustCompositionTests
    {

        /// <summary>
        /// this tests that a new action (print) can be added using the composition technique and without recompiling and based on example two client code
        /// </summary>
        [Test]
        public void ClientCodeCompositeThreeTests(){

            var factory = new CompositeFactory();

            var evalResult = new ClientCodeCompositeThree().Evaluate(factory);
            var printResult = new ClientCodeCompositeThree().Print(factory);


            Assert.AreEqual(3, evalResult);
            Assert.AreEqual("1 + 2", printResult);


        }
    }
}
