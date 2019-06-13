using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toes
{
    class PlayerUser
    {
        private int[] playerActualPos = new int[2];
        private char[,] tempGameTable;
        private int[] actualPos = new int[2];
        private int[] choosedCoords = new int[2]; // step koordináta, propertit neki!
        private char actualSymbol;
        private char setBackChar = char.MinValue;


        public PlayerUser(Board board, char actualSymbol)
        {
            Display.DisplayInfoForMove();

            this.actualSymbol = actualSymbol;
            tempGameTable = GenerateTempTable(board);
            actualPos[0] = tempGameTable.GetLength(0) / 2;
            actualPos[1] = tempGameTable.GetLength(1) / 2;

            do
            {
                UserInputForStep();

            } while (!IsCoordFreeFromSymbol(board));
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
        public void UserInputForStep()
        {
            bool areTheCoordsChoosed = false;
            int[] cursorStart = new int[2] { (tempGameTable.GetLength(0) / 2), (tempGameTable.GetLength(1) / 2) };
            int[] actualPosLatest = new int[2];
            bool setBack = false;
            int[] setBackCoords = new int[2];

            do
            {
                setBack = false;
                if (tempGameTable[cursorStart[0], cursorStart[1]] == 'X' || tempGameTable[cursorStart[0], cursorStart[1]] == 'O')
                {
                    setBackCoords[0] = cursorStart[0];
                    setBackCoords[1] = cursorStart[1];
                    setBack = true;
                    setBackChar = tempGameTable[cursorStart[0], cursorStart[1]];
                }
                tempGameTable[cursorStart[0], cursorStart[1]] = '\u2022';
                Display.DisplayTheTable(tempGameTable);
                actualPosLatest[0] = actualPos[0]; actualPosLatest[1] = actualPos[1];


                PlayerStep(cursorStart);


                Display.ClearTheUI();
                areTheCoordsChoosed = AreWeGotTheCoords(areTheCoordsChoosed, actualPosLatest);

                if (setBack == true)
                {
                    tempGameTable[setBackCoords[0], setBackCoords[1]] = setBackChar;
                }



            } while (areTheCoordsChoosed == false);

            choosedCoords[0] = actualPos[0];
            choosedCoords[1] = actualPos[1];
        }
        private void PlayerStep(int[] cursorStart)
        {
            char movement;
            movement = Console.ReadKey().KeyChar;
            actualPos = CheckMove(movement, cursorStart);



        }
        private int[] CheckMove(char movement, int[] cursorStart)
        {
            if (movement == 'w')
            {
                tempGameTable[cursorStart[0], cursorStart[1]] = '-';
                cursorStart[0]--;
                return cursorStart;
            }
            else if (movement == 's')
            {
                tempGameTable[cursorStart[0], cursorStart[1]] = '-';
                cursorStart[0]++;
                return cursorStart;
            }
            else if (movement == 'a')
            {
                tempGameTable[cursorStart[0], cursorStart[1]] = '-';
                cursorStart[1]--;
                return cursorStart;
            }
            else if (movement == 'd')
            {
                tempGameTable[cursorStart[0], cursorStart[1]] = '-';
                cursorStart[1]++;
                return cursorStart;
            }
            else if (movement == ' ')
            {
                return cursorStart;
            }
            return cursorStart;
        }
        private bool AreWeGotTheCoords(bool isTheCoordsChoosed, int[] actualPosLatest)
        {
            if (actualPos[0] == actualPosLatest[0] && actualPos[1] == actualPosLatest[1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void GenerateBoardTable(Board board)
        {
            for (int i = 0; i < board.GameTable.GetLength(0); i++)
            {
                for (int j = 0; j < board.GameTable.GetLength(1); j++)
                {
                    board.GameTable[i, j] = tempGameTable[i, j];
                }
            }
        }
        private bool IsCoordFreeFromSymbol(Board board)
        {
            if (board.GameTable[choosedCoords[0], choosedCoords[1]] != setBackChar)
            {
                board.GameTable[choosedCoords[0], choosedCoords[1]] = actualSymbol;
                return true;
            }
            else
            {
                Display.DisplayYourCoordsAreAlreadyUsed();
                return false;
            }
        }
        private bool CheckBorders(int[] actualPos)
        {
            if (tempGameTable[actualPos[0], actualPos[1]] != '-')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void BackToTheMiddle(int[] coord)
        {
            coord[0] = tempGameTable.GetLength(0) / 2;
            coord[1] = tempGameTable.GetLength(1) / 2;
        }

        public int[] ChoosedCoords { get { return choosedCoords; } }
        
    }
}