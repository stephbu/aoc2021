namespace Aoc2021.Day3
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle1 
    {
        public static void Sample() 
        {
            var lineChars = File.GetTextFileValues("./Day3/sample.csv").Select(l => l.ToCharArray());

            Dictionary<int, Dictionary<char, int>> bitMap = new Dictionary<int, Dictionary<char, int>>();

            foreach(var chars in lineChars)
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

            string gammaStr = "", epsilionStr = "";

            foreach(var kvp in bitMap)
            {
                if(bitMap[kvp.Key]['1'] > bitMap[kvp.Key]['0'])
                {
                    gammaStr = gammaStr + "1";
                    epsilionStr = epsilionStr + "0";
                } else {
                    gammaStr = gammaStr + "0";
                    epsilionStr = epsilionStr + "1";                    
                }

            }

            Console.WriteLine("G:{0},D:{1}", gammaStr, epsilionStr);

            int gamma = Convert.ToInt32(gammaStr, 2);
            int epsilion = Convert.ToInt32(epsilionStr, 2);

            Console.WriteLine("G:{0},D:{1}", gamma, epsilion);
            Console.WriteLine("Power:{0}", gamma * epsilion);

        }

        public static void Question() 
        {
            var lineChars = File.GetTextFileValues("./Day3/input.csv").Select(l => l.ToCharArray());

            Dictionary<int, Dictionary<char, int>> bitMap = new Dictionary<int, Dictionary<char, int>>();

            foreach(var chars in lineChars)
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

            string gammaStr = "", epsilionStr = "";

            foreach(var kvp in bitMap)
            {
                if(bitMap[kvp.Key]['1'] > bitMap[kvp.Key]['0'])
                {
                    gammaStr = gammaStr + "1";
                    epsilionStr = epsilionStr + "0";
                } else {
                    gammaStr = gammaStr + "0";
                    epsilionStr = epsilionStr + "1";                    
                }

            }

            Console.WriteLine("G:{0},D:{1}", gammaStr, epsilionStr);

            int gamma = Convert.ToInt32(gammaStr, 2);
            int epsilion = Convert.ToInt32(epsilionStr, 2);

            Console.WriteLine("G:{0},D:{1}", gamma, epsilion);
            Console.WriteLine("Power:{0}", gamma * epsilion);

        }
    }
}