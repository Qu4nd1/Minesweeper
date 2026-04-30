using MineSweeper.Display;
using static MineSweeper.Display.SuperConsole;
using MineSweeper.Difficulties;

namespace MineSweeper.Features
{
    public class MineField
    {
        // 1 carré du mineField est de 5 de largeur pour 3 de hauteur
        private int squareWidth = 5;
        private int squareHeight = 3;

        public int nbrRow = 0;
        public int nbrCol = 0;

        private int _surface;
        public int Surface { get { return _surface; } }
        private int _x;
        public int X
        {
            get { return _x; }
            set
            {
                if (value >= 7 && value <= (7 +(nbrCol - 1) * 4))
                    _x = value;
                else if (value < 7)
                    _x = 7 + ((nbrCol - 1) * 4);
                else if (value > ((nbrCol - 1) * 4))
                    _x = 7;
            }
        }
        private int _y;
        public int Y
        {
            get { return _y; }
            set
            {
                if (value >= 13 && value <= (13 + (nbrRow - 1) * 2))
                    _y = value;
                else if (value < 13)
                    _y = 13 + ((nbrRow - 1) * 2);
                else if (value > ((nbrRow - 1) * 2))
                    _y =13;
            }
        }
        public char[,] gameArray;

        public void DrawField(Menu menu, MineField field, Mine mine)
        {

            int fieldWidth = squareWidth * 1 + (squareWidth - 1) * (nbrRow - 1);
            int fieldHeight = squareHeight * 1 + (squareHeight - 1) * (nbrCol - 1);

            int instructionX = fieldWidth + 12;

            Console.Clear();
            menu.Presentation();
            Console.Write($"\tA vous de jouer !! Mode:");
            Console.BackgroundColor = ConsoleColor.Yellow;
            DrawInColor($"{menu.SelectedDifficulty}", ConsoleColor.Red);
            Console.ResetColor();
            LinesJump(1);
            DrawInColor($"\t{mine.NumberOfMines(menu, field)}", ConsoleColor.Red);
            Console.WriteLine(" mines se cachent dans le jeu !");
            LinesJump(1);
            // Ajout d'affichage difficulté et nbr mines
            for (int i = 0; i < fieldHeight; i++)
            {

                int instructionY = 12 + i;
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
                if (i == 0)
                    DrawAtString(instructionX, instructionY, "Consignes");
                if (i == 1)
                    DrawAtString(instructionX, instructionY, "----------");
                if (i == 2)
                    DrawAtString(instructionX, instructionY, "  - Pour se déplacer dans le jeu: les flèches directionnelles");
                if (i == 3)
                    DrawAtString(instructionX, instructionY, "  - Pour explorer une case: la touche Enter");
                if (i == 4)
                    DrawAtString(instructionX, instructionY, "  - Pour définir une case comme mine (flag): la touche Espace");
                if (i == 5)
                    DrawAtString(instructionX, instructionY, "  - Pour enlever un flag: la touche Enter");
                if (i == 6)
                    DrawAtString(instructionX, instructionY, "  - Pour quitter: la touche Esc");
                if (i == 8)
                    DrawAtString(instructionX, instructionY, "La partie est gangée :");
                if (i == 9)
                    DrawAtString(instructionX, instructionY, "  - Toutes les cases sont explorées");
                if (i == 10)
                    DrawAtString(instructionX, instructionY, "  - Il reste des bombes non explosées");
                Console.WriteLine();
            }
        }
        public int RowDimension()
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
            nbrRow = RowDimension();
            nbrCol = ColumnDimension();
            _surface = ((nbrRow / 2) + 1) * ((nbrCol / 2) + 1);
            gameArray = new char[nbrCol, nbrRow];
            for (int i = 0; i < nbrCol; i++)
                for (int j = 0; j < nbrRow; j++)
                {
                    gameArray[i, j] = ' ';
                }
        }
        public void MineFilling(int nbrMines)
        {
            int minesPlaced = 0;
            do
            {
                int mineX = Helpers.Random.Next(nbrCol);
                int mineY = Helpers.Random.Next(nbrRow);
                if (gameArray[mineX, mineY] != 'M')
                {
                    gameArray[mineX, mineY] = 'M';
                    minesPlaced++;
                }
                
            } while (minesPlaced != nbrMines);
            
        }
        public void CaseFilling(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(symbol);
        }
    }
}
