using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NonEmptyListDefinition
{
    public class NonEmptyCollection<T> : IReadOnlyCollection<T>
    {
        private IEnumerable<T> list;

        public NonEmptyCollection(IEnumerable<T> list)
        {
            var isListEmpty = IsListEmpty(list);
            if (isListEmpty)
                throw new ArgumentException("The parameter list cannot be an empty list", nameof(list));

            CopyListReference(list);
        }

        public NonEmptyCollection(T firstItem, params T[] restOfItems)
        {
            if (firstItem == null)
                throw new ArgumentNullException(nameof(firstItem));

            var internalList = CreateListFromDiscreteItems(firstItem, restOfItems);

            list = internalList;
        }

        public IEnumerable<T> Value => list;

        public int Count => list.Count();

        public static implicit operator List<T>(NonEmptyCollection<T> list) => new List<T>(list);

        public static implicit operator NonEmptyCollection<T>(List<T> list) => new NonEmptyCollection<T>(list);

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        private static List<T> CreateListFromDiscreteItems(T firstItem, T[] restOfItems)
        {
            var internalList = new List<T>();

            internalList.Add(firstItem);

            if (restOfItems?.Length > 0)
                internalList.AddRange(restOfItems);
            return internalList;
        }

        private void CopyListReference(IEnumerable<T> list)
        {
            this.list = new List<T>(list);
        }

        private bool IsListEmpty(IEnumerable<T> list)
        {
            return list.Any() == false;
        }
    }
}