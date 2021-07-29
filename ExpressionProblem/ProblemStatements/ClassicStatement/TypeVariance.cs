using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStatements.ClassicStatement
{
    /// <summary>
    /// adds a new datatype just because we can and to demo capability of OOP
    /// </summary>
    public class Mult : IEvalExp
    {
        public Mult(IEvalExp left, IEvalExp right)
        {
            Left = left;
            Right = right;
        }

        public IEvalExp Left { get; }

        public IEvalExp Right { get; }

        public int Eval()
        {
            return Left.Eval() * Right.Eval();
        }
    }
}
