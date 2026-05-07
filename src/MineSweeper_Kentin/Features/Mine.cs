using MineSweeper.Display;
using static MineSweeper.Display.SuperConsole;
namespace MineSweeper.Features
{
    public class Mine
    {
        public int NbrMines { get { return _nbrMines; } }
        private int _nbrMines;
        public char undiscoveredMine = 'M';
        public char flagedMine = 'A';
        public int NumberOfMines(Menu menu, MineField field)
        {
            if (menu.SelectedDifficulty == "Easy")
            {
                _nbrMines = (field.Surface * 10) / 100;
                return _nbrMines;
            }
            else if (menu.SelectedDifficulty == "Medium")
            {
                _nbrMines = (field.Surface * 25) / 100;
                return _nbrMines;
            }
            else
            {
                _nbrMines = (field.Surface * 40) / 100;
                return _nbrMines;
            }
        }
        public void DrawEnterMine(int visualX, int visualY, int arrayX, int arrayY)
        {
            // Placement de drapeau si case vide
            DrawInColorAt(visualX - 1, visualY, " M ", ConsoleColor.Red);
            Game.visualArray[arrayX, arrayY] = flagedMine;
        }
    }
}
