using static MineSweeper.Display.SuperConsole;

namespace MineSweeper.Features
{
    static class EmptyBlock
    {
        static public void DrawEnterFlag(int visualX, int visualY, int arrayX, int arrayY)
        {
            // Placement de drapeau si case vide
            DrawInColorAt(visualX - 1, visualY, "RAS", ConsoleColor.White);
            Game.visualArray[arrayX, arrayY] = 'R';
        }
    }
}
