namespace ProblemSolutions.ObjectAlgebraSolution
{
    public class NewActionPerformerFactory : ActionsFactory, IActionsWrapper<INewActionPerformer>
    {
        INewActionPerformer IActionsWrapper<INewActionPerformer>.CreateSayGoodByePerformer()
        {
            return new NewActionToSayGoodByePerformer();
        }

        INewActionPerformer IActionsWrapper<INewActionPerformer>.CreateSayHelloPerformer()
        {
            return new NewActionToSayHelloPerformer();
        }
    }
}