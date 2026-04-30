using MineSweeper.Display;
namespace MineSweeper.Features
{
    public class Mine
    {
        public int NbrMines { get { return _nbrMines; } }
        private int _nbrMines;
        public int NumberOfMines(Menu menu, MineField field)
        {
            if (menu.SelectedDifficulty == "Easy")
            {
                _nbrMines = (field.Surface * 10) / 100;
                field.MineFilling(_nbrMines);
                return _nbrMines;
            }
            else if (menu.SelectedDifficulty == "Medium")
            {
                _nbrMines = (field.Surface * 25) / 100;
                field.MineFilling(_nbrMines); 
                return _nbrMines;
            }
            else
            {
                _nbrMines = (field.Surface * 40) / 100;
                field.MineFilling(_nbrMines);
                return _nbrMines;
            }
        }
    }
}
