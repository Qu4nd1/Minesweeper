using MineSweeper.Features;
namespace MineSweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MineField field = new MineField();
            field.DrawField(5, 5, 5, 5);
        }
    }
}
