using static MineSweeper.Display.SuperConsole;

namespace MineSweeper.Features
{
    public class MineField
    {
        // 1 carré du mineField est de 5 de largeur pour 3 de hauteur
        private int squareWidth = 5;
        private int squareHeight = 3;

        private int nbrRow = 0;
        private int nbrCol = 0;

        private int _surface;
        public int Surface { get { return _surface; } }

        public void DrawField(int x, int y, int width, int height)
        {
            int fieldWidth = squareWidth * nbrRow;
            int fieldHeight = squareHeight * nbrCol;
            // Ligne du hauts
            DrawHorizontalLine(x, y, width, '─');

            // Ligne du bas
            DrawHorizontalLine(x, y + height - 1, width, '─');

            // Côté gauche
            DrawVerticalLine(x, y, height, '│');

            // Côté droit
            DrawVerticalLine(x + width - 1, y, height, '│');

            // Coins
            Console.SetCursorPosition(x, y);
            Console.Write('┌');
            Console.SetCursorPosition(x + width - 1, y);
            Console.Write('┐');
            Console.SetCursorPosition(x, y + height - 1);
            Console.Write('└');
            Console.SetCursorPosition(x + width - 1, y + height - 1);
            Console.Write('┘');
        }
        public int RowDimensions()
        {
            string question = "Choice: ";
            string nbrRowCheck;
            bool rowValueValid;
            int questionX = 5;
            int questionY = 5;
            do
            {
                Console.SetCursorPosition(questionX, questionY-1);
                Console.WriteLine("How many rows do you want your MineSweeper to have (6-30) ? :");
                
                Console.SetCursorPosition(questionX, questionY);
                Console.Write(question);
                
                Console.SetCursorPosition(questionX + question.Length, questionY);
                nbrRowCheck = Console.ReadLine();
                // Check for only int
                rowValueValid = int.TryParse(nbrRowCheck, out nbrRow);
                // Check for in limits
                if (nbrRow < 6 || nbrRow > 30)
                    rowValueValid = false;
                // If not valid (limits or ints)
                if (!rowValueValid)
                {
                    ClearAtForLength(questionX, questionY, question.Length + nbrRowCheck.Length);
                }
            }while (!rowValueValid);
            return nbrRow;
        }
        public int ColumnDimension()
        {
            string question = "Choice: ";
            string nbrColCheck;
            bool ColValueValid;
            int questionX = 5;
            int questionY = 7;
            do
            {
                Console.SetCursorPosition(questionX, questionY-1);
                Console.WriteLine("How many columns do you want your MineSweeper to have (6-30) ? :");
                
                Console.SetCursorPosition(questionX, questionY);
                Console.Write(question);

                Console.SetCursorPosition(questionX + question.Length, questionY);
                nbrColCheck = Console.ReadLine();
                // Check for only int
                ColValueValid = int.TryParse(nbrColCheck, out nbrCol);
                // Check for in limits
                if (nbrCol < 6 || nbrCol > 30)
                    ColValueValid = false;
                // If not valid (limits or ints)
                if (!ColValueValid)
                {
                    ClearAtForLength(questionX, questionY, question.Length + nbrColCheck.Length);
                }
            } while (!ColValueValid);
            return nbrCol;
        }
        
        public void FieldCreation()
        {
            nbrRow = RowDimensions();
            nbrCol = ColumnDimension();
            _surface = (nbrRow / 2) + 1 * (nbrCol / 2) + 1;

        }
    }
}
