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
		Settings.displayFee();
		Settings.displayCredits();

		requestBitcoinAddress();
	}

	public void requestBitcoinAddress()
	{
		Console.Write("Please enter your Bitcoin address: ");
		inputUser();

		void inputUser()
		{
			var Settings = new Settings();
			var BTCcoinAddress = new BitcoinAddress();
			string userInput = Console.ReadLine();

			if (userInput.Length >= BTCcoinAddress.minLength && userInput.Length <= BTCcoinAddress.maxLength)
			{
				InputConfirm(userInput);
			}
			else
			{
				inputInvalid();
			}
		}

		void inputInvalid()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Input invalid. Please try again");
			Console.ResetColor();
			requestBitcoinAddress();
		}

		void InputConfirm(string address)
		{
			Console.Write("Do you confirm that " + address + " is your address: ");
			string userInput = Console.ReadLine();

			if (userInput == "yes")
			{
				Settings.userBitcoinAddress.setAddress(userInput); //set the address

				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Address confirmed.");
				Console.ResetColor();

				mineBtc();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Address not confirmed.");
				Console.ResetColor();
				requestBitcoinAddress();
			}
		}
	}

	public void mineBtc()
	{
		Boolean Mine = true;
		var BTCcoinAddress = new BitcoinAddress();
		Random rnd = new Random();

		int randomNumber()
		{
			int number = rnd.Next(BTCcoinAddress.minLength, BTCcoinAddress.maxLength);
			return number;
		}

		string randomBtcAddress(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
		}

		double btcAmountWon()
		{
			double BTC = (rnd.NextDouble());
			return BTC;
		}

		while (Mine)
		{
			Thread.Sleep(100);
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write("[+]");
			Console.ResetColor();
			Console.Write(" " + randomBtcAddress(randomNumber()) + " ");
			if (rnd.Next(0, 100) == 0)
			{
				Mine = false;

				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("(" + btcAmountWon() + " BTC)");
				Console.ResetColor();
				Console.ReadKey();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("(0 BTC)");
				Console.ResetColor();
			}
			Console.WriteLine("");
		}
	}

	static void Main(string[] args)
	{
		var Program = new Program();
		Program.Entry();
	}
}