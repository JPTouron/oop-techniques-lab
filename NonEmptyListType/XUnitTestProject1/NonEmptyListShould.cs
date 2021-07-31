using NonEmptyListDefinition;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    public class NonEmptyListShould
    {
        [Fact]
        public void BeDefinedForAnyType()
        {
            var listA = new NonEmptyList<int>(new List<int> { 6 });
            var listB = new NonEmptyList<string>(new List<string> { "6" });
            var listC = new NonEmptyList<double>(new List<double> { 6.00005677d });
            var listD = new NonEmptyList<object>(new List<object> { new object() });
            var listE = new NonEmptyList<NonEmptyListShould>(new List<NonEmptyListShould> { new NonEmptyListShould() });

            Assert.NotNull(listA);
            Assert.NotNull(listB);
            Assert.NotNull(listC);
            Assert.NotNull(listD);
            Assert.NotNull(listE);

            Assert.NotEmpty(listA.Value);
            Assert.NotEmpty(listB.Value);
            Assert.NotEmpty(listC.Value);
            Assert.NotEmpty(listD.Value);
            Assert.NotEmpty(listE.Value);
        }

        [Fact]
        public void NotBeInitializedWithAnEmptyList()
        {
            var emptyList = new List<int>();

            var exceptionThrown = Assert.Throws<ArgumentException>("list", () => new NonEmptyList<int>(emptyList));

            Assert.Equal("The parameter list cannot be an empty list (Parameter 'list')", exceptionThrown.Message);
        }

        [Fact]
        public void ReturnACopyOfTheInputInsteadOfAReferenceOfTheInputAsTheValue()
        {
            var nonEmptyList = new List<int> { 5, 6, 7, 8 };

            var el = new NonEmptyList<int>(nonEmptyList);

            Assert.NotStrictEqual(nonEmptyList, el.Value);
            Assert.True(nonEmptyList.GetHashCode() != el.Value.GetHashCode());
        }

        [Fact]
        public void ReturnTheInputListValues()
        {
            var nonEmptyList = new List<int> { 5, 6, 7, 8 };

            var el = new NonEmptyList<int>(nonEmptyList);

            foreach (var item in el.Value)
            {
                Assert.Contains(item, nonEmptyList);
            }
        }
    }
}