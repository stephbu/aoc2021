namespace Aoc2021.Utility
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class LinqExtensions
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

        public static Tuple<int, int> CoordinatesOf<T>(this T[,] matrix, T value)
        {
            int w = matrix.GetLength(0); // width
            int h = matrix.GetLength(1); // height

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (matrix[x, y].Equals(value))
                        return Tuple.Create(x, y);
                }
            }

            return Tuple.Create(-1, -1);
        }
    }
}