using System.Collections.Generic;

namespace ProblemStatements.UseEnumerationAsParamter.Solution.HighLevelModules
{
    /*
     * High level modules here do not depend on low level modules
     */

    public interface IAnEnumeration
    {
        IEnumerable<string> PossibleValues();
    }

    public interface ICalcType
    {
        int Calc(int a, int b);
    }
    /// <summary>
    /// as the requestedCalcType is not an enumeration now it is not required that the 
    /// High level modules have any knowledge of any structure pertaining WHAT the factory should create
    /// other than the .net framework's string
    /// </summary>
    public interface IFactoryClass
    {
        ICalcType Create(string requestedCalcType);
    }

    public class Calculator
    {
        private IFactoryClass factory;

        public Calculator(IFactoryClass factory)
        {
            this.factory = factory;
        }

        public int Calculate(int a, int b, string calcType)
        {
            var calculatorType = factory.Create(calcType);

            var result = calculatorType.Calc(a, b);

            return result;
        }
    }
}