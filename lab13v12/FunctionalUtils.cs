namespace lab13v12;

public static class FunctionalUtils
{
    public static List<TResult> Map<T, TResult>(List<T> list, Func<T, TResult> mapper)
    {
        var result = new List<TResult>();
        foreach (var item in list)
        {
            result.Add(mapper(item));
        }
        return result;
    }

    public static List<T> Filter<T>(List<T> list, Func<T, bool> predicate)
    {
        var result = new List<T>();
        foreach (var item in list)
        {
            if (predicate(item))
                result.Add(item);
        }
        return result;
    }

    public static List<T> OrderBy<T, TKey>(List<T> list, Func<T, TKey> keySelector) 
        where TKey : IComparable<TKey>
    {
        var result = new List<T>(list);
        for (int i = 0; i < result.Count - 1; i++)
        {
            for (int j = 0; j < result.Count - 1 - i; j++)
            {
                if (keySelector(result[j]).CompareTo(keySelector(result[j + 1])) > 0)
                {
                    var temp = result[j];
                    result[j] = result[j + 1];
                    result[j + 1] = temp;
                }
            }
        }
        return result;
    }

    public static List<T> Reverse<T>(List<T> list)
    {
        var result = new List<T>();
        for (int i = list.Count - 1; i >= 0; i--)
        {
            result.Add(list[i]);
        }
        return result;
    }

    public static void ForEach<T>(List<T> list, Action<T> action)
    {
        foreach (var item in list)
        {
            action(item);
        }
    }
}