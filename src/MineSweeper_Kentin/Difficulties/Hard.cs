using MineSweeper.Features;

namespace MineSweeper.Difficulties
{
    public class Hard : Easy
    {
        private int _nbrMines;
        public Hard (MineField field) : base (field)
        {
            _nbrMines = (field.Surface * 40) / 100;
        }
    }
}
