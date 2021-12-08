namespace Aoc2021.Day8
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle2 
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

        internal static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

        internal static int DoWork(IEnumerable<string> lines) {

            
            List<Entry> entries = new List<Entry>();
            int outputTotal = 0;

            foreach(var line in lines) {

                Dictionary<string, string> signalLookup = new Dictionary<string, string>();

                var entryValues = line.Split("|", StringSplitOptions.TrimEntries);

                var entry = new Entry{
                    SignalPattern = entryValues[0].Split(" ", StringSplitOptions.TrimEntries).Select(v => SortString(v)).ToArray(),
                    Output = entryValues[1].Split(" ", StringSplitOptions.TrimEntries).Select(v => SortString(v)).ToArray()
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

                Dictionary<object,string> segments = new Dictionary<object, string>();

                foreach(var k in signalLookup.Keys) {

                    switch(k.Length) {
                        case 2: 
                            signalLookup[k] = "1";
                            segments[1] = k;
                            break;

                        case 3: 
                            segments[7] = k;
                            signalLookup[k] = "7";
                            break;

                        case 4: 
                            segments[4] = k;
                            signalLookup[k] = "4";
                            break;

                        case 7:
                            segments[8] = k;
                            signalLookup[k] = "8";
                            break;

                        default: 
                            break;
                    }
                }

                segments[47] = segments[4].ConcatSortDistinctChars(segments[7]);
                segments["EG"] = segments[8].ExcludeDistinctChars(segments[47]);
                segments["BD"] = segments[4].ExcludeDistinctChars(segments[1]);
                segments["CF"] = segments[1];
                segments["A"] = segments[7].ExcludeDistinctChars(segments[1]);

                bool found = true;
                while(found) {

                    found = false;

                    foreach(var k in signalLookup.Keys) {

                        if(!segments.ContainsKey(0)) {
                            // Zero has EG, CF, not BD
                            if(k.IncludesAll(segments["EG"]) && k.IncludesAll(segments["CF"]) && !k.IncludesAll(segments["BD"])) {
                                segments[0] = k;
                                signalLookup[k] = "0";
                                segments["D"] = segments[8].ExcludeDistinctChars(segments[0]);
                                segments["B"] = segments[4].ExcludeDistinctChars(segments["D"]).ExcludeDistinctChars(segments["CF"]);
                                Console.WriteLine("Found 0:{0}", segments[0]);
                                found = true;
                                break;
                            }
                        }

                        // you need 0 to find 6
                        if(segments.ContainsKey(0) && !segments.ContainsKey(6)) {
                            // Six has EG, B, D, A, excludes CF
                            if(k.IncludesAll(segments["EG"]) 
                                && k.IncludesAll(segments["A"]) 
                                && k.IncludesAll(segments["BD"])
                                && !k.IncludesAll(segments["CF"])
                                ){
                                
                                segments[6] = k;
                                signalLookup[k] = "6";

                                segments["C"] = segments[8].ExcludeDistinctChars(segments[6]);
                                segments["F"] = segments[1].ExcludeDistinctChars(segments["C"]);
                                segments["B"] = segments[4].ExcludeDistinctChars(segments["D"]).ExcludeDistinctChars(segments["CF"]);

                                segments[2] = segments[8].ExcludeDistinctChars(segments["B"]).ExcludeDistinctChars(segments["F"]);
                                signalLookup[segments[2]] = "2";

                                Console.WriteLine("Found 2:{0}", segments[2]);
                                Console.WriteLine("Found 6:{0}", segments[6]);
                                found = true;
                                break;
                            }
                        }

                        // you need 6 to find 9
                        if(segments.ContainsKey(6) && !segments.ContainsKey(9)) {
                            if(k.Length == 6 
                                && k.IncludesAll(segments["D"]) 
                                && k.IncludesAll(segments["C"])) {
                                
                                segments[9] = k;
                                signalLookup[k] = "9";

                                segments["E"] = segments[8].ExcludeDistinctChars(segments[9]);
                                segments["G"] = segments["EG"].ExcludeDistinctChars(segments["E"]);

                                segments[3] = segments[8].ExcludeDistinctChars(segments["B"]).ExcludeDistinctChars(segments["E"]);
                                signalLookup[segments[3]] = "3";

                                segments[5] = segments[8].ExcludeDistinctChars(segments["C"]).ExcludeDistinctChars(segments["E"]);
                                signalLookup[segments[5]] = "5";


                                Console.WriteLine("Found 3:{0}", segments[3]);
                                Console.WriteLine("Found 5:{0}", segments[5]);
                                Console.WriteLine("Found 9:{0}", segments[9]);
                                found = true;
                                break;
                            }

                        }

                    }

                }

                foreach(var v in signalLookup) {
                    if(string.IsNullOrEmpty(v.Value))
                    {
                        throw new Exception("Empty value");
                    }
                }

                var outputValue = int.Parse(string.Concat(entry.Output.Select(v => signalLookup[v])));
                Console.WriteLine("Output Value: {0}", outputValue);
                outputTotal += outputValue;
            }

            Console.WriteLine("Total Output Value: {0}", outputTotal);
            



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