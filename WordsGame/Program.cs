using WordsGame;

var game = new Game(
    onGameStarted: () =>
    {
        GameConsole.WriteLineGreen("НАЧИНАЕМ ИГРУ");
        GameConsole.WriteLine();
        GameConsole.WriteGreen("ПЕРВОЕ СЛОВО: ");
    },
    onNextLetter: (source, letter) =>
    {
        GameConsole.WriteLine();
        GameConsole.WriteGreen(source == Source.Game
            ? $"{GetCheerWord()}! МНЕ НА [bold yellow]{letter.ToUpper()}[/]: "
            : $"ТЕБЕ НА [bold yellow]{letter.ToUpper()}[/]: ");
    },
    onWordPlayed: (word, definition) =>
    {
        GameConsole.WriteLine(word);
        GameConsole.WriteLineSilver($"ЗНАЧЕНИЕ: {definition}");
    },
    onError: error =>
    {
        GameConsole.WriteLine();
        GameConsole.WriteLineOrange($"ОЙ! {error}");
    },
    onWin: () =>
    {
        GameConsole.WriteLinePink("ПОЗДРАВЛЯЮ! ТЫ ПОБЕДИТЕЛЬ!");
    },
    onInput: Console.ReadLine);

game.Play();

string GetCheerWord()
{
    var cheerWords = new[]
    {
        "МОЛОДЕЦ",
        "УМНИЦА",
        "ОТЛИЧНО",
        "ВЕЛИКОЛЕПНО",
        "СУПЕР",
        "ВОТ ЭТО ДА",
        "КЛАСС",
        "ПРЕВОСХОДНО",
        "ОЧЕНЬ ХОРОШО"
    };

    return cheerWords.GetRandomElement();
}

