using static MineSweeper.Display.SuperConsole;

namespace MineSweeper.Features
{
    static class Game
    {
        static int oldX;
        static int oldY;
        private static bool gameEnd = false;
        static public void Play(MineField field)
        {

            Init(field);
            do
            {
                ActionChoice(field);
            } while (!gameEnd);
        }
        static private void Init(MineField field)
        {
            field.X = 7;
            field.Y = 13;
        }
        static public void ActionChoice(MineField field)
        {

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if ((keyInfo.Key != ConsoleKey.Escape) || (keyInfo.Key != ConsoleKey.Spacebar))
            {
                Console.SetCursorPosition(field.X, field.Y);
                DrawInColor("_", ConsoleColor.Green);
                Move(field, keyInfo);
                ClearAt(oldX, oldY);
            }
            else if ((keyInfo.Key == ConsoleKey.Spacebar))
            {

            }
            
        }
        static public void Move(MineField field, ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    oldX = field.X;
                    oldY = field.Y;
                    field.Y -= 2;
                    break;
                case ConsoleKey.DownArrow:
                    oldX = field.X;
                    oldY = field.Y;
                    field.Y += 2;
                    break;
                case ConsoleKey.LeftArrow:
                    oldX = field.X;
                    oldY = field.Y;
                    field.X -= 4;
                    break;
                case ConsoleKey.RightArrow:
                    oldX = field.X;
                    oldY = field.Y;
                    field.X += 4;
                    break;
                case ConsoleKey.Escape:
                    gameEnd = true;
                    break;
            }
        }
    }
}
