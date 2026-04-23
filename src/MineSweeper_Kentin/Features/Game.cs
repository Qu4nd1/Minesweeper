using static MineSweeper.Display.SuperConsole;

namespace MineSweeper.Features
{
    static class Game
    {
        static int oldX;
        static int oldY;
        private static bool gameEnd = false;
        private static bool lastActionMove = false;
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
            if (lastActionMove == true)
            {
                ClearAt(oldX, oldY);
                lastActionMove = false;
            }
            DrawInColorAt(field.X, field.Y, "_", ConsoleColor.Green);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if ((keyInfo.Key != ConsoleKey.Escape) && (keyInfo.Key != ConsoleKey.Spacebar))
            {
                Move(field, keyInfo);
                
                lastActionMove = true;
            }
            else if ((keyInfo.Key == ConsoleKey.Spacebar))
            {
                // Placement de drapeau si case vide
                if (field.flagArray[_boardX,_boardY] != 'F')
                {
                    DrawInColorAt(field.X, field.Y, "F", ConsoleColor.Yellow);
                    field.flagArray[_boardX, _boardY] = 'F';
                }
                // Effacement de drapeau si case a déjà un drapeau
                else
                {
                    DrawAtChar(field.X, field.Y, ' ');
                    field.flagArray[_boardX, _boardY] = ' ';
                }
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
                    BoardY--;
                    break;
                case ConsoleKey.DownArrow:
                    oldX = field.X;
                    oldY = field.Y;
                    field.Y += 2;
                    BoardY++;
                    break;
                case ConsoleKey.LeftArrow:
                    oldX = field.X;
                    oldY = field.Y;
                    field.X -= 4;
                    BoardX--;
                    break;
                case ConsoleKey.RightArrow:
                    oldX = field.X;
                    oldY = field.Y;
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
