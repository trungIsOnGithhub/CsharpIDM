using System;
using System.Collections;

namespace Delegates
{
    // already define in C#, error if redefined
    // public delegate int Comparison<in T>(T param1, T param2);

    class EnumerableSorter<T>
    {
        public static List<T> Sort(IEnumerable<T> enumerable, Comparison<T> comparatorForT)
        {
            List<T> tempList = enumerable.ToList();

            tempList.Sort();

            return tempList;
        }
    }
}