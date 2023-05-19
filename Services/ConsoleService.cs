using Console = System.Console;

namespace BTCWalletMiner.Services;

public class ConsoleService
{
    public void SetForeGroundColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public void SetBackGroundColor(ConsoleColor color)
    {
        Console.BackgroundColor = color;
    }

    public void WriteAndReset(string message)
    {
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void ColorThenWriteAndReset(ConsoleColor color,string message)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}