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
		Settings.displayFee();

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
				Console.ReadKey();
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

	static void Main(string[] args)
	{
		var Program = new Program();
		Program.Entry();
	}
}