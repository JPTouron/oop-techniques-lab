using ProblemStatements.ClassicStatement;
using ProblemStatements.ClassicStatement.RedesignForExtensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolutions.ClassicSolutionWithJustComposition
{
    /*
     * to keep comparison fair between techniques (composition vs object algebra)
     * we'll try and implement a printable feature in the same manner and with same results as the 
     * object algebra solution for the expression problem
     */


    /// <summary>
    /// define the new action keeping the original ones
    /// </summary>
    public interface IPrintComposite : IEvalExp
    {
        string PrintWithComposition();
    }

    public class PrintableLitComposite : IPrintComposite
    {
        private readonly Lit lit;

        public PrintableLitComposite(Lit lit)
        {
            this.lit = lit;
        }
        public int Eval()
        {
            return lit.Eval();
        }

        public string PrintWithComposition()
        {
            return lit.N.ToString();
        }
    }


    /// <summary>
    /// implement the printable add with a composite pattern,  instead of an inheritance technique
    /// to keep the code matching the object algebra one, we need the literals to be passed into this class
    /// thus, having to create the add object within this composite
    /// </summary>
    public class PrintableAddComposite : Add, IPrintComposite
    {
        /*
         * here's the catch with the Object Algebra and WHY it cannot be replaced simply by composition:
         * if we choose not to inherit from Add and instead have an Add object injected in this class (composite)
         * then we are left in the issue that the Add object will not be able to take in the proper IPrintComposite left & right params 
         * instead taking the "old" original IEvalExp left & right params, thus effectively not being able to properly use them
         * within this class in the PrintWithComposition() method
         * This all gets solved, of course, by letting this PrintableAddComposite inherit from Add directly
         */

        //private readonly Add add;

        public PrintableAddComposite( IPrintComposite left, IPrintComposite right) : base(left, right)
        {
            //add = new Add(left, right);
            //this.add = add;
            Left = left;
            Right = right;
        }
        ////public IPrintComposite Left => add.Left;
        ////public IPrintComposite Right { get; private set; }
        public new IPrintComposite Left { get; }
        public new IPrintComposite Right { get; }

        ////public int Eval()
        ////{
        ////    return add.Eval();
        ////}

        public string PrintWithComposition()
        {
            return $"{Left.PrintWithComposition()} + {Right.PrintWithComposition()}";
        }
    }

    public class CompositeFactory : ExpAlgebra<IPrintComposite>
    {
        public IPrintComposite Add(IPrintComposite left, IPrintComposite right)
        {
            return new PrintableAddComposite(left, right);
        }

        public IPrintComposite Lit(int n)
        {
            var lit = new Lit(n);
            return new PrintableLitComposite(lit);
        }
    }

    public class ClientCodeCompositeThree
    {

        public int Evaluate(CompositeFactory factory) => new ClientCodeTwo<IPrintComposite>().AddOneToTwo(factory).Eval();
        public string Print(CompositeFactory factory) => new ClientCodeTwo<IPrintComposite>().AddOneToTwo(factory).PrintWithComposition();

    }
}
