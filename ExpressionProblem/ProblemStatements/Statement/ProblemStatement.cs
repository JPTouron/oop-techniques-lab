namespace ProblemStatements.Statement
{
    /*
     * Problem is that adding an action to the concrete types implies changing the iface
     * which in turn implies changing all the subtypes
     * this is an inherent problem to OOP:
     *  - adding a type without changing existing actions is easy
     *  - adding an action without changing existing types is difficult
     */
    public interface IActionsPerformer
    {
        string Execute();
    }

    public class SayGoodByeAction : IActionsPerformer
    {
        public string Execute()
        {
            return "bye world";
        }
    }

    public class SayHelloAction : IActionsPerformer
    {
        public string Execute()
        {
            return "hello world";
        }
    }
}