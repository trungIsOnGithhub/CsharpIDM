namespace ConsoleApplication
{
    static public partial class Options
    {
        public static void ManageFolders(int selectedItem)
        {
            switch(selectedItem)
            {
                //Create Folder
                case 0:
                {
                    Console.Clear();
                    Console.WriteLine("Enter the path for the folder you wish to create:");
                    string input = Console.ReadLine();

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        ObjectManager.CreateNewFolder(input);
                        Console.WriteLine("SUCCESS! New folder created at " + input);
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The requested directory path is invalid, OR already exists!");
                    }
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
                //Delete Folder
                case 1:
                {
                    Console.Clear();
                    Console.WriteLine("WARNING! This function will permenantly delete the specified folder and everything contained within. To cancel, enter 'C'.");
                    Console.WriteLine("Enter the path of the folder you wish to delete:");
                    string input = Console.ReadLine();

                    if(input == "c" || input == "C")
                    {
                        DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    }

                    try
                    {
                        ObjectManager.RemoveFolder(input, true);

                        if(ObjectManager.CheckFolderExists(input) == false)
                        {   
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("SUCCESS! The specified folder has been removed.");
                            DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The specified folder could not be removed.");
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The folder you are trying to remove does not exist");
                    }
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
                //Move FOLDER
                case 2:
                {
                    Console.Clear();
                    Console.WriteLine("Enter the name of the folder you would like to move:");
                    string input1 = Console.ReadLine();
                    Console.WriteLine("Enter the location where you would like to move the folder:");
                    string input2 = Console.ReadLine();

                    try
                    {
                        ObjectManager.MoveFolder(input1, input2);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SUCCESS! Your folder has been moved to " + input2);
                    }
                    catch(ArgumentException)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The folder you are trying to move does not exist, OR the destination path already exists!");
                    }
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
                //Rename FOLDER
                case 3:
                {
                    Console.Clear();
                    Console.WriteLine("Enter the path of the folder you would like to rename:");
                    string input1 = Console.ReadLine();
                    Console.WriteLine("Enter a new name for the folder:");
                    string input2 = Console.ReadLine();
                    string destinationPath = input1.Remove(input1.LastIndexOf(@"\")) + @"\" + input2;
                    
                    if (input1 == destinationPath)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Your folder is already named '" + input2 + "'! No changes made.");
                        DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    }
                    
                    try
                    {
                        ObjectManager.RenameFolder(input1, input2);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SUCCESS! Your folder has been renamed '" + input2 + "'!");
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The folder you are trying to move does not exist, OR the destination path already exists.");
                    }
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
                //Return to menu
                case 4:
                {
                    Console.Clear();
                    Console.WriteLine("MAIN MENU");
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
            }
        }
    }
}