using System;
using VisitorsImplementations.AcyclicVisitor.RegularExample;
using Xunit;

namespace XUnitTestProject1.AcyclicVisitor.RegularExample
{
    public class UnitTest1
    {
        [Fact]
        public void AcyclicVisitorExample()
        {

            var lhs = new AcDoubleExpression(5);
            var rhs = new AcDoubleExpression(1);
            BaseAcExpression add = new AcAddExpression(lhs, rhs);

            IAcVisitor visitor = new AcExpressionVisitor();


            var resultAdd = add.Accept(visitor);
            var resultRhs = rhs.Accept(visitor);
            var resultLhs = lhs.Accept(visitor);

            Assert.Equal(lhs.Value.ToString(), resultLhs);
            Assert.Equal(rhs.Value.ToString(), resultRhs);
            Assert.Equal("5 + 1", resultAdd);

        }

    }
}
