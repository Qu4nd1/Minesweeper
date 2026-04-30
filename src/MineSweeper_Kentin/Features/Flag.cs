using static MineSweeper.Display.SuperConsole;

namespace MineSweeper.Features
{
    static class Flag
    {
        public static char[,] flagArray;
        static public void FlagArrayInit(MineField field)
        {
            flagArray = new char[field.nbrCol, field.nbrRow];
        }
        static public void DrawEnterFlag(int visualX, int visualY, int arrayX, int arrayY)
        {
            // Placement de drapeau si case vide
            DrawInColorAt(visualX, visualY, "F", ConsoleColor.Yellow);
            Flag.flagArray[arrayX, arrayY] = 'F';
            
        }
        static public void ClearFlag(int visualX, int visualY, int arrayX, int arrayY)
        {
            DrawAtChar(visualX, visualY, ' ');
            Flag.flagArray[arrayX, arrayY] = ' ';
        }
    }
}
