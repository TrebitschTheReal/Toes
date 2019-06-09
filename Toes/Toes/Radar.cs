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
        char actualSymbol;

        public Radar(Board board, char actualSymbol)
        {
            this.board = board;
            this.actualSymbol = actualSymbol;
        }

        public int[] CheckAround()
        {
            int[] shotCoords = new int[2];

            for (int i = 2; i < board.GameTable.GetLength(0)-2; i++)
            {
                for (int j = 2; j < board.GameTable.GetLength(1)-2; j++)
                {
                    if(MiddleCheck(i,j) == true)
                    {
                        shotCoords[0] = i;
                        shotCoords[1] = j;
                        return shotCoords;
                    }

                    else if(ThirdCheckVerticalStart(i,j) == true)
                    {
                        shotCoords[0] = i-1;
                        shotCoords[1] = j;
                        return shotCoords;
                    }
                    else if(ThirdCheckVerticalEnd(i,j) == true)
                    {
                        shotCoords[0] = i + 1;
                        shotCoords[1] = j;
                        return shotCoords;
                    }
                    else if(ThirdCheckHorizontalStart(i,j) == true)
                    {
                        shotCoords[0] = i;
                        shotCoords[1] = j - 1;
                        return shotCoords;
                    }
                    else if(ThirdCheckHorizontalEnd(i,j)== true)
                    {
                        shotCoords[0] = i;
                        shotCoords[1] = j + 1;
                        return shotCoords;
                    }
                    else if(ThirdCheckDiagonalLeftStart(i,j) == true)
                    {
                        shotCoords[0] = i - 1;
                        shotCoords[1] = j - 1;
                        return shotCoords;
                    }
                    else if (ThirdCheckDiagonalLeftEnd(i, j) == true)
                    {
                        shotCoords[0] = i + 1;
                        shotCoords[1] = j + 1;
                        return shotCoords;
                    }
                    else if(ThirdCheckDiagonalRightStart(i,j) == true)
                    {
                        shotCoords[0] = i - 1;
                        shotCoords[1] = j + 1;
                        return shotCoords;
                    }
                    else if(ThirdCheckDiagonalRightEnd(i,j) == true)
                    {
                        shotCoords[0] = i + 1;
                        shotCoords[1] = j - 1;
                        return shotCoords;
                    }

                    else if(SecondCheckVerticalStart(i,j) == true)
                    {

                    }



                }
            }
            shotCoords[0] = StaticRandom.Instance.Next(2, 30);
            shotCoords[1] = StaticRandom.Instance.Next(2, 30);
            return shotCoords;
        }

        private bool MiddleCheck(int i, int j)
        {
            if(board.GameTable[i-1,j] == actualSymbol && board.GameTable[i,j] == '-' && board.GameTable[i+1,j] == actualSymbol)
            {
                return true;
            }
            else if (board.GameTable[i , j-1] == actualSymbol && board.GameTable[i, j] == '-' && board.GameTable[i, j+1] == actualSymbol)
            {
                return true;
            }
            else if (board.GameTable[i-1, j - 1] == actualSymbol && board.GameTable[i, j] == '-' && board.GameTable[i+1, j + 1] == actualSymbol)
            {
                return true;
            }
            else if (board.GameTable[i-1, j + 1] == actualSymbol && board.GameTable[i, j] == '-' && board.GameTable[i+1, j - 1] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ThirdCheckVerticalStart(int i, int j)
        {
            if (board.GameTable[i - 1, j] == '-' && board.GameTable[i, j] == actualSymbol && board.GameTable[i + 1, j] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ThirdCheckVerticalEnd(int i, int j)
        {
            if (board.GameTable[i - 1, j] == actualSymbol && board.GameTable[i, j] == actualSymbol && board.GameTable[i + 1, j] == '-')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ThirdCheckHorizontalStart(int i, int j)
        {
            if (board.GameTable[i, j - 1] == '-' && board.GameTable[i, j] == actualSymbol && board.GameTable[i, j + 1] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ThirdCheckHorizontalEnd(int i, int j)
        {
            if (board.GameTable[i, j - 1] == actualSymbol && board.GameTable[i, j] == actualSymbol && board.GameTable[i, j + 1] == '-')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ThirdCheckDiagonalLeftStart(int i, int j)
        {
            if (board.GameTable[i - 1, j - 1] == '-' && board.GameTable[i, j] == actualSymbol && board.GameTable[i + 1, j + 1] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ThirdCheckDiagonalLeftEnd(int i, int j)
        {
            if (board.GameTable[i - 1, j - 1] == actualSymbol && board.GameTable[i, j] == actualSymbol && board.GameTable[i + 1, j + 1] == '-')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ThirdCheckDiagonalRightStart(int i, int j)
        {
            if (board.GameTable[i - 1, j + 1] == '-' && board.GameTable[i, j] == actualSymbol && board.GameTable[i + 1, j - 1] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ThirdCheckDiagonalRightEnd(int i, int j)
        {
            if (board.GameTable[i - 1, j + 1] == actualSymbol && board.GameTable[i, j] == actualSymbol && board.GameTable[i + 1, j - 1] == '-')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool SecondCheckVerticalStart(int i, int j)
        {
            if (board.GameTable[i - 1, j] == '-' && board.GameTable[i, j] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool SecondCheckVerticalMiddle(int i, int j)
        {
            if (board.GameTable[i - 1, j] == actualSymbol && board.GameTable[i, j] == '-')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool SecondCheckVerticalEnd(int i, int j)
        {
            if (board.GameTable[i + 1, j] == '-' && board.GameTable[i, j] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
