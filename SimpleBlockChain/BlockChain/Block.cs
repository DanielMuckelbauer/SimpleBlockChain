using System.Security.Cryptography;
using System.Text;

namespace SimpleBlockChain.BlockChain;

public class Block
{
    public string Hash { get; set; }
    public string PreviousHash { get; set; }

    private long _nonce;
    private DateTime _timeStamp;
    private List<Transaction> _transactions;

    public Block(DateTime timeStamp, List<Transaction> transactions, string previousHash = "")
    {
        _timeStamp = timeStamp;
        _transactions = transactions;
        _nonce = 0;
        PreviousHash = previousHash;
        Hash = CreateHash();
    }

    public void Mine()
    {
        while(Hash[..2] != "00")
        {
            ++_nonce;
            Hash = CreateHash();
        }
        Console.WriteLine("Block calculated.");
    }

    private string CreateHash()
    {
        using var sha256 = SHA256.Create();
        var hashInput = PreviousHash + _timeStamp + _transactions + _nonce;
        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashInput));
        return Encoding.Default.GetString(hash);
    }
}