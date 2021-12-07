namespace Aoc2021.Utility
{
    public class Math {

        /// https://en.wikipedia.org/wiki/Gauss_sum
        public static int GaussSum(int steps) {
            return steps * (steps + 1) / 2;
        }
    }
}