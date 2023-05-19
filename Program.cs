using BTCWalletMiner.Models;
using BTCWalletMiner.Services;

class Program
{
	private readonly ConsoleService _consoleService;

    private Program(ConsoleService consoleService)
    {
		_consoleService = consoleService;
    }

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
            _consoleService.ColorThenWriteAndReset(ConsoleColor.Red, "Input invalid. Please try again");
            requestBitcoinAddress();
		}

		void InputConfirm(string address)
		{
			Console.Write("Do you confirm that " + address + " is your address: ");
			string userInput = Console.ReadLine();

			if (userInput == "yes")
			{
				Settings.userBitcoinAddress.SetAddress(userInput); //set the address

                _consoleService.ColorThenWriteAndReset(ConsoleColor.Green, "Address confirmed.");

				mineBtc();
			}
			else
			{
                _consoleService.ColorThenWriteAndReset(ConsoleColor.Red, "Address not confirmed.");
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
            _consoleService.ColorThenWriteAndReset(ConsoleColor.DarkCyan, "[+]");
			Console.Write(" " + randomBtcAddress(randomNumber()) + " ");
			if (rnd.Next(0, 100) == 0)
			{
				Mine = false;
				
                _consoleService.ColorThenWriteAndReset(ConsoleColor.Green, "(" + btcAmountWon() + " BTC)");
				Console.ReadKey();
			}
			else
			{
                _consoleService.ColorThenWriteAndReset(ConsoleColor.Red, "(0 BTC)");
			}
			Console.WriteLine("");
		}
	}

	static void Main(string[] args)
	{
		var program = new Program(new ConsoleService());
        program.Entry();
	}
}