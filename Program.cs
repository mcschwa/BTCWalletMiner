using ProgramSettings;
using ProgramBitcoin;

class Program
{
	static void Main(string[] args)
	{
		var Settings = new Settings();
		Console.WriteLine(Settings.ProgramLogo);
	}
}