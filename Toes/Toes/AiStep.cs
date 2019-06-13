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
            var radar = new Radar(board, actualSymbol);

            choosedCoords = radar.CheckAround();

            return choosedCoords;
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
    }
}

/* 
    class radar -> paraméterek: gametable, i, j, middle v. end stb. a paraméter alapján indul a függvény amit a konstukrtor indít

    elv: a legnagyobb nyerési esélytől haladni a legkisebbig: pl: nyerés egy szimbólummal a sorozat közepére, vagy harmadiknak
    másodiknak tenni a szimbólumot, hogy elősegítsük az első lépést. Ha nincs szimbólum akkor lehetőleg az ellenfél mellé
    ha elsők vagyunk random valahová.

    prioritás: middle -> third -> second -> firstWithEnemy (ellenség mellé) -> firstWithoutEnemy (random akárhová)



    */
