namespace Aoc2021.Day6
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle2 
    {
        public static void Sample()
        {
            var lines = File.GetTextFileValues("./Day6/sample.csv");
            ulong count = DoWork(lines, 256);
            Console.WriteLine("Total Laternfish:{0}", count);
        }

        internal struct Page {
            internal byte[] Fish = new byte[1048576];
        }

        internal static ulong DoWork(IEnumerable<string> lines, int days) {

            var fish = new Dictionary<int, ulong>();
            for(int index = 0; index <= 8; index++) {
                fish[index] = 0;
            }

            var line = lines.FirstOrDefault();
            foreach(byte fishTimer in line.Split(",").Select(v => byte.Parse(v))) {
                fish[fishTimer]++;
            }

            int elapsedDays = 0;
            while(elapsedDays < days) {

                elapsedDays++;

                var fish_zero = fish[0];
                for(int index = 1; index <= 8; index++) {
                    fish[index - 1] = fish[index];
                }
                fish[8] = fish_zero;
                fish[6] = fish[6] + fish_zero;

                Console.WriteLine("Day {0}:{1}", elapsedDays, fish[0] + fish[1] + fish[2] + fish[3] + fish[4] + fish[5] + fish[6] + fish[7] + fish[8]);
            }

            return fish[0] + fish[1] + fish[2] + fish[3] + fish[4] + fish[5] + fish[6] + fish[7] + fish[8];

        }
        public static void Question() 
        {
            var lines = File.GetTextFileValues("./Day6/input.csv");
            ulong count = DoWork(lines, 256);
            Console.WriteLine("Total Laternfish:{0}", count);
        }

    }
}