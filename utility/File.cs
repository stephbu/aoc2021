namespace Aoc2021.Utility
{
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    public static class File 
    {
        public static uint[] GetValuesFromFile(string filename)
        {
            return GetTextFileValues(filename).Select(l => uint.Parse(l)).ToArray();
        }

        public static IEnumerable<string> GetTextFileValues(string filename)
        {
            foreach (string line in System.IO.File.ReadLines(filename))
            {  
                yield return line;
            }  
        }
    }
}