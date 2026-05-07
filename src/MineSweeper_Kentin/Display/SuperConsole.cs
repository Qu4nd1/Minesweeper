using MineSweeper.Features;

namespace MineSweeper.Display
{
    public static class SuperConsole
    {
        public static char visualFlag = 'F';
        public static char emptyCase = 'R';
        public static char flagedMine = 'A';
        public static char undiscoveredMine = 'M';
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
        public static void DrawCusor(int visualX, int visualY, int arrayX, int arrayY)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            visualX = visualX - 1;
            Console.SetCursorPosition(visualX, visualY);
            if (Game.visualArray[arrayX, arrayY] == visualFlag)
                DrawInColorAt(visualX, visualY, " F ", ConsoleColor.DarkYellow);
            else if (Game.visualArray[arrayX, arrayY] == flagedMine)
                DrawInColorAt(visualX, visualY, " M ", ConsoleColor.Red);
            else if (Game.visualArray[arrayX, arrayY] == emptyCase)
                DrawInColorAt(visualX, visualY, "RAS", ConsoleColor.White);
            else
                Console.Write("   ");
            Console.ResetColor();
        }
        public static void ClearCusor(int visualX, int visualY, int arrayX, int arrayY)
        {
            visualX = visualX - 1;
            Console.SetCursorPosition(visualX, visualY);
            if (Game.visualArray[arrayX, arrayY] == visualFlag)
                Console.Write(" F ");
            else if (Game.visualArray[arrayX, arrayY] == flagedMine)
                Console.Write(" M ");
            else if (Game.visualArray[arrayX, arrayY] == emptyCase)
                Console.Write("RAS");
            else
                Console.Write("   ");
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
