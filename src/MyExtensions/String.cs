namespace MyExtensions;

public static class StringExtensions
{   
    // Count If String has Unicode
    public static int CountCharacters(this string text)
    {
        if (String.IsNullOrEmpty(text))
            return 0;
        
        int count = 0;

        var enumerator = StringInfo.GetTextElementEnumerator(text);
        while (enumerator.MoveNext())
            ++count;

        return count;
    }

    public static int CountDistinctCharacters(this string text)
    {
        if (String.IsNullOrEmpty(text))
            return 0;
        
        return text.ToCharArray().GroupBy(chr => chr).Count();
    }

    public static IEnumerable<string> SplitFormat(this string text, string format)
    {
        foreach (var chr in text)
        {
            Console.WriteLine($"Iterator: about to yield {i}");
            yield return $"|{chr}|";
            Console.WriteLine($"Iterator: yielded {i}");
        }
        Console.WriteLine("Iterator: End");
    }
}