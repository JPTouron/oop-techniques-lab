using System;
using VisitorsImplementations.ClassicVisitor.RegularExample;
using Xunit;

namespace XUnitTestProject1.ClassicVisitor.RegularExample
{
    public class UnitTest1
    {

        [Fact]
        public void RegularVisitorExample()
        {

            var lhs = new DoubleExpression(5);
            var rhs = new DoubleExpression(1);
            BaseExpression add = new AddExpression(lhs, rhs);

            IExpressionVisitor visitor = new ExpressionVisitor();


            var resultAdd = add.Accept(visitor);
            var resultRhs = rhs.Accept(visitor);
            var resultLhs = lhs.Accept(visitor);

            Assert.Equal(lhs.Value.ToString(), resultLhs);
            Assert.Equal(rhs.Value.ToString(), resultRhs);
            Assert.Equal("5 + 1", resultAdd);

        }
    }
}
