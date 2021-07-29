namespace ProblemStatements.ClassicStatement
{
    public interface IEvalExp
    {
        int Eval();
    }


    public class Add : IEvalExp
    {
        public Add(IEvalExp left, IEvalExp right)
        {
            Left = left;
            Right = right;
        }

        public IEvalExp Left { get; }

        public IEvalExp Right { get; }

        public int Eval()
        {
            return Left.Eval() + Right.Eval();
        }
    }

    public class Lit : IEvalExp
    {
        public Lit(int n)
        {
            N = n;
        }

        public int N { get; }

        public int Eval()
        {
            return N;
        }
    }


    public class ClientCodeOne
    {
        public IEvalExp AddOneAndTwo() => new Add(new Lit(1), new Lit(2));
        public int EvaluateTheSumOfOneAndTwo() => AddOneAndTwo().Eval();
    }
}