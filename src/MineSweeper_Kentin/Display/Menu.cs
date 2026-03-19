
namespace MineSweeper.Display
{
    public class Menu
    {
        private string[] options = new string[] {"easy", "medium", "hard"};
        public int SelectedIndex { get; private set; }

        // Méthode : afficher le menu (ex-Menu_ShowInteractive)
        void ShowInteractive()
        {
            Console.Clear();
            Console.WriteLine("Use arrows to navigate, Enter to select");
            Console.WriteLine("");

            for (int i = 0; i < this.options.Length; i++)
            {
                if (i == this.SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"> {this.options[i]} <");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {this.options[i]}");
                }
            }

            Console.WriteLine("");
        }

        // Méthode : boucle interactive (ex-Menu_RunInteractive)
        public int RunInteractive()
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

            return this.SelectedIndex;
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
