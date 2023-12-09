using ExtensionMethods;

namespace ConsoleApplication
{
    public static partial class Options
    {
        public static void MainMenuOptions(int selectedItem)
        {
            switch(selectedItem)
            {
                case 0:
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a directory path: ");
                    input = Console.ReadLine();
                    
                    try
                    {
                        ListMaker list = new ListMaker();
                        TableMaker tableMaker = new TableMaker();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(tableMaker.PrintLine());
                        Console.WriteLine(tableMaker.PrintRow(headings));
                        Console.WriteLine(tableMaker.PrintLine());
                        string[] files = ObjectManager.ListFilesInDirectory(input);
                        List<DataObject> fileList = new List<DataObject>();

                        foreach (string file in files)
                        {
                            DataObject obj = new FileObject();
                            obj.Path = file;
                            obj.Name = file.Name();
                            obj.Size = file.FileSize();
                            obj.LastAccess = file.LastAccess();
                            fileList.Add(obj);
                        }

                        string[] table = list.CreateTable(fileList);

                        tableMaker.PrintTableToConsole(table);
                        string listSize = input.FolderSize();

                        Console.WriteLine("The total size of the files within this folder (excluding subfolders) is: " + listSize);
                        Console.WriteLine();
                    }
                    catch(ArgumentException exception)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("EXCEPTION: " + exception.Message);
                        Console.WriteLine("---------------------------------------------");
                    }   
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }   
                case 1: 
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a directory:");
                    input = Console.ReadLine();

                    try
                    {
                        ListMaker list = new ListMaker();
                        TableMaker tableMaker = new TableMaker();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(tableMaker.PrintLine());
                        Console.WriteLine(tableMaker.PrintRow(headings));
                        Console.WriteLine(tableMaker.PrintLine());
                        string[] folders = ObjectManager.ListSubfoldersInDirectory(input);
                        List<DataObject> folderList = new List<DataObject>();

                        foreach(string folder in folders)
                        {
                            DataObject obj = new FolderObject();
                            obj.Path = folder;
                            obj.Name = folder.Name();
                            obj.Size = folder.FolderSize();
                            obj.LastAccess = folder.LastAccess(); 
                            folderList.Add(obj);
                        }

                        string[] table = list.CreateTable(folderList);
                        tableMaker.PrintTableToConsole(table);
                        long totalSize = ObjectManager.GetSizeOfDirectory(input) - ObjectManager.GetSizeOfFileList(input);
                        
                        Console.WriteLine("The total size of the subfolders within this directory is: " + Utilities.SelectAppropriateFileSizeFormat(totalSize));
                        Console.WriteLine();
                    }
                    catch(ArgumentException exception)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("EXCEPTION: " + exception.Message);
                        Console.WriteLine("---------------------------------------------");
                    } 
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1); 
                    break;
                }
                case 2:
                {
                    Console.WriteLine("another test");
                    Console.Clear();
                    Console.WriteLine("FILE MANAGER");
                    DynamicMenu.Menu(DynamicMenuOption.filesMenu, 2);
                    break;
                }
                case 3:
                {
                    Console.Clear();
                    Console.WriteLine("FOLDER MANAGER");
                    DynamicMenu.Menu(DynamicMenuOption.foldersMenu, 3);
                    break;
                }
                case 4:
                {
                    Console.Clear();
                    Console.WriteLine("This option creates a text file which compiles information on all of the files and folders in the location specified.");
                    Console.WriteLine("To continue, please enter the directory path where you would like to create your index file:");
                    input = Console.ReadLine();

                    try
                    {
                        ObjectManager.CreateIndexFile(input);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SUCCESS! Your new index file has been created at " + input + "\\index.txt");
                    }
                    catch(ArgumentException exception)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("EXCEPTION: " + exception.Message);
                        Console.WriteLine("---------------------------------------------");
                    }
                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
                case 5:
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Clear();

                    Console.WriteLine("Enter One Character That You Want To Be Animated:");

                    char animatedChar = Console.ReadKey().KeyChar;

                    Program.setAnimatedCharacterForLoadingAnimation(animatedChar);

                    Console.Clear();

                    Console.WriteLine($"Set {animatedChar} for Loading Animation Successfully!");
                    Console.WriteLine("-------------------------------------------------------");

                    Console.ForegroundColor = ConsoleColor.White;

                    DynamicMenu.Menu(DynamicMenuOption.mainMenu, 1);
                    break;
                }
                default:
                {
                    Console.Clear();

                    Console.WriteLine("Goodbye!!");

                    Environment.Exit(0);

                    break;  
                }
            }
        }
    }
}