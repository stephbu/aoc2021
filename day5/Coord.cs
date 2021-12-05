namespace Aoc2021.Day5
{
    using System.Linq;

    internal struct Coord {
        internal int X;
        internal int Y;

        internal static Coord Parse(string coord) {
            int[] components = coord.Split(",").Select(s => int.Parse(s)).ToArray();

            return new Coord{X=components[0], Y=components[1]};
        }
    }
}
