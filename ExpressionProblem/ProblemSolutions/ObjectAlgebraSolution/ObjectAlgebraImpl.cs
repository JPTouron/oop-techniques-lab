using ProblemStatements.Statement;

namespace ProblemSolutions.ObjectAlgebraSolution
{
    /*
     * Pick the types from the statement folder and "extend" / redesign them like this:
     * (this should demonstrate non-recompiling necessities to add behavior, complying with Open closed principle)
     */

    /// <summary>
    /// wrap the individual interfaces actions in another iface that returns the same homogeneus ifaces
    /// for the action execution
    /// the T parameter is not really necessary but we use it here
    /// </summary>
    public interface IActionsWrapper<T>
    {
        T CreateSayGoodByePerformer();

        T CreateSayHelloPerformer();
    }

    /// <summary>
    /// create the factory to get the concrete executors of the actions
    /// </summary>
    public class ActionsFactory : IActionsWrapper<IActionsPerformer>
    {
        public IActionsPerformer CreateSayGoodByePerformer()
        {
            return new SayGoodByeAction();
        }

        public IActionsPerformer CreateSayHelloPerformer()
        {
            return new SayHelloAction();
        }
    }
}