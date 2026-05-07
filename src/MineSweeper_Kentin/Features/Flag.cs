using static MineSweeper.Display.SuperConsole;

namespace MineSweeper.Features
{
    static class Flag
    {
        static public void DrawEnterFlag(int visualX, int visualY, int arrayX, int arrayY)
        {
            // Placement de drapeau si case vide
            Console.BackgroundColor = ConsoleColor.Yellow;
            DrawInColorAt(visualX - 1, visualY, " F ", ConsoleColor.DarkYellow);
            Game.visualArray[arrayX, arrayY] = 'F';
        }
        static public void ClearFlag(int visualX, int visualY, int arrayX, int arrayY)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            DrawAtString(visualX - 1, visualY, "   ");
            Console.ResetColor();
            Game.visualArray[arrayX, arrayY] = ' ';
        }
    }
}
