using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toes
{
    class AiStep
    {
        private int[] playerActualPos = new int[2];
        private char[,] tempGameTable;
        private int[] actualPos = new int[2];
        private int[] choosedCoords = new int[2];
        private char actualSymbol;
        private char enemySymbol;


        public AiStep(Board board, char actualSymbol)
        {
            this.actualSymbol = actualSymbol;
            GenerateEnemySymbol();
            tempGameTable = GenerateTempTable(board);

            choosedCoords = GenerateStep();

            board.GameTable[choosedCoords[0], choosedCoords[1]] = actualSymbol;
        }
        private char[,] GenerateTempTable(Board board)
        {
            char[,] tempGameTable = new char[board.GameTable.GetLength(0), board.GameTable.GetLength(1)];

            for (int i = 0; i < board.GameTable.GetLength(0); i++)
            {
                for (int j = 0; j < board.GameTable.GetLength(1); j++)
                {
                    tempGameTable[i, j] = board.GameTable[i, j];
                }
            }

            return tempGameTable;
        }
        private int[] GenerateStep()
        {
            for (int i = 2; i < tempGameTable.GetLength(0) - 2; i++)
            {
                for (int j = 2; j < tempGameTable.GetLength(1) - 2; j++)
                {
                    if (MiddleCheck(i, j) == true)  //KÉSZ (középre illesztést csekkolja)
                    {
                        choosedCoords[0] = i;
                        choosedCoords[1] = j;
                        return choosedCoords;
                    }
                    else if (CheckThird(i, j) == true) // ha kettő után teszi 3. nak
                    {
                        choosedCoords[0] = i;
                        choosedCoords[1] = j;
                        return choosedCoords;
                    }
                    else if (BestStep(i, j) == true) // ha egy symbol van csak
                    {
                        choosedCoords[0] = i;
                        choosedCoords[1] = j;
                        return choosedCoords;
                    }
                    else if (FirstStep(i, j) == true) // első lépés, lehetőleg az ellenfél mellé
                    {
                        choosedCoords[0] = i;
                        choosedCoords[1] = j;
                        return choosedCoords;
                    }


                }
            }

            choosedCoords[0] = StaticRandom.Instance.Next(3, tempGameTable.GetLength(0) - 3);
            choosedCoords[1] = StaticRandom.Instance.Next(3, tempGameTable.GetLength(1) - 3);
            return choosedCoords;
        }
        private bool MiddleCheck(int i, int j)
        {
            if (CheckAroundMiddle(i, j) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckThird(int i, int j)
        {
            return false;
        } //
        private bool BestStep(int i, int j)
        {
            return false;
        }  //
        private bool FirstStep(int i, int k)
        {
            if (CheckAroundOneEnemySymbol(i, j) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void GenerateEnemySymbol()
        {
            if (actualSymbol == 'X')
            {
                enemySymbol = 'O';
            }
            else
            {
                enemySymbol = 'X';
            }
        }

        private bool CheckAroundMiddle(int i, int j)
        {
            if (CheckHorizontal(i, j) == true || CheckVertical(i, j) == true || CheckDiagonalLeft(i, j) == true || CheckDiagonalRight(i, j) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckVertical(int i, int j)
        {
            if (tempGameTable[i - 1, j] == actualSymbol && tempGameTable[i, j] == '-' && tempGameTable[i + 1, j] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool CheckHorizontal(int i, int j)
        {
            if (tempGameTable[i, j - 1] == actualSymbol && tempGameTable[i, j] == '-' && tempGameTable[i, j + 1] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool CheckDiagonalLeft(int i, int j)
        {
            if (tempGameTable[i - 1, j - 1] == actualSymbol && tempGameTable[i, j] == '-' && tempGameTable[i, j + 1] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool CheckDiagonalRight(int i, int j)
        {
            if (tempGameTable[i - 1, j + 1] == actualSymbol && tempGameTable[i, j] == '-' && tempGameTable[i + 1, j - 1] == actualSymbol)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool CheckAroundOneEnemySymbol(int i, int j)
        {

        }
    }
}

// class radar -> paraméterek: gametable, i, j, middle v. end stb. a paraméter alapján indul a függvény amit a konstukrtor indít
