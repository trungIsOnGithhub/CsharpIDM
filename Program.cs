using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            Console.Clear();
            Console.Title = "Console Ultilities Application";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("┬─┬ノ( º _ ºノ)");
            Console.WriteLine( Utilities.GetSystemInfo() );
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Welcome to Console Ultilities Application! Select an option from below menu using the UP and DOWN arrow keys to navigate:");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            DynamicMenu.Menu(new []{"option1", "option2", "option3"}, 1);
        }
    }
}