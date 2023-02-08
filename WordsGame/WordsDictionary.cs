using System.Diagnostics;

namespace WordsGame;

internal class WordsDictionary
{
    private readonly IDictionary<string, string> _dict;

    public WordsDictionary(string path)
    {
        _dict = LoadDictionary(path);
    }
    
    public bool Contains(string word) => _dict.ContainsKey(word);
    
    public string GetDefinition(string word) => _dict[word];

    public string GetRandomWord() => _dict.Keys.GetRandomElement();

    public string? GetWordStartingWith(char letter, IEnumerable<string> excludeWords)
    {
        var words = _dict.Keys
            .Where(word => word.StartsWith(letter))
            .Except(excludeWords)
            .ToList();

        return words.Count > 0 ? words.GetRandomElement() : null;
    }
    
    private static IDictionary<string, string> LoadDictionary(string path)
    {
        var result = new Dictionary<string, string>();
        
        var lines = File.ReadLines(path);
        
        foreach (var line in lines)
        {
            var split = line.IndexOf(':');
            
            var word = line[..split];
            var definition = line[(split + 2)..];
            
            result.Add(word, definition);
        }

        return result;
    }
}