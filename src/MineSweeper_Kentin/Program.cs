using MineSweeper.Features;
using MineSweeper.Display;
namespace MineSweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            MineField field = new MineField();
            Mine mine = new Mine();
            menu.Presentation();
            field.FieldCreation(menu, mine, field);
            menu.RunInteractive(menu, field, mine);
            field.MineFilling(mine.NumberOfMines(menu, field));
            field.DrawField(menu, field, mine);
            Game.Play(field, mine);
        }
    }
}
