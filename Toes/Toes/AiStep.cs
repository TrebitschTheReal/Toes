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


        public AiStep(Board board, char actualSymbol)
        {
            this.actualSymbol = actualSymbol;
            tempGameTable = GenerateTempTable(board);
            int posOne = StaticRandom.Instance.Next(3, 15);
            int posTwo = StaticRandom.Instance.Next(3, 20);
            board.GameTable[posOne, posTwo] = actualSymbol;
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
    }
}
