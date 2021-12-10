namespace Aoc2021.Day10
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle1 
    {
        public static void Sample()
        {
            var lines = File.GetTextFileValues("./Day10/sample.csv");
            var result = DoWork(lines);
        }

        internal const string chunkOpen = "([{<";
        internal const string chunkClose = ")]}>";

        internal static int DoWork(IEnumerable<string> lines) {


            
            List<string> validatedLines = new List<string>();
            List<string> invalidLines = new List<string>();

            int totalSyntaxScore = 0;
            foreach(var line in lines)
            {
                char? badChar = FindFirstSyntaxError(line);
                if(badChar != null) {
                    switch(badChar) {
                        case ')':

                            totalSyntaxScore += 3;
                            break;
                        case ']':

                            totalSyntaxScore += 57;
                            break;                    
                        case '}':

                            totalSyntaxScore += 1197;
                            break;
                        case '>':

                            totalSyntaxScore += 25137;
                            break;                    
                    }
                }
            }

            Console.WriteLine("Score:{0}",totalSyntaxScore);


            return 0;

            static char? FindFirstSyntaxError(string line)
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

                            Console.WriteLine("{0} at {1} - Expected {2}, but found {3} instead", line, i, expectedOpen, c);
                            return c;
                        }
                    }
                }

                return null;
            }
        }
        public static void Question() 
        {
            var lines = File.GetTextFileValues("./Day10/input.csv");
            var result = DoWork(lines);
        }
    }
}