namespace VisitorsImplementations.ClassicVisitor.RegularExample
{
    public class AddExpression : BaseExpression
    {
        private readonly DoubleExpression lhs;
        private readonly DoubleExpression rhs;

        public AddExpression(DoubleExpression lhs, DoubleExpression rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }

        public DoubleExpression Lhs => lhs;

        public DoubleExpression Rhs => rhs;

        public override string Accept(IExpressionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public abstract class BaseExpression
    {
        public abstract string Accept(IExpressionVisitor visitor);
    }

    public class DoubleExpression : BaseExpression
    {
        private double value;

        public DoubleExpression(double value)
        {
            this.value = value;
        }

        public double Value => value;

        public override string Accept(IExpressionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}