using Spectre.Console;

namespace WordsGame;

internal static class GameConsole
{ 
    public static void WriteLineOrange(string? message)
    {
        AnsiConsole.MarkupLine($"[bold darkorange]{message}[/]");
    }

    public static void WriteLineGreen(string message)
    {
        AnsiConsole.MarkupLine($"[bold green]{message}[/]");
    }

    public static void WriteGreen(string message)
    {
        AnsiConsole.Markup($"[bold green]{message}[/]");
    }

    public static void WriteLineSilver(string definition)
    {
        AnsiConsole.MarkupLine($"[bold silver]{definition}[/]");
    }

    public static void WriteLinePink(string message)
    {
        AnsiConsole.MarkupLine($"[bold pink]{message}[/]");
    }

    public static void WriteLine(string? message = null)
    {
        Console.WriteLine(message);
    }
}