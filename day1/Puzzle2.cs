namespace Aoc2021.Day1
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public struct Changes {
        public int Increases = 0; 
        public int Decreases = 0;
        public int Nochange = 0;
        public int Last = 0;

        public override string ToString()
        {
            return String.Format("({0},{1},{2})", this.Increases, this.Decreases, this.Nochange);
        }

    }

    public static class Puzzle2
    {
        public static void Sample() 
        {
            var values = File.GetTextFileValues("./Day1/sample.csv").Select(l => int.Parse(l));
            var response = GetWindowIncreasesDecreases(values);
            Console.WriteLine(response);
        }

        public static void Question() 
        {
            var values = File.GetTextFileValues("./Day1/puzzle1.csv").Select(l => int.Parse(l));
            var response = GetWindowIncreasesDecreases(values);
            Console.WriteLine(response);
        }

        public static Changes GetWindowIncreasesDecreases(IEnumerable<int> values)
        {
            var windowSums = values.Window(3).Where(w => w.Count() == 3).Select(w => w.Sum());
            var result = windowSums.Aggregate(new Changes(),(changes, next) => {
                if(changes.Last != 0) {
                    if(next < changes.Last)
                    {
                        changes.Decreases++;
                    }
                    else if (next > changes.Last) 
                    {
                        changes.Increases++;
                    }
                    else
                    {
                        changes.Nochange++;
                    }
                }
                changes.Last = next;
                return changes;

            });

            return result;
        }

        public static IEnumerable<IEnumerable<T>> Window<T>(this IEnumerable<T> enumerable, uint length) {
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