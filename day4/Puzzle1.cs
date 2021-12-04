namespace Aoc2021.Day4
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    public class Puzzle1 
    {
        public static void Sample()
        {
            var lines = File.GetTextFileValues("./Day4/sample.csv");
            PlayBoard(lines);

        }

        private static void PlayBoard(IEnumerable<string> lines)
        {
            var boardEnumerator = lines.GetEnumerator();
            boardEnumerator.MoveNext();
            var numbersDrawn = boardEnumerator.Current.Split(",").Select(v => int.Parse(v)).ToArray();
            boardEnumerator.MoveNext();

            List<Board> boards = new List<Board>();
            while (boardEnumerator.MoveNext())
            {
                var board = new Board();
                board.LoadBoard(boardEnumerator);
                boards.Add(board);
            }

            var winner = false;
            var unmarkedSum = 0;
            foreach (var number in numbersDrawn)
            {

                Console.WriteLine("Number Drawn:{0}", number);

                foreach (var board in boards)
                {
                    board.MarkBoard(number);
                }

                foreach (var board in boards)
                {
                    winner = board.CheckBoardWinner();
                    if (winner)
                    {
                        unmarkedSum = board.GetUnmarkedSum();
                        break;
                    }
                }

                if (winner)
                {
                    Console.WriteLine("Winner:{0}, Sum:{1}", unmarkedSum, unmarkedSum * number);
                    break;
                }
            }
        }

        internal static void DoWork()
        {
            int[,] board = new int[5,5];
        }


        public static void Question() 
        {
            var lines = File.GetTextFileValues("./Day4/input.csv");
            PlayBoard(lines);

        }
    }
}