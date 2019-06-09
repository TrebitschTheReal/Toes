using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toes
{
    class Radar
    {
        Board board;

        public Radar(Board board)
        {
            this.board = board;

        }

        public int[] CheckAround()
        {
            int[] shotCoords = new int[2];

            for (int i = 2; i < board.GameTable.GetLength(0)-2; i++)
            {
                for (int j = 2; j < board.GameTable.GetLength(1)-2; j++)
                {
                    int verticalBefore = i - 1;
                    int verticalAfter = i + 1;

                    int horizontalBefore = j - 1;
                    int horizontalAfter = j + 1;

                    int diagonalLeftUpY = i - 1;
                    int diagonalLeftUpX = j - 1;
                    int diagonalLeftDownY = i + 1;
                    int diagonalLeftDownX = j - 1;     

                    int diagonalRightUpY = i - 1;
                    int diagonalRightUpX = j + 1;
                    int diagonalRightDownY = i + 1;
                    int diagonalRightDownX = j + 1;

                    if(MiddleCheck(verticalBefore, verticalAfter, horizontalBefore, horizontalAfter, diagonalLeftUpY, diagonalLeftUpX, diagonalLeftDownY, diagonalLeftDownX, diagonalRightUpY, diagonalRightUpX, diagonalRightDownY, diagonalRightDownX) == true)
                    {
                        shotCoords[0] = i;
                        shotCoords[1] = j;
                        return shotCoords;
                    }
                }
            }
        }

        private bool MiddleCheck(int verticalBefore, int verticalAfter, int horizontalBefore, int horizontalAfter, int diagonalLeftUpY, int diagonalLeftUpX, int diagonalLeftDownY, int diagonalLeftDownX, int diagonalRightUpY, int diagonalRightUpX, int diagonalRightDownY, int diagonalRightDownX)
        {

        }




    }
}
