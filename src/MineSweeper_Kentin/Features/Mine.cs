using MineSweeper.Display;
namespace MineSweeper.Features
{
    public class Mine
    {
        public int NumberOfMines(Menu menu, MineField field)
        {
            if (menu.SelectedDifficulty == "Easy")
            {
                return (field.Surface * 10) / 100;
            }
            else if (menu.SelectedDifficulty == "Medium")
            {
                return (field.Surface * 25) / 100;
            }
            else
            {
                return (field.Surface * 40) / 100;
            }
        }
    }
}
