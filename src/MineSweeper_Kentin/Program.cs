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
            field.FieldCreation();
            Flag.FlagArrayInit(field);
            menu.RunInteractive(menu, field, mine);
            field.DrawField(menu, field, mine);
            Game.Play(field);
        }
    }
}
