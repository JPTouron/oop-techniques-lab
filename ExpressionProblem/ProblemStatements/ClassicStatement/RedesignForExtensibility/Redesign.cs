using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStatements.ClassicStatement.RedesignForExtensibility
{
    public interface ExpAlgebra<T>
    {
        T Lit(int n);
        T Add(T left, T right);
    }

    public class ExpFactory : ExpAlgebra<IEvalExp>
    {
        public IEvalExp Lit(int n)
        {
            return new Lit(n);
        }

        public IEvalExp Add(IEvalExp left, IEvalExp right)
        {
            return new Add(left, right);
        }
    }

    public class ClientCodeTwo<T>
    {
        public T AddOneToTwo(ExpAlgebra<T> ae) => ae.Add(ae.Lit(1), ae.Lit(2));
    }
}
