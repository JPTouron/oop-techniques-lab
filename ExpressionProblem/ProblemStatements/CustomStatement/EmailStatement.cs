namespace ProblemStatements.CustomStatement
{
    public interface IEmail
    {
        string Body { get; set; }

        string Subject { get; set; }

        string To { get; set; }
    }

    /// <summary>
    /// the object algebra at play, this interface defines an abstract factory, 
    /// which in turn enables that methods may be added to an existing type (EmailBuilderT) simply by changing the concrete type it operates on
    /// effectively adding the new method in a new type (derivative of EmailBuilderT) that should extend from EmailBuilderT's concrete type
    /// </summary>
    public interface IEmailBuilderObjectAlgebra<EmailBuilderT, EmailT>
    {
        EmailBuilderT Body(string body);

        EmailT Build();

        EmailBuilderT Subject(string subject);

        EmailBuilderT To(string toEmailAddress);
    }

    public class Email : IEmail
    {
        public string Body { get; set; }

        public string Subject { get; set; }

        public string To { get; set; }
    }


    public interface IEmailBuilder
    {
        IEmailBuilder Body(string body);

        IEmail Build();

        IEmailBuilder Subject(string subject);

        IEmailBuilder To(string toEmailAddress);
    }

    public class EmailBuilder : IEmailBuilderObjectAlgebra<IEmailBuilder, IEmail>, IEmailBuilder
    {
        private IEmail email = new Email();

        public IEmailBuilder Body(string body)
        {
            email.Body = body; return this;
        }

        public IEmail Build()
        {
            return email;
        }

        public IEmailBuilder Subject(string subject)
        {
            email.Subject = subject; return this;
        }

        public IEmailBuilder To(string toEmailAddress)
        {
            email.To = toEmailAddress; return this;
        }
    }
}