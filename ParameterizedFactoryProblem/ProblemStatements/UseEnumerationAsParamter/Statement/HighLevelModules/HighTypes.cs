namespace ProblemStatements.UseEnumerationAsParamter.Statement.HighLevelModules
{
    /*
     * High level modules here do not depend on low level modules
     */


    public interface ICalcType
    {
        int Calc(int a, int b);
    }

    public interface IFactoryClass
    {
        ICalcType Create(AnEnumeration anEnumeration);
    }

    /// <summary>
    /// enumeration has to be part of the high level module as it is required by
    /// the ifactoryclass, therein lies the problem
    /// </summary>
    public enum AnEnumeration
    {
        Sum,
        Subtract
        //, Multiply
    }

    public class Calculator
    {
        private IFactoryClass factory;

        public Calculator(IFactoryClass factory)
        {
            this.factory = factory;
        }

        public int Calculate(int a, int b, AnEnumeration calcType)
        {

            var calculatorType = factory.Create(calcType);

            var result = calculatorType.Calc(a, b);

            return result;
        }
    }
}