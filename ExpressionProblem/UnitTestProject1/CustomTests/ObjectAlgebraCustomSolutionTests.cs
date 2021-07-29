using NUnit.Framework;
using ProblemSolutions.CustomSolution;
using ProblemStatements.CustomStatement;

namespace UnitTestProject1.CustomTests
{
    [TestFixture]
    public class ObjectAlgebraCustomSolutionTests
    {

        /// <summary>
        /// this tests how the email builder works normally, by invoking the concrete type (EmailBuilder) through it's implementing interface: IEmailBuilderObjectAlgebra<T,R>
        /// </summary>
        [Test]
        public void DirectUsageOfRegularEmailBuilder_Test()
        {
            IEmailBuilderObjectAlgebra<IEmailBuilder, IEmail> builder = new EmailBuilder();

            var body = "body";
            var subject = "subject";
            var to = "to";

            builder.Body(body);
            builder.Subject(subject);
            builder.To(to);

            var email = builder.Build();

            Assert.AreEqual(body, email.Body);
            Assert.AreEqual(subject, email.Subject);
            Assert.AreEqual(to, email.To);
        }

        /// <summary>
        /// this tests out the extended email builder which includes a signature
        /// <seealso cref="IEmailBuilderSig"/> is an interface that extends the <seealso cref="IEmailBuilderObjectAlgebra{EmailBuilderT, EmailT}"/>
        /// one which has to be programmed within the ProblemStatements dll
        /// This means that in order to apply this pattern you HAVE TO have the actions  that may be extended within an Object Algebra interface: IObjectAlgebra<T>
        /// Here we demonstrate how we make use of such Object Algebra interface to invoke the new extended method Signature
        /// </summary>
        [Test]
        public void UsageOfEmailWithSignatureBuilder_ThroughObjectAlgebraFactory_Test()
        {
            IEmailBuilderSig builder = new EmailBuilderSig();

            var body = "body";
            var subject = "subject";
            var to = "to";
            var signature = "best regards, the signature";

            builder.Body(body);
            builder.Subject(subject);
            builder.To(to);
            builder.Signature(signature);

            var email = builder.Build();

            Assert.AreEqual(body, email.Body);
            Assert.AreEqual(subject, email.Subject);
            Assert.AreEqual(to, email.To);
            Assert.AreEqual(signature, email.Signature);
        }
    }
}