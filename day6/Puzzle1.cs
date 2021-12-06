namespace Aoc2021.Day6
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle1 
    {
        public static void Sample()
        {
            var lines = File.GetTextFileValues("./Day6/sample.csv");
            int count = DoWork(lines, 18);
            Console.WriteLine("Total Laternfish:{0}", count);
        }

        internal static int DoWork(IEnumerable<string> lines, int days) {

            List<int> fish = new List<int>();
            var line = lines.FirstOrDefault();

            foreach(int fishTime in line.Split(",").Select(v => int.Parse(v))) {
                fish.Add(fishTime);
            }

            Console.Write("Day 0 :");
            for(int index = 0; index < fish.Count; index++) {
                Console.Write(fish[index]);
            }

            Console.WriteLine("Start: {0} laternfish", fish.Count);

            int elapsedDays = 0;
            while(elapsedDays < days) {

                elapsedDays++;

                for(int index = 0; index < fish.Count; index++) {
                    if(fish[index] > 0) {
                        fish[index]--;
                    } else {
                        fish[index] = 6;
                        fish.Add(8);
                    }
                }

                Console.Write("Day {0} :", elapsedDays);
                for(int index = 0; index < fish.Count; index++) {
                    Console.Write(fish[index]);
                }
                Console.WriteLine();

            }

            return fish.Count;

        }
        public static void Question() 
        {
            var lines = File.GetTextFileValues("./Day6/input.csv");
            // DoWork(lines, 80);
        }
    }
}