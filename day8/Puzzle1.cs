namespace Aoc2021.Day8
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle1 
    {
        public static void Sample1()
        {
            Console.WriteLine("Sample1");
            var lines = File.GetTextFileValues("./Day8/sample1.csv");
            var result = DoWork(lines);
        }

        public static void Sample2()
        {
            Console.WriteLine("Sample2");
            var lines = File.GetTextFileValues("./Day8/sample2.csv");
            var result = DoWork(lines);
        }

        internal struct Entry {
            internal string[] SignalPattern;
            internal string[] Output;
        }

        internal static int DoWork(IEnumerable<string> lines) {

            
            List<Entry> entries = new List<Entry>();

            Dictionary<string, string> signalLookup = new Dictionary<string, string>();

            foreach(var line in lines) {

                var entryValues = line.Split("|", StringSplitOptions.TrimEntries);

                var entry = new Entry{
                    SignalPattern = entryValues[0].Split(" ", StringSplitOptions.TrimEntries),
                    Output = entryValues[1].Split(" ", StringSplitOptions.TrimEntries)
                };

                foreach(var signalPattern in entry.SignalPattern) {
                    if(!signalLookup.ContainsKey(signalPattern)) {
                        signalLookup.Add(signalPattern, "");
                    }
                }
                foreach(var outputDigit in entry.Output) {
                    if(!signalLookup.ContainsKey(outputDigit)) {
                        signalLookup.Add(outputDigit, "");
                    }
                }

                entries.Add(entry);    


            }

            foreach(var k in signalLookup.Keys) {

                switch(k.Length) {
                    case 2: 
                        signalLookup[k] = "1";
                        break;

                    case 3: 
                        signalLookup[k] = "7";
                        break;

                    case 4: 
                        signalLookup[k] = "4";
                        break;

                    case 7:
                        signalLookup[k] = "8";
                        break;

                    default: 
                        break;
                }

                Console.WriteLine("{0}:{1}", k, signalLookup[k]);
            }

            // reparse entries

            var digitCount = 0;
            foreach(var entry in entries) {
                foreach(var signal in entry.Output) {
                    if(!string.IsNullOrEmpty(signalLookup[signal])) {
                        digitCount++;
                    }
                }
            }

            Console.WriteLine("Digit Count: {0}", digitCount);
        
            return 0;
        }
        public static void Question() 
        {
            Console.WriteLine("Question");

            var lines = File.GetTextFileValues("./Day8/input.csv");
            var result = DoWork(lines);
        }
    }
}