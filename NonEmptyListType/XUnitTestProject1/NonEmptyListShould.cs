using AutoFixture;
using NonEmptyListDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class NonEmptyCollectionShould
    {
        [Fact]
        public void BeCreatedForAnyType()
        {
            var listA = new NonEmptyCollection<int>(new List<int> { 6 });
            var listB = new NonEmptyCollection<string>(new List<string> { "6" });
            var listC = new NonEmptyCollection<double>(new List<double> { 6.00005677d });
            var listD = new NonEmptyCollection<object>(new List<object> { new object() });
            var listE = new NonEmptyCollection<NonEmptyCollectionShould>(new List<NonEmptyCollectionShould> { new NonEmptyCollectionShould() });

            Assert.NotNull(listA);
            Assert.NotNull(listB);
            Assert.NotNull(listC);
            Assert.NotNull(listD);
            Assert.NotNull(listE);

            Assert.NotEmpty(listA);
            Assert.NotEmpty(listB);
            Assert.NotEmpty(listC);
            Assert.NotEmpty(listD);
            Assert.NotEmpty(listE);

            Assert.NotEmpty(listA.Value);
            Assert.NotEmpty(listB.Value);
            Assert.NotEmpty(listC.Value);
            Assert.NotEmpty(listD.Value);
            Assert.NotEmpty(listE.Value);
        }

        [Fact]
        public void BeCreatedFromANonEmptyList()
        {
            var nonEmptyList = CreateNonEmptyListOfRandomIntegers();
            var nonEmptyCollection = new NonEmptyCollection<int>(nonEmptyList);

            Assert.NotNull(nonEmptyCollection);
        }

        [Fact]
        public void BeCreatedFromDiscreteElements()
        {
            var nonEmptyCollection = new NonEmptyCollection<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20);
            var randomValueInCollection = new Random().Next(1, 21);

            Assert.NotNull(nonEmptyCollection);
            Assert.Equal(20, nonEmptyCollection.Count);
            Assert.Contains(randomValueInCollection, nonEmptyCollection);
        }

        [Fact]
        public void BeCreatedWithJustASingleDiscreteElement()
        {
            var singleItem = 7;
            var nonEmptyCollection = new NonEmptyCollection<int>(singleItem);

            Assert.NotNull(nonEmptyCollection);
            Assert.Contains(singleItem, nonEmptyCollection);
        }

        [Fact]
        public void BeCreatedWithJustASingleDiscreteElementAndTheRestAsNull()
        {
            var singleItem = 7;
            var nonEmptyCollection = new NonEmptyCollection<int>(singleItem, null);

            Assert.NotNull(nonEmptyCollection);
            Assert.Contains(singleItem, nonEmptyCollection);
        }

        [Fact]
        public void BeExplicitlyConvertibleToAList()
        {
            var nonEmptyList = CreateNonEmptyListOfRandomIntegers();

            var nonEmptyCollection = (NonEmptyCollection<int>)nonEmptyList.ToList();

            foreach (var item in nonEmptyCollection)
            {
                Assert.Contains(item, nonEmptyList);
            }
        }

        [Fact]
        public void BeIterabable()
        {
            var nonEmptyList = CreateNonEmptyListOfRandomIntegers();

            var nonEmptyCollection = new NonEmptyCollection<int>(nonEmptyList);

            foreach (var item in nonEmptyCollection)
            {
                Assert.Contains(item, nonEmptyList);
            }
        }

        [Fact]
        public void ConvertAListImplicitlyToANonEmptyCollection()
        {
            var nonEmptyList = CreateNonEmptyListOfRandomIntegers();

            var nonEmptyCollection = new NonEmptyCollection<int>(nonEmptyList);

            List<int> newList = nonEmptyCollection;

            foreach (var item in nonEmptyCollection)
            {
                Assert.Contains(item, newList);
            }
        }

        [Fact]
        public void NotBeCreatedIfAFirstElementIsNotProvidedWithDiscreteElements()
        {
            int? singleItem = null;
            Assert.Throws<ArgumentNullException>("firstItem", () => new NonEmptyCollection<int?>(singleItem));
        }

        [Fact]
        public void NotBeInitializedWithAnEmptyList()
        {
            var emptyList = new List<int>();

            var exceptionThrown = Assert.Throws<ArgumentException>("list", () => new NonEmptyCollection<int>(emptyList));

            Assert.Equal("The parameter list cannot be an empty list (Parameter 'list')", exceptionThrown.Message);
        }

        [Fact]
        public void NotChangeItsValueIfAnOutsideReferenceIsChanged()
        {
            var nonEmptyList = CreateNonEmptyListOfRandomIntegers();

            var randomIndexToRemove = new Random().Next(0, nonEmptyList.Count - 1);

            var nonEmptyCollection = new NonEmptyCollection<int>(nonEmptyList);

            var removedValue = nonEmptyList[randomIndexToRemove];
            nonEmptyList.RemoveAt(randomIndexToRemove);

            Assert.True(nonEmptyList.Count < nonEmptyCollection.Count);
            Assert.DoesNotContain(removedValue, nonEmptyList);
        }

        [Fact]
        public void ReturnACopyOfTheInputInsteadOfAReferenceOfTheInputAsTheValue()
        {
            var nonEmptyList = CreateNonEmptyListOfRandomIntegers();

            var el = new NonEmptyCollection<int>(nonEmptyList);

            Assert.NotStrictEqual(nonEmptyList, el.Value);
            Assert.True(nonEmptyList.GetHashCode() != el.Value.GetHashCode());
        }

        [Fact]
        public void ReturnTheInputListValues()
        {
            var nonEmptyList = CreateNonEmptyListOfRandomIntegers();

            var nonEmptyCollection = new NonEmptyCollection<int>(nonEmptyList);

            foreach (var item in nonEmptyCollection.Value)
            {
                Assert.Contains(item, nonEmptyList);
            }
        }

        private IList<int> CreateNonEmptyListOfRandomIntegers()
        {
            var fixture = new Fixture();
            var size = fixture.Create<int>();

            return fixture.CreateMany<int>(size).ToList();
        }
    }
}