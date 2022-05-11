using ProgramSettings;
using ProgramBitcoin;

class Program
{
	public void Entry()
	{
		var Settings = new Settings();
		Settings.displayLogo();
		Settings.setColors();
		Settings.displayVersion();
		Settings.displayCredits();

		requestBitcoinAddress();
	}

	public void requestBitcoinAddress()
	{
		Console.Write("Please enter your Bitcoin address: ");
		inputUser();

		void inputInvalid()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Input invalid. Please try again");
			Console.ResetColor();
			requestBitcoinAddress();
		}

		void inputUser()
		{
			var BTCcoinAddress = new BitcoinAddress(); 
			string userInput = Console.ReadLine().ToString();

			if (userInput.Length >= BTCcoinAddress.minLength)
			{
				Console.WriteLine(userInput);
			}
			else
			{
				inputInvalid();
			}
		}
	}

	static void Main(string[] args)
	{
		var Program = new Program();
		Program.Entry();
	}
}