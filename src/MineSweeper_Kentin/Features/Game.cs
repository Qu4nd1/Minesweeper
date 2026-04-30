using static MineSweeper.Display.SuperConsole;

namespace MineSweeper.Features
{
    static class Game
    {
        static int oldX = 7;
        static int oldY = 13;
        private static bool gameEnd = false;
        private static bool lastActionMove = false;
        private static bool lastActionFlagPlaced = false;
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
        static public void Play(MineField field)
        {

            Init(field);
            DrawInColorAt(field.X, field.Y, "_", ConsoleColor.Green);
            do
            {
                ActionChoice(field);
            } while (!gameEnd);
        }
        static public void Init(MineField field)
        {
            field.X = 7;
            field.Y = 13;
            _boardX = 0;
            _boardY = 0;
        }
        static public void ActionChoice(MineField field)
        {
            
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    Move(field, keyInfo);
                    // Dosen't clear last case if a flag is on it 
                    if (!lastActionFlagPlaced && Flag.flagArray[oldBoardX, oldBoardY] != 'F')
                        ClearAt(oldX, oldY);
                    lastActionFlagPlaced = false;
                    // Dosen't overwrite a flag
                    if (Flag.flagArray[_boardX,_boardY]!= 'F')
                        DrawInColorAt(field.X, field.Y, "_", ConsoleColor.Green);
                    break;
                case ConsoleKey.Spacebar:
                    Flag.DrawEnterFlag(field.X, field.Y, _boardX, _boardY);
                    lastActionFlagPlaced = true;
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
