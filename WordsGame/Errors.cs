namespace WordsGame;

public static class Errors
{
    public static string CannotBeEmpty => "СЛОВО НЕ МОЖЕТ БЫТЬ ПУСТЫМ";

    public static string CannotContainSpaces => "СЛОВО НЕ МОЖЕТ СОДЕРЖАТЬ ПРОБЕЛОВ";

    public static string ShouldStartWith(char firstChar) => 
        $"СЛОВО ДОЛЖНО НАЧИНАТЬСЯ С БУКВЫ [bold yellow]{firstChar.ToString().ToUpper()}[/]";

    public static string AlreadyUsed => "ТАКОЕ СЛОВО УЖЕ БЫЛО. ПОПРОБУЙ ДРУГОЕ";

    public static string DoesNotExist => "ТАКОГО СЛОВА НЕТ. ПОПРОБУЙ ДРУГОЕ";
}