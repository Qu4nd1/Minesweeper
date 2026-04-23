using MineSweeper.Display;
namespace MineSweeper.Features
{
    public class Mine
    {
        public int NumberOfMines(Menu menu, MineField field)
        {
            if (menu.SelectedDifficulty == "Easy")
            {
                field.MineFillingPercentage(0.10);
                return (field.Surface * 10) / 100;
            }
            else if (menu.SelectedDifficulty == "Medium")
            {
                field.MineFillingPercentage(0.25);
                return (field.Surface * 25) / 100;
            }
            else
            {
                field.MineFillingPercentage(0.40);
                return (field.Surface * 40) / 100;
            }
        }
    }
}
