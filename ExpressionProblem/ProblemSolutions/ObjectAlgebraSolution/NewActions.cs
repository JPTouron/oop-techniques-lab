using ProblemStatements.Statement;

namespace ProblemSolutions.ObjectAlgebraSolution
{
    /// <summary>
    /// this is how we add a new action to an already existing class (the goodbye / hello performers)
    /// </summary>
    public interface INewActionPerformer : IActionsPerformer
    {
        string Greet(string name);

        int OperateOnTwoInts(int a, int b);
    }

    public class NewActionToSayGoodByePerformer : SayGoodByeAction, INewActionPerformer
    {
        public string Greet(string name)
        {
            return "bye " + name;
        }

        public int OperateOnTwoInts(int a, int b)
        {
            return a - b;
        }
    }

    public class NewActionToSayHelloPerformer : SayHelloAction, INewActionPerformer
    {
        public string Greet(string name)
        {
            return "hello " + name;
        }

        public int OperateOnTwoInts(int a, int b)
        {
            return a + b;
        }
    }
}