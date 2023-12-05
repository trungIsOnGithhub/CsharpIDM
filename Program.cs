using System;
using System.Text;
using CocktailModule;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            Console.Clear();
            Console.Title = "Console Ultilities Application";
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Console.WriteLine("┬─┬ノ( º _ ºノ)");
            Console.WriteLine( Utilities.GetSystemInfo() );
            // Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Welcome to Console Ultilities Application! Select an option from below menu using the UP and DOWN arrow keys to navigate:");
            // Console.WriteLine();
            // Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            // DynamicMenu.Menu(DynamicMenu.mainMenu, 1);

            Console.Clear();

            StringBuilder charBuffer = new StringBuilder(String.Empty);

            while (true) {
                ConsoleKeyInfo keyPress = Console.ReadKey(true);
                
                char keyRead = Convert.ToChar(keyPress.Key);

                char keyReadFiltered = Utilities.filterKey(keyRead);
                
                charBuffer.Append(keyRead);

                Console.Write(keyRead);

                if (keyPress.Key == ConsoleKey.Enter)
                {
                    // string line = Console.ReadLine();
                    Console.WriteLine();
                    CocktailModel model = new CocktailModel { VersionString = "v1" };
                    model.getCocktailByFirstLetter(charBuffer[0]);
                    Console.WriteLine();

                    // MessageModel.save(charBuffer.ToString());
                    Console.WriteLine();
                    Console.WriteLine($"Enter Pressed: {charBuffer.ToString()}");
                    // break;
                }
            }
        }
    }
}