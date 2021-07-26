
using ProblemStatements.UseEnumerationAsParamter.Solution.HighLevelModules;
using System.Collections;
using System.Collections.Generic;

namespace ProblemStatements.UseEnumerationAsParamter.Solution.LowLevelModules
{
    /*
     * Low level modules here depend on high level modules
     */

    public class CalculatorClient
    {
        private Calculator calculator;

        public CalculatorClient()
        {
            calculator = new Calculator(new FactoryClass(new AnEnumeration()));
        }

        public int DoCalculate(int a, int b, string calcType)
        {
            return calculator.Calculate(a, b, calcType);
        }
    }

    public class AnEnumeration : IAnEnumeration
    {

        public const string TypeSubtract = "subtract";
        public const string TypeSum= "sum";
        public const string TypeMultiply = "multiply";
        public const string TypeDivide = "divide";
        public IEnumerable<string> PossibleValues()
        {
            yield return TypeSubtract;
            yield return TypeSum;
            yield return TypeMultiply;
            yield return TypeDivide;
        }
    }

    public class FactoryClass : IFactoryClass
    {
        private readonly IReadOnlyDictionary<string, ICalcType> calcTypesMap;

        public FactoryClass(IAnEnumeration anEnumeration)
        {
            var possibleValues = anEnumeration.PossibleValues();

            var dict= new Dictionary<string, ICalcType>();

            foreach (var value in possibleValues)
            {
                if (value == "subtract")
                    dict.Add(value, new TypeSubtract());
                if (value == "sum")
                    dict.Add(value, new TypeSum());
                if (value == "multiply")
                    dict.Add(value, new TypeMultiply());
                if (value == "divide")
                    dict.Add(value, new TypeDivide());
            }

            calcTypesMap = dict;


        }
        

        public ICalcType Create(string requestedCalcType)
        {
            return calcTypesMap[requestedCalcType];
        }
    }

    internal class TypeDivide : ICalcType
    {
        public int Calc(int a, int b)
        {
            if (b == 0)
                return 0;

            return a / b;

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

    public class TypeMultiply : ICalcType
    {

        public int Calc(int a, int b)
        {
            return a * b;
        }
    }
}