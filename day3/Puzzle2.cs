namespace Aoc2021.Day3
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle2 
    {
        public static void Sample() 
        {
            var oxygen = Compute(File.GetTextFileValues("./Day3/sample.csv"), GetMostCommonBit);
            var co2 = Compute(File.GetTextFileValues("./Day3/sample.csv"), GetLeastCommonBit);

            Console.WriteLine("Rating:{0}", oxygen * co2);
        }

        public static int Compute(IEnumerable<string> lines, Func<Dictionary<int, Dictionary<char, int>>, int, char> comparer) 
        {
            int offset = 0;
            var residualLines = lines.ToArray();
            while(true) {

                Dictionary<int, Dictionary<char, int>> bitMap = new Dictionary<int, Dictionary<char, int>>();

                foreach(var chars in residualLines.Select(l => l.ToCharArray()))
                {
                    for(int index = 0; index < chars.Length; index++)
                    {
                        if(!bitMap.ContainsKey(index)) {
                            bitMap[index] = new Dictionary<char, int>();
                        }

                        if(!bitMap[index].ContainsKey(chars[index]))
                        {
                            bitMap[index][chars[index]] = 0;
                        }
                        bitMap[index][chars[index]]++;
                    }
                }

                var comparedBit = comparer(bitMap, offset);
                Console.WriteLine("Bit[{0}] = {1}", offset, comparedBit);

                residualLines = residualLines.Where(c => c[offset] == comparedBit).ToArray();

                offset++;
                if(residualLines.Length <= 1) {
                    break;
                }

            }

            Console.WriteLine(residualLines[0]);

            return Convert.ToInt32(residualLines[0], 2);
        }

        internal static char GetMostCommonBit(Dictionary<int, Dictionary<char, int>> bitMap, int bit) {
            return bitMap[bit]['1'] >= bitMap[bit]['0'] ? '1' : '0';
        }

        internal static char GetLeastCommonBit(Dictionary<int, Dictionary<char, int>> bitMap, int bit) {
            return bitMap[bit]['1'] >= bitMap[bit]['0'] ? '0' : '1';
        }


        public static void Question()
        {
            var oxygen = Compute(File.GetTextFileValues("./Day3/input.csv"), GetMostCommonBit);
            var co2 = Compute(File.GetTextFileValues("./Day3/input.csv"), GetLeastCommonBit);
            Console.WriteLine("Rating:{0}", oxygen * co2);
        } 
    }
}