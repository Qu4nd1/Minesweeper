using MineSweeper.Features;

namespace MineSweeper.Difficulties
{
    public class Easy
    {
        private int _nbrMines;
        public Easy(MineField field) 
        {
            _nbrMines = (field.Surface * 10)/100;

        }
    }
}
