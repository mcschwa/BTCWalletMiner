using ProgramSettings;
using ProgramBitcoin;

class Program
{
	static void Main(string[] args)
	{
		var Settings = new Settings();
		Settings.displayLogo();
		Settings.setColors();
		Settings.displayVersion();
		Settings.displayCredits();
		Console.ReadKey();
	}
}