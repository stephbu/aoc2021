namespace Aoc2021.Day5
{
    internal struct VentLine {
        internal Coord Start;
        internal Coord End;
        internal string Description;

        internal bool IsVerticalHorizontal(){
            return Start.X == End.X || Start.Y == End.Y;
        }

        public override string ToString() {
            return this.Description;
        }
    }
}
