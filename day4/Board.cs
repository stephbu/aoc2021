namespace Aoc2021.Day4
{

    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utility;

    internal struct Board {

        internal bool Playable = true;

        private int[,] boardData = new int[5,5];
        internal void LoadBoard(IEnumerator<string> lineSource) {
            for(var row = 0; row < 5; row++) {
                var line = lineSource.Current.Split(" ").Where(v => !string.IsNullOrEmpty(v)).ToArray();
                for(var col = 0; col < 5; col++) {
                    this.boardData[row,col] = int.Parse(line[col]);                    
                }

                if(!lineSource.MoveNext()) {
                    break;
                }
            }
        }

        internal void MarkBoard(int number) {
            var boardMarking = boardData.CoordinatesOf(number);
            if(boardMarking.Item1 > -1 && boardMarking.Item2 > -1) {
                this.boardData[boardMarking.Item1, boardMarking.Item2] = -1;
            }
        }

        internal int GetUnmarkedSum() {
            var sum = 0;
            for(int row = 0; row < 5; row++) {
                for(int col = 0; col < 5; col++) {
                    if(this.boardData[row,col] > -1) {
                        sum = sum + this.boardData[row,col];
                    }
                }
            }
            return sum;
        }

        internal bool CheckBoardWinner() {
            for(int row = 0; row < 5; row++) {
                for(int col = 0; col < 5; col++) {
                    if(this.boardData[row,col] != -1) {
                        break;
                    }
                    if(col == 4) return true;
                }
            }

            for(int col = 0; col < 5; col++) {
                for(int row = 0; row < 5; row++) {
                    if(this.boardData[row,col] != -1) {
                        break;
                    }
                    if(row == 4) return true;
                }
            }

            return false;
        }    
    }
}