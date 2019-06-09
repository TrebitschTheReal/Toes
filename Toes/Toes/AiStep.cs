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
        private Board board;


        public AiStep(Board board, char actualSymbol)
        {
            this.board = board;
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
            var radar = new Radar(board);

            choosedCoords = radar.CheckAround();


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

/* 
    class radar -> paraméterek: gametable, i, j, middle v. end stb. a paraméter alapján indul a függvény amit a konstukrtor indít
    pl:

    elv: a legnagyobb nyerési esélytől haladni a legkisebbig: pl: nyerés egy szimbólummal a sorozat közepére, vagy harmadiknak
    másodiknak tenni a szimbólumot, hogy elősegítsük az első lépést. Ha nincs szimbólum akkor lehetőleg az ellenfél mellé
    ha elsők vagyunk random valahová.

    prioritás: middle -> third -> second -> firstWithEnemy (ellenség mellé) -> firstWithoutEnemy (random akárhová)

    A radar konstruktora lefuttatja a paraméterben megkapott private függvényét ami visszaad majd egy boolt VAGY lefut az összes prioritás szerint,
    ahol true, ott megszakad és return

  CheckStyle = middle
  var radar = new Radar(i, j, gameTable, CheckStyle);



    */
