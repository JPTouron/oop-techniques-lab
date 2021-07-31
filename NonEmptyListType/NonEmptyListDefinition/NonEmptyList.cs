using System;
using System.Collections.Generic;
using System.Linq;

namespace NonEmptyListDefinition
{
    public class NonEmptyList<T>
    {
        private IEnumerable<T> list;

        public NonEmptyList(IEnumerable<T> list)
        {
            var isListEmpty = IsListEmpty(list);
            if (isListEmpty)
                throw new ArgumentException("The parameter list cannot be an empty list", nameof(list));

            SetACopyOfTheInputParameterAsState(list);
        }

        public IEnumerable<T> Value => list;

        private bool IsListEmpty(IEnumerable<T> list)
        {
            return list.Any() == false;
        }

        private void SetACopyOfTheInputParameterAsState(IEnumerable<T> list)
        {
            this.list = new List<T>(list);
        }
    }
}