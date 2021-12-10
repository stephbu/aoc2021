namespace Aoc2021.Day10
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle2 
    {
        public static void Sample()
        {
            var lines = File.GetTextFileValues("./Day10/sample.csv");
            var result = DoWork(lines);
        }

        internal const string chunkOpen = "([{<";
        internal const string chunkClose = ")]}>";

        internal static int DoWork(IEnumerable<string> lines) {
            
            List<ulong> acScores = new List<ulong>();

            foreach(var line in lines)
            {
                ulong lineACScore = 0;
                string acString = GetAutocompleteLine(line);

                if(acString == null) {
                    // error line
                    continue;
                }

                if(acString == "") {
                    // no AC
                    continue;
                }

                for(int i=0; i < acString.Length; i++)
                {
                    char c = acString[i];

                    switch(c) {
                        case ')':
                            lineACScore = (lineACScore * 5) + 1;
                            break;
                        case ']':

                            lineACScore = (lineACScore * 5) + 2;
                            break;                    
                        case '}':

                            lineACScore = (lineACScore * 5) + 3;
                            break;
                        case '>':
                            lineACScore = (lineACScore * 5) + 4;
                            break;                    
                    }
                }

                Console.WriteLine("{0} - {1}",acString, lineACScore);
                acScores.Add(lineACScore);
            }

            var middleScore = acScores.OrderByDescending(i => i).Skip((int) (acScores.Count()/2)).Take(1).FirstOrDefault();
            Console.WriteLine("Middle Score: {0}", middleScore);

            return 0;

            static string GetAutocompleteLine(string line)
            {
                Stack<char> validationStack = new Stack<char>();
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if (chunkOpen.Contains(c))
                    {
                        validationStack.Push(c);
                    }
                    else if (chunkClose.Contains(c))
                    {
                        var offset = chunkClose.IndexOf(c);
                        var expected = chunkOpen[offset];
         
                        if (validationStack.Peek() == expected)
                        {
                            // tags match - close the chunk
                            validationStack.Pop();
                        }
                        else
                        {
                            var expectedOpen = chunkClose[chunkOpen.IndexOf(validationStack.Peek())];
                            //Console.WriteLine("{0} at {1} - Expected {2}, but found {3} instead", line, i, expectedOpen, c);
                            return null;
                        }
                    }
                }

                if(validationStack.Count > 0) {
                    
                    List<char> acChars = new List<char>();
                    while(validationStack.Count() > 0)
                    {
                        char missingClose = chunkClose[chunkOpen.IndexOf(validationStack.Pop())];
                        acChars.Add(missingClose);
                    }
                    return String.Concat(acChars.Select(c => c.ToString()));

                } else
                {
                    return "";
                }
            }
        }
        public static void Question() 
        {
            var lines = File.GetTextFileValues("./Day10/input.csv");
            var result = DoWork(lines);
        }
    }
}