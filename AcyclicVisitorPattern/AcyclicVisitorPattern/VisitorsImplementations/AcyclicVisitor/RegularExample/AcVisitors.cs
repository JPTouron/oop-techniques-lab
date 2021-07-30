namespace VisitorsImplementations.AcyclicVisitor.RegularExample
{
    /// <summary>
    /// the uncle bob's degenerate type (no memebers)
    /// or as it is usually called: a marker interface
    /// using this instead of the IAcVisitor<T> directly enables the decoupling required to add or remove visit methods with no fuss
    /// </summary>
    public interface IAcVisitor
    {
    }

    public interface IAcVisitor<T>
    {
        string Visit(T expression);
    }

    /// <summary>
    /// try adding a new visit case or remove one to verify the pattern's flexibility
    /// </summary>
    public class AcExpressionVisitor : IAcVisitor, IAcVisitor<AcDoubleExpression>, IAcVisitor<AcAddExpression>
    {
        public string Visit(AcDoubleExpression expression)
        {
            return expression.Value.ToString();
        }

        public string Visit(AcAddExpression expression)
        {
            return expression.Lhs.Value.ToString() + " + " + expression.Rhs.Value.ToString();
        }
    }
}