using MineSweeper.Display;
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

        public void DrawField(Menu menu)
        {

            int fieldWidth = squareWidth * 1 + (squareWidth - 1) * (nbrRow - 1);
            int fieldHeight = squareHeight * 1 + (squareHeight - 1) * (nbrCol - 1);

            Console.Clear();
            menu.Presentation();
            // Ajout d'affichage difficulté et nbr mines
           for (int i = 0; i < fieldHeight; i++)
            {
                Console.SetCursorPosition(5, 12 + i);
                if (i == 0)
                    for (int j = 0; j < fieldWidth; j++)
                    {
                        if (j == 0)
                            Console.Write("╔");
                        else if (j == fieldWidth - 1)
                            Console.Write("╗");
                        else if (j % 4 == 0)
                            Console.Write("╦");
                        else
                            Console.Write("═");
                    }
                else if (i % (squareHeight-1) == 0 && i != fieldHeight-1)
                    for (int j = 0; j < fieldWidth; j++)
                    {
                        if (j == 0)
                            Console.Write("╠");
                        else if (j == fieldWidth - 1)
                            Console.Write("╣");
                        else if (j % 4 == 0)
                            Console.Write("╬");
                        else
                            Console.Write("═");
                    }
                else if (i == fieldHeight - 1)
                    for (int j = 0; j < fieldWidth; j++)
                    {
                        if (j == 0)
                            Console.Write("╚");
                        else if (j == fieldWidth - 1)
                            Console.Write("╝");
                        else if (j % 4 == 0)
                            Console.Write("╩");
                        else
                            Console.Write("═");
                    }
                else
                    for (int j = 0; j < fieldWidth; j++)
                    {
                        if (j == 0)
                            Console.Write("║");
                        else if (j == fieldWidth - 1)
                            Console.Write("║");
                        else if (j % 4 == 0)
                            Console.Write("║");
                        else
                            Console.Write(" ");
                    }
                Console.WriteLine();
            }
        }
        public int RowDimensions()
        {
            string question = "Choice: ";
            string nbrRowCheck;
            bool rowValueValid;
            int questionX = 5;
            int questionY = 10;
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
            int questionY = 12;
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
            _surface = ((nbrRow / 2) + 1) * ((nbrCol / 2) + 1);

        }
    }
}
