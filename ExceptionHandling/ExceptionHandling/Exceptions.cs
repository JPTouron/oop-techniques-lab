using System;
using System.Runtime.Serialization;

namespace ExceptionHandling
{
    public class InvalidCalculation : DivideByZeroException, ISerializable
    {
        private InvalidCalculation(string message, int input, int otherCalculationMember, Exception inner) :
            base(message: message, innerException: inner)
        {
            Input = input;
            OtherCalculationMember = otherCalculationMember;
        }

        public string HumanReadableDetails
        {
            get
            {
                return $"{Message}. The INPUT was: {Input}. The calculation member faulting is: { OtherCalculationMember}";
            }
        }

        public int Input { get; }

        public int OtherCalculationMember { get; }

        public static InvalidCalculation BecauseACalculationMemberWasInvalid(int input, int otherCalculationMember, Exception inner)
        {
            //this could be a much more complicated message, even as complex as HumanReadableDetails
            var message = "this is a demo exception";

            return new InvalidCalculation(message, input, otherCalculationMember, inner);
        }
    }
}