using ProblemStatements.CustomStatement;

namespace ProblemSolutions.CustomSolution
{

    public interface IEmailBuilderSig : IEmailBuilderObjectAlgebra<IEmailBuilderSig, IEmailWithSignature>
    {
        IEmailBuilderSig Signature(string sig);
    }

    public interface IEmailWithSignature : IEmail
    {
        string Signature { get; set; }
    }

    public class EmailWithSignature : Email, IEmailWithSignature
    {
        public string Signature { get; set; }

    }

    public class EmailBuilderSig : EmailBuilder, IEmailBuilderSig
    {

        IEmailWithSignature email = new EmailWithSignature();
        public IEmailBuilderSig Signature(string sig)
        {

            email.Signature = sig;
            return this;
        }


        public new IEmailBuilderSig Body(string body)
        {
            email.Body = body;
            return this;
        }

        public new IEmailBuilderSig Subject(string subject)
        {
            email.Subject = subject;
            return this;
        }

        public new IEmailBuilderSig To(string toEmailAddress)
        {

            email.To = toEmailAddress;
            return this;
        }

        public new IEmailWithSignature Build()
        {
            return email;
        }
    }


}