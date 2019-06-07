using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toes
{
    static class Umpire
    {
        public static bool CheckWin(Board board, char actualSymbol)
        {
            for (int i = 2; i < board.GameTable.GetLength(0)-2; i++)
            {
                for (int j = 2; j < board.GameTable.GetLength(1)-2; j++)
                {
                    if (CheckAround(board, actualSymbol, i, j) == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool CheckAround(Board board, char actualSymbol, int posVer, int posHor)
        {
            if (CheckHorizontal(board, actualSymbol, posVer, posHor) == true || CheckVertical(board, actualSymbol, posVer, posHor) == true || CheckDiagonalLeft(board, actualSymbol, posVer, posHor) == true || CheckDiagonalRight(board, actualSymbol, posVer, posHor) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckHorizontal(Board board, char actualSymbol, int posVer, int posHor)
        {
            if (board.GameTable[posVer, posHor - 1] == actualSymbol && board.GameTable[posVer,posHor] == actualSymbol && board.GameTable[posVer, posHor + 1] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private static bool CheckVertical(Board board, char actualSymbol, int posVer, int posHor)
        {
            if (board.GameTable[posVer - 1, posHor] == actualSymbol && board.GameTable[posVer, posHor] == actualSymbol && board.GameTable[posVer + 1, posHor] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private static bool CheckDiagonalLeft(Board board, char actualSymbol, int posVer, int posHor)
        {
            if (board.GameTable[posVer - 1, posHor - 1] == actualSymbol && board.GameTable[posVer, posHor] == actualSymbol && board.GameTable[posVer + 1, posHor + 1] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private static bool CheckDiagonalRight(Board board, char actualSymbol, int posVer, int posHor)
        {
            if (board.GameTable[posVer - 1, posHor + 1] == actualSymbol && board.GameTable[posVer, posHor] == actualSymbol && board.GameTable[posVer + 1, posHor - 1] == actualSymbol)
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









//class Umpire
//{
//    private bool doWin;
//    private int posVer;
//    private int posHor;
//    private char actualSymbol;
//    private char[,] tempGameTable;

//    public Umpire(Board board, int[] coordsToCheck, char actualSymbol)
//    {
//        tempGameTable = board.GameTable;
//        posVer = coordsToCheck[0];
//        posHor = coordsToCheck[1];
//        this.actualSymbol = actualSymbol;
//    }
//    private bool CheckWin()
//    {
//        if (CheckHorizontal() == true || CheckVertical() == true || CheckDiagonalLeft() == true || CheckDiagonalRight() == true)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }

//    private bool CheckHorizontal()
//    {
//        if (tempGameTable[posVer, posHor - 1] == actualSymbol && tempGameTable[posVer, posHor + 1] == actualSymbol)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }

//    }
//    private bool CheckVertical()
//    {
//        if (tempGameTable[posVer-1, posHor] == actualSymbol && tempGameTable[posVer+1, posHor] == actualSymbol)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }

//    }
//    private bool CheckDiagonalLeft()
//    {
//        if (tempGameTable[posVer-1, posHor - 1] == actualSymbol && tempGameTable[posVer+1, posHor + 1] == actualSymbol)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }

//    }
//    private bool CheckDiagonalRight()
//    {
//        if (tempGameTable[posVer-1, posHor + 1] == actualSymbol && tempGameTable[posVer+1, posHor- 1] == actualSymbol)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }

//    }

//    public bool DoWin { get { return CheckWin(); } }


//}