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
            menu.Presentation();
            field.FieldCreation();
            menu.RunInteractive(field);
            field.DrawField(menu);
        }
    }
}
