namespace ProgramBitcoin
{
	public class BitcoinAddress
	{
		public int minLength = 26;
		public int maxLength = 35;
		public string Address;

		public void setAddress(string address)
		{
			this.Address = address;
		}
	}

	public class BitcoinPrivateKey
	{
		public Int32 length = 256;
	}
}