using System.Text;

namespace Generics
{
    class EnumerablePrinter<T>   
    {
        public static void printEnumerableByLine(IEnumerable<T> enummerable)
        {
            Console.WriteLine("[");
            foreach (T item in enummerable)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("]");
        }

        public static void printEnumerableByComma(IEnumerable<T> enumerable)
        {
            StringBuilder toPrint = new StringBuilder("[");

            bool moreThanOneElement = false;

            foreach (T item in enumerable)
            {
                toPrint.Append($"{item}, ");
                moreThanOneElement = true;
            }

            if (moreThanOneElement)
            {
                toPrint.Remove(toPrint.Length - 2, 2);
                // Console.WriteLine(toPrint);
            }

            toPrint.Append(']');

            Console.WriteLine(toPrint);
        }
    }
}