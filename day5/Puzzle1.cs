namespace Aoc2021.Day5
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle1 
    {
        public static void Sample()
        {
            var lines = File.GetTextFileValues("./Day5/sample.csv");
            DoWork(lines);
        }

        internal static void DoWork(IEnumerable<string> lines) {

            int[,] map = new int[1000,1000];

            foreach(var line in lines) {
                var ventLine = processInput(line);
                if(!ventLine.IsVerticalHorizontal()) {
                    Console.WriteLine("Diagonal Vent {0}", ventLine);
                    continue;
                }

                // mark vents on board
                if(ventLine.Start.X == ventLine.End.X) {
                    // variance is in Y axis

                    var startY = ventLine.Start.Y > ventLine.End.Y ? ventLine.End.Y : ventLine.Start.Y;
                    var endY = ventLine.Start.Y > ventLine.End.Y ? ventLine.Start.Y : ventLine.End.Y;
                    Console.WriteLine("Processing {0} as {1},{2} -> {1},{3}", ventLine, ventLine.Start.X, startY, endY);
                    for(int y = startY; y <= endY; y++) {
                        map[ventLine.Start.X, y]++;
                    } 

                } else {
                    // variance is in the x axis
                    var startX = ventLine.Start.X > ventLine.End.X ? ventLine.End.X : ventLine.Start.X;
                    var endX = ventLine.Start.X > ventLine.End.X ? ventLine.Start.X : ventLine.End.X;
                    Console.WriteLine("Processing {0} as {2},{1} -> {3},{1}", ventLine, ventLine.Start.Y, startX, endX);
                    for(int x = startX; x <= endX; x++) {
                        map[x, ventLine.Start.Y]++;
                    } 
                }
            }

            int intersections = 0;
            // DumpMap(map);
            EvaluateMap(map, (i) => {if((i) > 1) intersections++;});
            Console.WriteLine("Intersections: {0}", intersections);
        }

        internal static void EvaluateMap(int[,] map, Action<int> eval) {
            for(var y = 0; y < map.GetLength(1); y++) { 
                for(var x = 0; x < map.GetLength(0); x++) {
                    eval(map[x,y]);
                }
            }
        }

        internal static void DumpMap(int[,] map) {
            for(var y = 0; y < map.GetLength(1); y++) { 
                for(var x = 0; x < map.GetLength(0); x++) {
                    Console.Write(map[x,y]);
                }
                Console.WriteLine();
            }
        }

        internal static VentLine processInput(string line) {
            Coord[] coords = line.Split(" -> ").Select(c => Coord.Parse(c)).ToArray();
            return new VentLine{Start=coords[0], End=coords[1], Description = line};
        }

        public static void Question() 
        {
            var lines = File.GetTextFileValues("./Day5/input.csv");
            DoWork(lines);
        }
    }
}