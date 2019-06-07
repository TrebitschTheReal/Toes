using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toes
{
    class GameManager
    {
        private char actualSymbol;
        private char latestSymbol;
        private char playerX = 'X';
        private char playerO = 'O';

        public void GameStart()
        {
            var board = new Board();
            GenerateStarterSymbol();

            while (true)
            {
                ChangeSymbols();
                var player = new PlayerUser(board, actualSymbol);
                Display.DisplayTheTable(board.GameTable);
                ChangeSymbols();
                var ai = new AiStep(board, actualSymbol);
            }
        }
        private void ChangeSymbols()
        {
            if (actualSymbol == playerX)
            {
                actualSymbol = playerO;
                latestSymbol = playerX;
            }
            else
            {
                actualSymbol = playerX;
                latestSymbol = playerO;
            }
        }
        private void GenerateStarterSymbol()
        {
            int dice = StaticRandom.Instance.Next(1, 3);
            if (dice == 1)
            {
                actualSymbol = playerX;
            }
        }
    }
}
