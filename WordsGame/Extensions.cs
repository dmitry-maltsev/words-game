namespace WordsGame;

internal static class Extensions
{
    private static readonly Random Random = new();

    public static T GetRandomElement<T>(this ICollection<T> collection)
    {
        var index = Random.Next(collection.Count - 1);
        return collection.ElementAt(index);
    }

    public static string ToUpper(this char letter)
    {
        return letter.ToString().ToUpper();
    }
}