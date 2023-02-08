namespace WordsGame;

public class Game
{
    private readonly ISet<string> _usedWords;
    private readonly WordsDictionary _dict;
    private char _currentLetter;

    private readonly Action _onGameStarted;
    private readonly Action<string, string> _onWordPlayed;
    private readonly Action<Source, char> _onNextLetter;
    private readonly Action<string> _onError;
    private readonly Action _onWin;
    private readonly Func<string?> _onInput;

    public Game(
        Action onGameStarted,
        Action<string, string> onWordPlayed,
        Action<Source, char> onNextLetter,
        Action<string> onError,
        Action onWin,
        Func<string?> onInput)
    {
        _usedWords = new HashSet<string>();
        _dict = new WordsDictionary("Dictionaries/russian_nouns_with_definition.txt");
        
        _onGameStarted = onGameStarted;
        _onWordPlayed = onWordPlayed;
        _onNextLetter = onNextLetter;
        _onError = onError;
        _onWin = onWin;
        _onInput = onInput;
    }

    public void Play()
    {
        _onGameStarted();

        var firstWord = _dict.GetRandomWord();
        PlayWord(Source.Game, firstWord);

        while (true)
        {
            _onNextLetter(Source.Player, _currentLetter);
            
            var input = GetInput();
            var error = Validate(input);
            
            while (error is not null)
            {
                _onError(error);
                _onNextLetter(Source.Player, _currentLetter);
                
                input = GetInput();
                error = Validate(input);
            }

            PlayWord(Source.Player, input);

            _onNextLetter(Source.Game, _currentLetter);
            
            var nextWord = _dict.GetWordStartingWith(_currentLetter, _usedWords);
            if (nextWord is null)
            {
                _onWin();
                return;
            }
            
            PlayWord(Source.Game, nextWord);
        }
    }

    private string? GetInput()
    {
        return _onInput()?.ToLower();
    }

    private void PlayWord(Source source, string word)
    {
        _usedWords.Add(word);
        _currentLetter = GetLastLetter(word);

        if (source == Source.Game)
        {
            var definition = _dict.GetDefinition(word);
            _onWordPlayed(word, definition);
        }
    }
    
    private string? Validate(string? word)
    {
        if (string.IsNullOrEmpty(word))
            return Errors.CannotBeEmpty;

        if (word.Contains(' '))
            return Errors.CannotContainSpaces;

        var firstLetter = word[0];
        if (firstLetter != _currentLetter)
            return Errors.ShouldStartWith(_currentLetter);

        if (_usedWords.Contains(word))
            return Errors.AlreadyUsed;

        if (!_dict.Contains(word))
            return Errors.DoesNotExist;
        
        return null;
    }
    
    private static char GetLastLetter(string word)
    {
        var lastLetter = word[^1];

        switch (lastLetter)
        {
            case 'й':
                return 'и';
            case 'ё':
                return 'е';
        }

        var invalidLetters = new[] { 'ь', 'ы' };
        return invalidLetters.Contains(lastLetter) ? word[^2] : lastLetter;
    }
}

public enum Source
{
    Game,
    Player
}

