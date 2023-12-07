## File Manager Console Application

> Development using .NET 6 SDK, C# 10 Language Version

#### Example For Some Fundamentals C# Concepts

## LinQ

```cs
    return rootList
                .SelectMany(
                    root => FlattenRootsByValue(root.Childs, value)
                ).Concat(
                    rootList.Where(root => root.Value == value)
                );
```

```cs
...
    return (from child in Childs select child.Value);
```

## Delegates

```cs
    public delegate void EnterKeyEventHandler (object sender, EnterKeyEventArgs eArgs);
    public delegate void SpaceKeyEventHandler (object sender, SpaceKeyEventArgs eArgs);
...
```

```cs
    // public delegate int Comparison<in T>(T x, T y); -- predefined in System namespace
...
    public static List<T> Sort(IEnumerable<T> enumerable, Comparison<T> comparatorForT)
...
    EnumerableSorter<Cocktail>.Sort(
       getCocktaiListFromJson(responseContent), cocktailCompareByNameLength
    )
```

## Generics

```cs
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
```

### Bounded Generics

```cs
    public class EquationFactory<T1, T2>
        where T1 : System.ValueTuple<int, int, int, string>
        where T2 : QuadraticEquation
...
```

## Events

```cs
class EnterKeyEventPublisher : KeyEventPublisher
    {
        public event EnterKeyEventHandler KeyEvent;

        protected virtual void OnKeyPressed(EnterKeyEventArgs eArgs)
...
 class SpaceKeyEventPublisher : KeyEventPublisher
    {
        public event SpaceKeyEventHandler KeyEvent;

        protected virtual void OnKeyPressed(SpaceKeyEventArgs eArgs)
...
```

## Tuple (> C# 7)

```cs
...
      var equation = EquationFactory<
          (int, int, int, string),
          QuadraticEquation
      >.CreateWith4Args( (1, 2, 1, "x");
```

## Object Initializer

```cs
    public static T2 CreateWith2Args(T1 dataTuple)
    {
        return new T2{
            A = dataTuple.Item1,
            B = dataTuple.Item2,
            C = 0,
            Variable = "x"
     };
```

######  ```Dictionary<K, V>``` vs ```Hashtable``` ??

- ```Dictionary<K, V>``` provide generics and type-saftety on element, avoid casting and random object
> In fact, generic Dictionary was a copy of Hashtable - [MS Reference](https://referencesource.microsoft.com/#mscorlib/system/collections/hashtable.cs)

This console application was created for the purpose of learning the C# language. It enable user with some(and maybe more) functionalities:

- View a table of all files in a directory (including file size and last access timestamp).
- View a table of all subfolders in a directory (pretty much the same idea as above).
- Create, delete, move, rename, read text from and write text to files, as well as searching text files for specific phrases.
- Create, delete, move and rename folders.
- Create and save an 'index.txt' file, which displays all of the files and subfolders in a directory, with some useful information (basically the same thing as the first 2 bullet points, but in a HANDY and CONVENIENT text file).
- Colorful console animation!
