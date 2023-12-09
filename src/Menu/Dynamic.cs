using System;
using System.Threading;

namespace ConsoleApplication
{
    public static class DynamicMenuOption
    {
        public static readonly string[] mainMenu = {
            "Get list of files in directory",
            "Get list of folders in directory",
            "Manage files", "Manage folders",
            "Generate index file", "Custom Loading Animation",
            "Cocktail API", "Quadratic Equation Generator",
            "Quit"
        };

        public static readonly string[] filesMenu = {
            "Create file", "Delete file", "Move file", "Rename File",
            "Read text from file", "Write text to file","Search file for text",
            "Return to MAIN MENU"
        };

        public static readonly string[] foldersMenu = {
            "Create folder", "Delete folder", "Move Folder",
            "Rename Folder", "Return to MAIN MENU"
        };
    }
    public static class DynamicMenu
    {
        private static int selectedItemIndex = default;

        public static void Menu(string[] array, int menu)
        {
            bool loopComplete = false;
            int topOffset = Console.CursorTop;
            int bottomOffset = 0;

            selectedItemIndex = 0;

            Console.CursorVisible = false;

            while (!loopComplete)
            {
                for (int i = 0; i < array.Length; i ++)
                {
                    if (i == selectedItemIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine(array[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(array[i]);
                    }
                }

                bottomOffset = Console.CursorTop;

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch(key.Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        if (selectedItemIndex > 0)
                        {
                            selectedItemIndex--;
                        }
                        else
                        {
                            selectedItemIndex = (array.Length - 1);
                        }
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        if (selectedItemIndex < (array.Length - 1))
                        {
                            selectedItemIndex++;
                        }
                        else
                        {
                            selectedItemIndex = 0;
                        }
                        break;
                    }
                    case ConsoleKey.Enter:
                    {
                        Console.WriteLine("testing");
                        loopComplete = true;
                        break;
                    }
                }
                Console.SetCursorPosition(0, topOffset);
            }
    
            Console.SetCursorPosition(0, bottomOffset);
            Console.CursorVisible = true;

            (new ConsoleAnimation{ animatedChar = Program.getLoadingAnimationCharacter() }).play(40);
            
            selectOptions(selectedItemIndex, menu);
        }


        private static void selectOptions(int selectedItemIndex, int menu)
        {
            switch (menu)
            {
                case 1:
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("MAIN MENU");
                    Console.WriteLine();
                    Options.MainMenuOptions(selectedItemIndex);
                    break;
                }
                case 2:
                {
                    Console.WriteLine("testing");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FILE MANAGER");
                    Console.WriteLine("testing1");
                    Console.WriteLine();
                    Options.ManageFiles(selectedItemIndex);
                    break;
                }
                case 3:
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FOLDER MANAGER");
                    Console.WriteLine();
                    Options.ManageFolders(selectedItemIndex);
                    break;
                }
            }
        }
    }
}