using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toes
{
    class Board
    {
        private const int x = 25;
        private const int y = 40;
        private char[,] gameTable;
        private int[] coords = new int[2];

        public Board()
        {
            Console.OutputEncoding = Encoding.UTF8;
            gameTable = GenerateTheTable(x, y);
        }
        private char[,] GenerateTheTable(int x, int y)
        {
            char[,] gameTable = new char[x, y];

            for (int i = 2; i < gameTable.GetLength(0) - 2; i++)
            {
                gameTable[i, 1] = '|';
            }

            for (int i = 2; i < gameTable.GetLength(1) - 2; i++)
            {
                gameTable[1, i] = '_';
            }
            for (int i = 2; i < gameTable.GetLength(1) - 2; i++)
            {

                gameTable[gameTable.GetLength(0) - 2, i] = '\u035e';
            }

            for (int i = 2; i < gameTable.GetLength(0) - 2; i++)
            {
                for (int j = 2; j < gameTable.GetLength(1) - 2; j++)
                {
                    gameTable[i, j] = '-';
                }
            }

            for (int i = 2; i < gameTable.GetLength(0) - 2; i++)
            {
                gameTable[i, gameTable.GetLength(1) - 2] = '|';
            }

            return gameTable;
        }
        public void DisplayTheTable()
        {
            for (int i = 0; i < gameTable.GetLength(0); i++)
            {
                for (int j = 0; j < gameTable.GetLength(1); j++)
                {
                    Console.Write(gameTable[i, j]);
                }
                Console.WriteLine();
            }
        }
        public char[,] GameTable
        {
            get { return gameTable; }
            set { value = gameTable; }
        }
    }
}
