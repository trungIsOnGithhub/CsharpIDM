## File Manager Console Application

> Development using .NET 6 platform, C# 10 Language Version

> Reference: [Microsoft Learn](https://learn.microsoft.com) - for educational purpose, [CodeMaze](https://code-maze.com/csharp-unit-of-work-pattern/), [Blog](https://www.stevejgordon.co.uk/aspnet-core-dependency-injection-what-is-the-iserviceprovider-and-how-is-it-built
)


#### Example For Some Fundamentals C# Concepts/.NET features

## Partial Class

Make it possible to split the definition of a class, a struct, an interface or a method in many files.

```cs
    public static partial class Options
    {
        ...
```

Together with the namespace system, this aid code structuring and refactoring more comfortable even for many people working on same codebase.

## LinQ

LINQ - Language Integrated Query is the integration of query capabilities directly into the C# language.

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

With LINQ, type checking at compile time or IntelliSense support is added, and query is first-class language construct, like classes, methods, events.

## Delegates

Delegates provide late binding mechanism in .NET == an procedure where the caller supplies a part of the procedure.

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

#### Multicast Delegate

Multiple function object can be assigned to one  using the +, += operator to form a list of the assigned delegates.

When called, it invokes the chain of delegates in order. Only delegates of same type can be combined.

## Generics

Like other languages, Generic introduce concept of type parameter to .NET. It can be applied to Classes, Methods, Types.

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

Literally, with Generics, we can define a class that defer the the parameter specifying to client code without involving runtime casting or boxing.

### Bounded Generics

```cs
    public class EquationFactory<T1, T2>
        where T1 : System.ValueTuple<int, int, int, string>
        where T2 : QuadraticEquation
...
```

## Events

Events enable a class or object to notify other classes or objects when something of interest occurs. It provide more official way to implement Pattern: Publisher - Subscriber

In a typical C# application, you subscribe to events raised by buttons and list boxes.

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

## Extension Method

We can add methods to types without creating new derived type, recompiling, or modifying original type.
```cs
    public static string Name(this string filePath)
    {...}
...
```
Extension methods are static methods, but they can be called as if they were instance methods.
Some methods from LinQ `GroupBy, OrderBy, Average` from `IEnumerable` interface are example.

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

## Nullable Types

```cs
...
    public class UnitOfWork : IUnitOfWork
    {
        private ITransaction? _currentTransaction;

        public UnitOfWork(IDatabase database)
...
```

######  ```Dictionary<K, V>``` vs ```Hashtable``` ??

- ```Dictionary<K, V>``` provide generics and type-saftety on element, avoid casting and random object
> In fact, generic Dictionary was a copy of Hashtable - [MS Reference](https://referencesource.microsoft.com/#mscorlib/system/collections/hashtable.cs)


#### [Repository Pattern in ASP Net Core API](https://code-maze.com/net-core-web-development-part4/)

### [Dependency Injection in C#](https://xuanthulab.net/dependency-injection-di-trong-c-voi-servicecollection.html)


This console application was created for the purpose of learning the C# language. It enable user with some(and maybe more) functionalities:

- View a table of all files in a directory (including file size and last access timestamp).
- View a table of all subfolders in a directory (pretty much the same idea as above).
- Create, delete, move, rename, read text from and write text to files, as well as searching text files for specific phrases.
- Create, delete, move and rename folders.
- Create and save an 'index.txt' file, which displays all of the files and subfolders in a directory, with some useful information (basically the same thing as the first 2 bullet points, but in a HANDY and CONVENIENT text file).
- Colorful console animation!
