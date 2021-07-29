using ProblemStatements.Statement;

namespace ProblemSolutions.CompositionSolution
{
    /// <summary>
    /// this is how we define a new action
    /// </summary>
    public interface IGreetAction : IActionsPerformer
    {
        string Greet(string userName);
    }

    /// <summary>
    /// this is how we define a new action
    /// </summary>
    public interface IGreetHelloAction : IActionsPerformer
    {
        string GreetHello(string namey);
    }

    /// <summary>
    /// we use composition to take in the already-compiled code and extend it with new actions
    /// also we expose the already-compiled method by means of delegation
    /// </summary>
    public class GreetAction : IGreetAction, IGreetHelloAction
    {
        private readonly IActionsPerformer compiledAction;

        public GreetAction(IActionsPerformer compiledAction)
        {
            this.compiledAction = compiledAction;
        }

        public string Execute()
        {
            return compiledAction.Execute();
        }

        public string Greet(string userName)
        {
            return "greetings " + userName;
        }

        public string GreetHello(string namey)
        {
            return "hello " + namey;
        }
    }
}