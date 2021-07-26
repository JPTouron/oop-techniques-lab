using ProblemStatements.UseEnumerationAsParamter.Statement.HighLevelModules;
using System;

namespace ProblemStatements.UseEnumerationAsParamter.Statement.LowLevelModules
{
    /*
     * Low level modules here depend on high level modules
     */

    public class CalculatorClient
    {
        private Calculator calculator;

        public CalculatorClient()
        {
            calculator = new Calculator(new FactoryClass());
        }

        public int DoCalculate(int a, int b, AnEnumeration calcType)
        {
            return calculator.Calculate(a, b,calcType);
        }
    }

    public class FactoryClass : IFactoryClass
    {
        public ICalcType Create(AnEnumeration anEnumeration)
        {
            switch (anEnumeration)
            {
                case AnEnumeration.Sum:
                    return new TypeSum();

                case AnEnumeration.Subtract:
                    return new TypeSubtract();

                //case AnEnumeration.Multiply:
                //    return new TypeSubtract();

                default:
                    return null;
            }
        }
    }

    public class TypeSubtract : ICalcType
    {
        public int Calc(int a, int b)
        {
            return a - b;

        }
    }

    public class TypeSum : ICalcType
    {
        public int Calc(int a, int b)
        {
            return a + b;
        }
    }

    //public class TypeMultiply : ICalcType
    //{
    //    public int Calc(int a, int b)
    //    {
    //        return a * b;
    //    }
    //}
}