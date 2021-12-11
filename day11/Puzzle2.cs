using System.Reflection.Metadata;

namespace Aoc2021.Day11
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle2
    {
        public static void Sample1()
        {
            var lines = File.GetTextFileValues("./Day11/sample1.csv");
            
            int[,,] octopuses = new int[5, 5, 2];

            var lineNo = 0;
            foreach (string line in lines)
            {
                for (var x = 0; x < line.Length; x++)
                { 
                    octopuses[x, lineNo, 0] = int.Parse(line[x].ToString()); 
                }

                lineNo++;
            }
            
            var result = DoWork(octopuses, 2);
        }

        public static void Sample2()
        {
            var lines = File.GetTextFileValues("./Day11/sample2.csv");
            
            int[,,] octopuses = new int[10, 10, 2];

            var lineNo = 0;
            foreach (string line in lines)
            {
                for (var x = 0; x < line.Length; x++)
                { 
                    octopuses[x, lineNo, 0] = int.Parse(line[x].ToString()); 
                }

                lineNo++;
            }
            
            var result = DoWork(octopuses, 10000);
        }
        
        public struct Coord
        {
            public int X;
            public int Y;
        };
        
        internal static int DoWork(int[,,] octopuses, int maxSteps)
        {
            var step = 0;
            var totalFlashes = 0;
            var stepFlashes = 0;

            var maxX = octopuses.GetLength(0);
            var maxY = octopuses.GetLength(1);
            
            while (step < maxSteps)
            {
                IncrementEnergy(octopuses);
                
                var flashQueue = new Queue<Coord>();
                // scan and flash where energy > 9 and not flashed
                
                stepFlashes += EnqueueFlashes(octopuses, flashQueue);

                while (flashQueue.Count > 0)
                {
                    var nextFlash = flashQueue.Dequeue();
                    var x = nextFlash.X;
                    var y = nextFlash.Y;
                    
                    // top-row
                    if (x > 0 && y > 0) {octopuses[x - 1, y - 1,0]++;}
                    if (y > 0) {octopuses[x, y - 1,0]++;}
                    if (x < maxX - 1 && y > 0) {octopuses[x + 1, y - 1,0]++;}

                    // middle row
                    if (x > 0) {octopuses[x - 1, y,0]++;}
                    if (x < maxX - 1) {octopuses[x + 1, y,0]++;}

                    // bottom row
                    if (x > 0 && y < maxY - 1) {octopuses[x - 1, y + 1,0]++;}
                    if (y < maxY - 1) {octopuses[x, y + 1,0]++;}
                    if (x < maxX - 1 && y < maxY - 1) {octopuses[x + 1, y + 1,0]++;}

                    stepFlashes += EnqueueFlashes(octopuses, flashQueue);
                }

                step++;
                if(ResetFlashed(octopuses) == octopuses.GetLength(0) * octopuses.GetLength(1))
                {
                    Console.WriteLine("Complete Step:{0}", step);
                    break;
                }
            }
            
            return 0;
        }

        private static void Dump(int[,,] octopuses)
        {
            var maxX = octopuses.GetLength(0);
            var maxY = octopuses.GetLength(1);

            // increment
            for (var y = 0; y < maxY; y++)
            {
                for (var x = 0; x < maxX; x++)
                {
                    Console.Write(octopuses[x, y, 0]);
                }
                Console.WriteLine();
            }
        }

        private static void IncrementEnergy(int[,,] octopuses)
        {
            var maxX = octopuses.GetLength(0);
            var maxY = octopuses.GetLength(1);

            
            // increment
            for (var y = 0; y < maxY; y++)
            {
                for (var x = 0; x < maxX; x++)
                {
                    octopuses[x, y, 0]++;
                }
            }
        }

        private static int ResetFlashed(int[,,] octopuses)
        {
            var maxX = octopuses.GetLength(0);
            var maxY = octopuses.GetLength(1);

            int count = 0;
            // increment
            for (var y = 0; y < maxY; y++)
            {
                for (var x = 0; x < maxX; x++)
                {
                    if (octopuses[x, y, 1] > 0)
                    {
                        count++;
                        octopuses[x, y, 0] = 0;
                        octopuses[x, y, 1] = 0;
                    }
                }
            }

            return count;
        }
        
        private static int EnqueueFlashes(int[,,] octopuses, Queue<Coord> flashQueue)
        {
            var maxX = octopuses.GetLength(0);
            var maxY = octopuses.GetLength(1);

            var flashCount = 0;
            for (var y = 0; y < maxY; y++)
            {
                for (var x = 0; x < maxX; x++)
                {
                    if (octopuses[x, y, 0] > 9 && octopuses[x,y,1] == 0)
                    {
                        flashQueue.Enqueue(new Coord {X = x, Y = y});
                        octopuses[x, y, 1] = 1;
                        flashCount++;
                    }
                }
            }

            return flashCount;
        }

        public static void Question() 
        {
            var lines = File.GetTextFileValues("./Day11/input.csv");
            
            int[,,] octopuses = new int[10, 10, 2];

            var lineNo = 0;
            foreach (string line in lines)
            {
                for (var x = 0; x < line.Length; x++)
                { 
                    octopuses[x, lineNo, 0] = int.Parse(line[x].ToString()); 
                }

                lineNo++;
            }
            
            var result = DoWork(octopuses, 10000);
        }
    }
}