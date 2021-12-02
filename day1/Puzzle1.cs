namespace Aoc2021.Day1
{
    using System;

    using Aoc2021.Utility;

    public class Puzzle1 
    {
        public static void Sample() 
        {
            uint[] values = File.GetValuesFromFile("./Day1/sample.csv");
            var response = GetIncreasesDecreases(values);
            Console.WriteLine(response);
        }

        public static void Question() 
        {
            uint[] values = File.GetValuesFromFile("./Day1/puzzle1.csv");
            var response = GetIncreasesDecreases(values);
            Console.WriteLine(response);
        }


        private static Tuple<uint, uint> GetIncreasesDecreases(uint[] values)
        {
            uint increases = 0;
            uint decreases = 0;

            var length = values.Length;

            if(length < 2) {
                return new Tuple<uint,uint>(0,0);
            }

            uint last = 0;
            for(uint index = 1; index < length; index++) {
                if(values[index] < last)
                {
                    decreases++;
                }
                else if (values[index] > last) 
                {
                    increases++;
                }
                else
                {
                    // no change
                }
                last = values[index];
            }

            return new Tuple<uint, uint>(increases, decreases);
        }
    }
}
