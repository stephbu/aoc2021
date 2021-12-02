namespace Aoc2021.Utility
{
    using System.Linq;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Window<T>(this IEnumerable<T> enumerable, uint length) 
        {
            IEnumerator<T> e = enumerable.GetEnumerator();
            LinkedList<T> state = new LinkedList<T>();
            while ( e.MoveNext() ) {
                T next = e.Current;
                state.AddLast(next);

                if(state.Count > length)
                {
                    state.RemoveFirst();
                }
                yield return state.ToArray();
            }
        }
    }

}