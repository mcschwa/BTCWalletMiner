namespace ProgramSettings
{
	public class Settings
	{
		public static double ProgramVersion = 0.1;
		public string ProgramLogo = @"
			______ _____ _____ _    _       _ _      _  ___  ____                 
			| ___ \_   _/  __ \ |  | |     | | |    | | |  \/  (_)                
			| |_/ / | | | /  \/ |  | | __ _| | | ___| |_| .  . |_ _ __   ___ _ __ 
			| ___ \ | | | |   | |/\| |/ _` | | |/ _ \ __| |\/| | | '_ \ / _ \ '__|
			| |_/ / | | | \__/\  /\  / (_| | | |  __/ |_| |  | | | | | |  __/ |   
			\____/  \_/  \____/\/  \/ \__,_|_|_|\___|\__\_|  |_/_|_| |_|\___|_|   
		";

		public void displayLogo()
		{
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine(ProgramLogo);
			Console.ResetColor();
		}

		public void displayVersion()
		{
			Console.WriteLine("Current version: v" + ProgramVersion);
		}

		public void displayCredits()
		{
			System.Console.OutputEncoding = System.Text.Encoding.UTF8; //allows the display of a copyright mark
			Console.WriteLine("Credits: Schwa/Rick Huisman © 2022");
		}

		public void setColors()
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}