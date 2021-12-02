namespace Aoc2021.Day2
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle1 
    {
        internal delegate void CommandFunction(ref Position position, int vector);

        public static void Sample() 
        {
            var commandFile = File.GetTextFileValues("./Day2/sample.csv");
            EvaluateCommands(commandFile);
        }

        public static void Question() 
        {
            var commandFile = File.GetTextFileValues("./Day2/input.csv");
            EvaluateCommands(commandFile);
        }

        public static void EvaluateCommands(IEnumerable<string> commands)
        {
            Position p = new Position();
            SubmarineCommandParser scp = new SubmarineCommandParser();

            foreach(string commandText in commands)
            {
                Command c = scp.Parse(commandText);
                c.Execute(ref p);
            }

            Console.WriteLine(p);
            Console.WriteLine(p.X * p.Depth);
        }

        internal class SubmarineCommandParser
        {
            
            private Dictionary<string, CommandFunction> functions = new Dictionary<string, CommandFunction>();

            internal SubmarineCommandParser()
            {
                functions["forward"] = this.Forward;
                functions["backward"] = this.Backward;
                functions["up"] = this.Up;
                functions["down"] = this.Down;
            }

            internal Command Parse(string command)
            {
                var commandArgs = command.Split(" ");
                if(commandArgs.Length != 2) {
                    throw new ArgumentException("Expected 2 args");
                }

                var result = new Command();

                if(!this.functions.ContainsKey(commandArgs[0].ToLowerInvariant())) 
                {
                    throw new ArgumentException("Command not found");
                }
                else
                {
                    result.Function = functions[commandArgs[0].ToLowerInvariant()];
                }

                result.Vector = int.Parse(commandArgs[1]);
                return result;
            }

            private void Forward(ref Position position, int vector)
            {
                position.X += vector;
            }

            private void Backward(ref Position position, int vector)
            {
                position.X -= vector;
            }

            private void Down(ref Position position, int vector)
            {
                position.Depth += vector;
            }

            private void Up(ref Position position, int vector)
            {
                position.Depth -= vector;
            }
        }

        internal struct Position
        {
            internal int X;
            internal int Y;
            internal int Depth;
            
            public override string ToString()
            {
                return String.Format("X:{0},Y:{1},Depth:{2}", this.X, this.Y, this.Depth);
            }
        }

        internal struct Command
        {
            internal CommandFunction Function;
            internal int Vector;

            public void Execute(ref Position p)
            {
                this.Function(ref p, this.Vector);
            }
        }
    }
}