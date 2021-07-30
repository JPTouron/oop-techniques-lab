using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorsImplementations.ClassicVisitor.RegularExample
{
    /// <summary>
    /// adding a new expression type means adding new stuff here (not so much encapsulation)
    /// changing expressions hierarchy means re-arranging it all here (not so much isolation either)
    /// </summary>
    public interface IExpressionVisitor
    {
        public string Visit(DoubleExpression expression);
        public string Visit(AddExpression expression);
    }


    public class ExpressionVisitor : IExpressionVisitor
    {
        public string Visit(DoubleExpression expression)
        {
            return expression.Value.ToString();
        }

        public string Visit(AddExpression expression)
        {
            return expression.Lhs.Value.ToString() + " + " + expression.Rhs.Value.ToString();
        }
    }
}

