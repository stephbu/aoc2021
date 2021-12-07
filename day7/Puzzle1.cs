namespace Aoc2021.Day7
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle1 
    {
        public static void Sample()
        {
            var lines = File.GetTextFileValues("./Day7/sample.csv");
            var result = DoWork(lines);
        }

        internal static int DoWork(IEnumerable<string> lines) {

            var line = lines.FirstOrDefault();

            int maxCrab = 0;
            foreach(int crabPos in line.Split(",").Select(v => int.Parse(v))) {
                if(crabPos > maxCrab) {
                    maxCrab = crabPos + 1;       
                }
            }

            int[] crabsByPos = new int[maxCrab];
            foreach(int crabPos in line.Split(",").Select(v => int.Parse(v))) {
                crabsByPos[crabPos]++;
            }

            var leastFuelPos = -1;
            var leastFuel = -1;

            for(int pos = 0; pos < maxCrab; pos++) {
                int totalFuelUsed = 0;
                for(int index = 0; index < maxCrab; index++) {
                    totalFuelUsed = totalFuelUsed + (System.Math.Abs(index-pos) * crabsByPos[index]);
                }

                if(leastFuelPos == -1 || totalFuelUsed < leastFuel) {
                    leastFuel = totalFuelUsed;
                    leastFuelPos = pos;
                }
            }

            Console.WriteLine("Position {0}:{1}", leastFuelPos, leastFuel);
            return 0;

        }
        public static void Question() 
        {
            var lines = File.GetTextFileValues("./Day7/input.csv");
            var result = DoWork(lines);
        }
    }
}