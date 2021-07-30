namespace VisitorsImplementations.AcyclicVisitor.RegularExample
{
    public class AcAddExpression : BaseAcExpression
    {
        private readonly AcDoubleExpression lhs;

        private readonly AcDoubleExpression rhs;

        public AcAddExpression(AcDoubleExpression lhs, AcDoubleExpression rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }

        public AcDoubleExpression Lhs => lhs;

        public AcDoubleExpression Rhs => rhs;

        public override string Accept(IAcVisitor visitor)
        {
            if (visitor is IAcVisitor<AcAddExpression> typed)
                return typed.Visit(this);

            return "nothing to visit!";
        }
    }

    public class AcDoubleExpression : BaseAcExpression
    {
        private double value;

        public AcDoubleExpression(double value)
        {
            this.value = value;
        }

        public double Value => value;

        public override string Accept(IAcVisitor visitor)
        {
            if (visitor is IAcVisitor<AcDoubleExpression> typed)
                return typed.Visit(this);

            return "nothing to visit!";
        }
    }

    public abstract class BaseAcExpression
    {
        /// <summary>
        /// each implementation takes in the marker interface, thus the actual visitor type has to be resolved in run-time
        /// therefore there's a performance downgrade, but it should be minimal for most cases 
        /// and mostly affordable for the flexibility provided by this pattern
        /// </summary>
        public abstract string Accept(IAcVisitor visitor);
    }
}