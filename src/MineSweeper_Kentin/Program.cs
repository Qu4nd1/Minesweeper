using MineSweeper.Features;
using MineSweeper.Display;
namespace MineSweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MineField field = new MineField();
            field.FieldCreation();
            Menu menu = new Menu();
            menu.RunInteractive();
            field.DrawField(5, 5, 5, 3);
        }
    }
}
