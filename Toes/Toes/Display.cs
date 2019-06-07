using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toes
{
    static class Display
    {
        private static int coordForWarningX = 40;
        private static int coordForWarningY = 3;

        private static int coordForWinX = 40;
        private static int coordForWinY = 5;

        private static int coordForInformX = 2;
        private static int coordForInformY = 25;


        public static void DisplayTheTable (char[,] gameTable)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < gameTable.GetLength(0); i++)
            {
                for (int j = 0; j < gameTable.GetLength(1); j++)
                {
                    Console.Write(gameTable[i, j]);
                }
                Console.WriteLine();
            }
        } 
        public static void DisplayYourCoordsAreAlreadyUsed()
        {
            Console.SetCursorPosition(coordForWarningX, coordForWarningY);
            Console.Write("Ide nem tudsz tenni, mert már szerepel O vagy X");
        }
        public static void DisplayInfoForMove()
        {
            Console.SetCursorPosition(coordForInformX, coordForInformY);
            Console.WriteLine("W: up, S: down, A: left, D: right    Space: action");

        }
        public static void DisplaySomeoneWin(char actualSymbol)
        {
            Console.SetCursorPosition(coordForWinX, coordForWinY);
            Console.WriteLine("{0} nyert!", actualSymbol);
        }
        public static void ClearTheUI()
        {
            Console.SetCursorPosition(coordForWarningX, coordForWarningY);
            Console.Write("                                                                       ");
        }
    }
}
