namespace BTCWalletMiner.Models;

public class BitcoinAddress
{
    public int minLength = 26;
    public int maxLength = 35;
    private string Address {get; set;}

    public void SetAddress(string address)
    {
        Address = address;
    }
}

public class BitcoinPrivateKey
{
    public int Length = 256;
}