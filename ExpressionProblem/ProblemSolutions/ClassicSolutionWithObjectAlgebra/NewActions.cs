using ProblemStatements.ClassicStatement;
using ProblemStatements.ClassicStatement.RedesignForExtensibility;

namespace ProblemSolutions.ClassicSolutionWithObjectAlgebra
{
    /// <summary>
    /// this interface will define a new family of printable objects
    /// that will be created by means of an abstract factory
    /// </summary>
    public interface IPrintExp : IEvalExp
    {
        string Print();
    }

    public class PrintableAdd : Add, IPrintExp
    {
        public PrintableAdd(IPrintExp left, IPrintExp right) : base(left, right)
        {
            Left = left;
            Right = right;
        }

        public new IPrintExp Left { get; }

        public new IPrintExp Right { get; }

        public string Print()
        {
            return Left.Print() + " + " + Right.Print();
        }
    }

    public class PrintableLit : Lit, IPrintExp
    {
        public PrintableLit(int n) : base(n)
        {
            N = n;
        }

        public int N { get; }

        public string Print()
        {
            return N.ToString();
        }
    }

    public class PrintFactory : ExpFactory, ExpAlgebra<IPrintExp>
    {
        public IPrintExp Add(IPrintExp left, IPrintExp right)
        {
            return new PrintableAdd(left, right);
        }

        public new IPrintExp Lit(int n)
        {
            return new PrintableLit(n);
        }
    }

    /// <summary>
    /// this class encapsulates client code two by means of adapter pattern to use the print factory 
    /// to enable the printable family of objects to be instantiated and then execute the printable actions
    /// </summary>
    public class ClientCodeThree
    {
        public int Evaluate(PrintFactory factory) => new ClientCodeTwo<IPrintExp>().AddOneToTwo(factory).Eval();
        public string Print(PrintFactory factory) => new ClientCodeTwo<IPrintExp>().AddOneToTwo(factory).Print();
    }
}