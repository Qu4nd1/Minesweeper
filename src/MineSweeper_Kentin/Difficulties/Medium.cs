using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineSweeper.Features;

namespace MineSweeper.Difficulties
{
    public class Medium : Easy
    {
        private int _nbrMines;
        public Medium(MineField field) : base(field)
        {
            _nbrMines = (field.Surface * 25) / 100;
        }
    }
}
