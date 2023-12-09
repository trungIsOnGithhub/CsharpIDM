using System;
using System.Collections.Generic;
using ExtensionMethods;

namespace ConsoleApplication
{
    public static partial class Options
    {
        public static string input;
        static string[] headings = {"Name", "Size", "Last Accessed"};

        public static void ManageFiles(int selectedItem)
        {
            switch(selectedItem)
            {
                //CreateFile
                case 0:
                {
                    Console.Clear();
                    Console.WriteLine("Enter the path for the file you wish to create: ");
                    string input = Console.ReadLine();

                    try
                    {
                        if(ObjectManager.IsExist(input) == false)
                        {
                            ObjectManager.CreateNewFile(input);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("SUCCESS! Your file has been created.");
                            DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Could not create new file!");
                    }
                    catch(ArgumentException)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Either the file already exists or you have entered an invalid file path!");
                    }
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
                //Delete File
                case 1:
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WARNING! This function will permenantly delete the specified file. To cancel, press 'C'.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Enter the path for the file you wish to delete: ");
                    string input = Console.ReadLine();

                    if(input == "c" || input == "C")
                    {
                        DynamicMenu.Menu(DynamicMenuOption.filesMenu, 1);
                    }
                        
                    try
                    {
                        ObjectManager.RemoveFile(input);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SUCCESS! File has been removed");
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! This file path does not exist!");
                    }
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
                //Move File
                case 2:
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the path of the file that you wish to move: ");
                    string input1 = Console.ReadLine();
                    Console.WriteLine("Please enter the path you wish to move the file to: ");
                    string input2 = Console.ReadLine();

                    try
                    {
                        ObjectManager.MoveFile(input1, input2);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Success! Your file has been moved");
                    }
                    catch(ArgumentException)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The file you are trying to move doesn't exist, OR there is already a file at the destination path, OR you have entered an invalid file path!");
                    } 
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
                //Rename file
                case 3:
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the path for the file you would like to rename:");
                    string input1 = Console.ReadLine();
                    Console.WriteLine("Please enter the new name you would like for the file:");
                    string input2 = Console.ReadLine();

                    try
                    {
                        ObjectManager.RenameFile(input1, input2);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SUCCESS! Your file has been renamed");
                        
                    }
                    catch(ArgumentException)
                    {
                        // Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The file you are trying to move doesn't exist, OR a file already exists in that location, OR you have entered an invalid file path!");
                        
                    }
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
                //Read text from file
                case 4:
                {
                    Console.Clear();
                    Console.WriteLine("Select file to read: ");
                    string input = Console.ReadLine();

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(ObjectManager.ReadTextFromFile(input));
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The file you are trying to read doesn't exist!");
                    }
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
                //Write text to file
                case 5:
                {
                    Console.Clear();
                    Console.WriteLine("Select file to write to:");
                    string input1 = Console.ReadLine();
                    Console.WriteLine("Enter the text to write to the file:");
                    string input2 = Console.ReadLine();

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        ObjectManager.WriteTextToFile(input1, input2);
                        Console.WriteLine("SUCCESS! Your text has been written to the file");
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! The file you are trying to write to doesn't exist!");
                    }  
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
                //search file for text
                case 6:
                {
                    Console.Clear();
                    Console.WriteLine("Select file to search:");
                    string input1 = Console.ReadLine();
                    Console.WriteLine("Enter the text to search for:");
                    string input2 = Console.ReadLine();
                    
                    try
                    {
                        if(ObjectManager.SearchForTextInFile(input1, input2) == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Clear();
                            Console.WriteLine(input1 + " DOES include the phrase '" + input2 + "'");
                            DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                        }

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Clear();
                        Console.WriteLine(input1 + " does NOT contain the phrase '" + input2 + "'");
                    }
                    catch(ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! File path cannot be found!");
                    }
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
                //Return to menu
                case 7:
                {
                    Console.Clear();
                    Console.WriteLine("MAIN MENU");
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
            }
        }

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