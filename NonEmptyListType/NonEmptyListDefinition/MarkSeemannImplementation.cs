using System;
using System.Collections;
using System.Collections.Generic;

namespace NonEmptyListDefinition
{
    /// <summary>
    /// extracted from: https://blog.ploeh.dk/2017/12/11/semigroups-accumulate/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NotEmptyCollection<T> : IReadOnlyCollection<T>
    {
        public NotEmptyCollection(T head, params T[] tail)
        {
            if (head == null)
                throw new ArgumentNullException(nameof(head));

            Head = head;
            Tail = tail;
        }

        public int Count { get => this.Tail.Count + 1; }

        public T Head { get; }

        public IReadOnlyCollection<T> Tail { get; }

        public IEnumerator<T> GetEnumerator()
        {
            yield return Head;
            foreach (var item in Tail)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}