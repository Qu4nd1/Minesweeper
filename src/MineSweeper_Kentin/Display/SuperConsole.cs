using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Display
{
    public static class SuperConsole
    {
        public static void LinesJump(int nbr)
        {
            for (int i = 0; i < nbr; i++)
                Console.WriteLine("");
        }
        public static void DrawInColor(string phrase, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(phrase);
            Console.ResetColor();
        }
        public static void DrawInColorAt(int x, int y, string phrase, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(phrase);
            Console.ResetColor();
        }
        public static void DrawAtString(int x, int y, string phrase)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(phrase);
        }
        public static void DrawAtCenterString(int x, int y, int width, string phrase)
        {
            int centerX = x + (width / 2) - (phrase.Length / 2);
            Console.SetCursorPosition(centerX, y);
            Console.Write(phrase);
        }
        public static void DrawAtChar(int x, int y, char character)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(character);
        }
        public static void ClearAt(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }
        public static void ClearAtForLength(int x, int y, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(x + i, y);
                Console.Write(' ');
            }
        }
        public static void DrawHorizontalLine(int startX, int y, int length, char character)
        {
            for (int x = startX; x < startX + length; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(character);
            }
        }
        public static void DrawVerticalLine(int x, int startY, int length, char character)
        {
            for (int y = startY; y < startY + length; y++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(character);
            }
        }
    }
}
