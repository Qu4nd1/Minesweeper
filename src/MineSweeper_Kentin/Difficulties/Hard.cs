using MineSweeper.Features;

namespace MineSweeper.Difficulties
{
    public class Hard : Easy
    {
        private int _nbrMines;
        public Hard (MineField field, int nbrMines) 
            : base (field, nbrMines)
        {
            _nbrMines = nbrMines;
        }
    }
}
