using static MineSweeper.Display.SuperConsole;

namespace MineSweeper.Features
{
    static class Game
    {
        static int oldX = 7;
        static int oldY = 13;
        private static bool gameEnd = false;
        private static bool lastActionMove = false;
        private static bool lastActionNotMoved = false;
        public static int BoardX
        {
            get { return _boardX; }
            set
            {
                if (value <= 5 && value >= 0)
                    _boardX = value;
                else if (value < 0)
                    _boardX = 5;
                else if (value > 5)
                    _boardX = 0;
            }
        }
        private static int _boardX;
        public static int BoardY
        {
            get { return _boardY; }
            set
            {
                if (value <= 5 && value >= 0)
                    _boardY = value;
                else if (value < 0)
                    _boardY = 5;
                else if (value > 5)
                    _boardY = 0;
            }
        }
        public static int oldBoardX;
        public static int oldBoardY;
        private static int _boardY;
        public static char[,] visualArray;
        static public void Play(MineField field, Mine mine)
        {
            Init(field);
            DrawCusor(field.X, field.Y, _boardX, _boardY);
            do
            {
                ActionChoice(field, mine);
            } while (!gameEnd);
        }
        static public void Init(MineField field)
        {
            field.X = 7;
            field.Y = 13;
            _boardX = 0;
            _boardY = 0;
            visualArray = new char[field.nbrCol, field.nbrRow];
        }
        static public void ActionChoice(MineField field, Mine mine)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    ClearCusor(field.X, field.Y, _boardX, _boardY);
                    Move(field, keyInfo);
                    DrawCusor(field.X, field.Y, _boardX, _boardY);
                    break;
                case ConsoleKey.Spacebar:
                    Flag.DrawEnterFlag(field.X, field.Y, _boardX, _boardY);
                    break;
                case ConsoleKey.Enter:
                    if (visualArray[_boardX, _boardY] == visualFlag)
                        Flag.ClearFlag(field.X, field.Y, _boardX, _boardY);
                    else if ((visualArray[_boardX, _boardY] == ' ') && (field.gameArray[_boardX, _boardY] == undiscoveredMine))
                        mine.DrawEnterMine(field.X, field.Y, _boardX, _boardY);
                    break;
            }
        }
        static public void Move(MineField field, ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    oldX = field.X;
                    oldY = field.Y;
                    oldBoardX = BoardX;
                    oldBoardY = BoardY;
                    field.Y -= 2;
                    BoardY--;
                    break;
                case ConsoleKey.DownArrow:
                    oldX = field.X;
                    oldY = field.Y;
                    oldBoardX = BoardX;
                    oldBoardY = BoardY;
                    field.Y += 2;
                    BoardY++;
                    break;
                case ConsoleKey.LeftArrow:
                    oldX = field.X;
                    oldY = field.Y;
                    oldBoardX = BoardX;
                    oldBoardY = BoardY;
                    field.X -= 4;
                    BoardX--;
                    break;
                case ConsoleKey.RightArrow:
                    oldX = field.X;
                    oldY = field.Y;
                    oldBoardX = BoardX;
                    oldBoardY = BoardY;
                    field.X += 4;
                    BoardX++;
                    break;
                case ConsoleKey.Escape:
                    gameEnd = true;
                    break;
            }
        }
    }
}
