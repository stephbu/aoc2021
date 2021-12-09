namespace Aoc2021.Day9
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle2
    {
        public static void Sample()
        {
            Console.WriteLine("Sample");
            var lines = File.GetTextFileValues("./Day9/sample.csv");


            // z[0] = data
            // z[1] = lowPoint Data
            var heightMap = new int[10, 5, 2];

            // load
            var y = 0;
            foreach (var line in lines)
            {
                for(var x = 0; x < line.Length; x++)
                {
                    heightMap[x, y, 0] = int.Parse(line[x].ToString());
                }
                y++;
            }
            var result = DoWork(heightMap);
        }

        private static int DoWork(int[,,] heightMap)
        {


            var mapWidth = heightMap.GetLength(0);
            var mapDepth = heightMap.GetLength(1);

            List<int> basinSize = new List<int>();
            for (var y = 0; y < mapDepth; y++)
            {
                for(var x = 0; x < mapWidth; x++)
                {
                    // low point = lower than adjacent low points
                    bool left, right, up, down = true;
                    
                    // check-left
                    left = (x > 0) ? (heightMap[x, y, 0] < heightMap[x-1, y, 0]) : true; 

                    // check right
                    right = (x < mapWidth - 1) ? (heightMap[x, y, 0] < heightMap[x+1, y, 0]) : true; 

                    // check up
                    up = (y > 0) ? (heightMap[x, y, 0] < heightMap[x, y - 1, 0]) : true; 

                    // check down
                    down = (y < mapDepth - 1) ? (heightMap[x, y, 0] < heightMap[x, y + 1, 0]) : true;

                    if (left && right && up && down)
                    {
                        heightMap[x, y, 1] = heightMap[x, y, 0] + 1;
                                                
                        int size = FindBasin(heightMap, x, y);
                        Console.WriteLine(size);

                        basinSize.Add(size);

                    }
                    
                }
            }

            Console.WriteLine(basinSize.OrderByDescending(i => i).Take(3).Aggregate((total, next) => total = total * next));            
            return 0;
        }

        internal struct Coord {
            internal int X;
            internal int Y;
        }

        private static int FindBasin(int[,,] heightMap, int startX, int startY)
        {
            Queue<Coord> searchQueue = new Queue<Coord>();
            searchQueue.Enqueue(new Coord{X=startX, Y=startY});

            var mapWidth = heightMap.GetLength(0);
            var mapDepth = heightMap.GetLength(1);

            var basinSize = 0;
            while(searchQueue.Count > 0) {

                Coord coord = searchQueue.Dequeue();

                var x = coord.X;
                var y = coord.Y;

                if((heightMap[x,y,0] == 9) || (heightMap[x,y,1] == -1)) { 
                    continue;
                }

                heightMap[x,y,1] = -1;
                basinSize++;

                if (x > 0) {
                    searchQueue.Enqueue(new Coord{X=x-1, Y=y});
                }  

                if (x < mapWidth - 1) {
                    searchQueue.Enqueue(new Coord{X=x+1, Y=y});
                } 

                if (y > 0) {
                    searchQueue.Enqueue(new Coord{X=x, Y=y-1});
                }

                if (y < mapDepth - 1) {
                    searchQueue.Enqueue(new Coord{X=x, Y=y+1});
                }
            }

            return basinSize;
        }


        public static void Question() 
        {
            Console.WriteLine("Question");

            var lines = File.GetTextFileValues("./Day9/input.csv");
            // z[0] = data
            // z[1] = lowPoint Data
            var heightMap = new int[100, 100, 2];

            // load
            var y = 0;
            foreach (var line in lines)
            {
                for(var x = 0; x < line.Length; x++)
                {
                    heightMap[x, y, 0] = int.Parse(line[x].ToString());
                }
                y++;
            }
            var result = DoWork(heightMap);
        }
    }
}