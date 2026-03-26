using MineSweeper.Difficulties;
using MineSweeper.Features;
namespace MineSweeper.Display
{
    public class Menu
    {
        private string[] options = new string[] {"easy", "medium", "hard"};
        public int SelectedIndex { get; private set; }
        private string title = @"
                        ███╗   ███╗ ██╗ ███╗  ██╗ ███████╗
                        ████╗ ████║ ██║ ████╗ ██║ ██╔════╝
                        ██╔████╔██║ ██║ ██╔██╗██║ █████╗  
                        ██║╚██╔╝██║ ██║ ██║╚████║ ██╔══╝  
                        ██║ ╚═╝ ██║ ██║ ██║ ╚███║ ███████╗
                        ╚═╝     ╚═╝ ╚═╝ ╚═╝  ╚══╝ ╚══════╝
";
        public List <Easy> selectedDifficulty = new List<Easy> ();

        public void Presentation()
        {
            const int TITLE_X = 10;
            const int TITLE_Y = 1;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetCursorPosition(TITLE_X, TITLE_Y);
            Console.WriteLine(title);
        }
        // Méthode : afficher le menu (ex-Menu_ShowInteractive)
        public void ShowInteractive()
        {
            Console.Clear();
            Presentation();
            Console.WriteLine("\tUse arrows to navigate, Enter to select");
            Console.WriteLine("");

            for (int i = 0; i < this.options.Length; i++)
            {
                if (i == this.SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\t> {this.options[i]} <");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"\t  {this.options[i]}");
                }
            }

            Console.WriteLine("");
        }

        // Méthode : boucle interactive (ex-Menu_RunInteractive)
        public void RunInteractive(MineField field)
        {
            Console.CursorVisible = false;
            ConsoleKey key;

            do
            {
                ShowInteractive();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

                if (key == ConsoleKey.UpArrow)
                {
                    MoveUp();
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    MoveDown();
                }

            } while (key != ConsoleKey.Enter);
            DifficultySelection(field);
        }
        public void DifficultySelection(MineField field)
        {
            switch (this.options[this.SelectedIndex])
            {
                case "easy":
                    Easy easy = new Easy(field);
                    selectedDifficulty.Add(easy);
                    break;
                case "medium":
                    Medium medium = new Medium(field);
                    selectedDifficulty.Add(medium);
                    break;
                case "hard":
                    Hard hard = new Hard(field);
                    selectedDifficulty.Add(hard);
                    break;
            }
        } 
        public void MoveUp()
        {
            // monte normalement
            if (this.SelectedIndex > 0)
            {
                this.SelectedIndex--;
            }
            // si sur la ligne du haut, recommencer en bas
            else
            {
                this.SelectedIndex = options.Length - 1;
            }
        }

        public void MoveDown()
        {
            // descend normalement
            if (this.SelectedIndex < this.options.Length - 1)
            {
                this.SelectedIndex++;
            }
            else
            {
                this.SelectedIndex = 0;
            }
        }
    }
}
