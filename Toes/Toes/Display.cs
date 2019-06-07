using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toes
{
    static class Display
    {
        private static int coordX = 40;
        private static int coordY = 3;


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
            Console.SetCursorPosition(coordX, coordY);
            Console.Write("Ide nem tudsz tenni, mert már szerepel O vagy X");
        }
        public static void ClearTheUI()
        {
            Console.SetCursorPosition(coordX, coordY);
            Console.Write("                                                                       ");
        }
    }
}
