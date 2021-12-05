namespace Aoc2021.Day5
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle2
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

                int x, xInc;
                int y, yInc;

                // mark vents on board
                if(ventLine.Start.X <= ventLine.End.X && ventLine.Start.Y <= ventLine.End.Y) {
                    // both X/Y positive
                    xInc = ventLine.Start.X == ventLine.End.X ? 0 : 1;
                    yInc = ventLine.Start.Y == ventLine.End.Y ? 0 : 1;

                    x = ventLine.Start.X;
                    y = ventLine.Start.Y;
                    while(x <= ventLine.End.X && y <= ventLine.End.Y) {
                        map[x, y]++;
                        x = x + xInc;
                        y = y + yInc;
                    }
                } else if(ventLine.Start.X <= ventLine.End.X && ventLine.Start.Y >= ventLine.End.Y) {
                    // positive X, negative Y

                    xInc = ventLine.Start.X == ventLine.End.X ? 0 : 1;
                    yInc = ventLine.Start.Y == ventLine.End.Y ? 0 : -1;

                    x = ventLine.Start.X;
                    y = ventLine.Start.Y;
                    while(x <= ventLine.End.X && y >= ventLine.End.Y) {
                        map[x, y]++;
                        x = x + xInc;
                        y = y + yInc;
                    }
                } else if(ventLine.Start.X >= ventLine.End.X && ventLine.Start.Y <= ventLine.End.Y) {
                    // negative X, positive Y

                    xInc = ventLine.Start.X == ventLine.End.X ? 0 : -1;
                    yInc = ventLine.Start.Y == ventLine.End.Y ? 0 : 1;

                    x = ventLine.Start.X;
                    y = ventLine.Start.Y;
                    while(x >= ventLine.End.X && y <= ventLine.End.Y) {
                        map[x, y]++;
                        x = x + xInc;
                        y = y + yInc;
                    }
                } else if(ventLine.Start.X >= ventLine.End.X && ventLine.Start.Y >= ventLine.End.Y) {
                    // negative X, negative Y

                    xInc = ventLine.Start.X == ventLine.End.X ? 0 : -1;
                    yInc = ventLine.Start.Y == ventLine.End.Y ? 0 : -1;

                    x = ventLine.Start.X;
                    y = ventLine.Start.Y;
                    while(x >= ventLine.End.X && y >= ventLine.End.Y) {
                        map[x, y]++;
                        x = x + xInc;
                        y = y + yInc;
                    }
                } else {
                    Console.WriteLine("Barf: {0}", ventLine.Description);
                }


            }

            int intersections = 0;
            DumpMap(map);
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