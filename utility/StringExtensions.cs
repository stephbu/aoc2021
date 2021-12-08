namespace Aoc2021.Utility
{
    using System;
    using System.Linq;

    public static class StringExtensions
    {
        public static string Format(this string format, params object[] args) {
            return string.Format(format,args);
        }

        public static string ExcludeDistinctChars(this string sortString, string exclusions){
            var distinctExcludedChars = sortString.Select(c => exclusions.Contains(c) ? "" : new String(c,1)).Distinct();
            return String.Concat(distinctExcludedChars);
        }

        public static string ConcatSortDistinctChars(this string str1, string str2){
            return String.Concat((str1 + str2).Distinct().OrderBy(c => c));
        }

        public static bool IncludesAll(this string str1, string str2){

            foreach(var c in str2) {
                if(str1.IndexOf(c) < 0) {
                    return false;
                }
            }
            return true;
        }
    }
}