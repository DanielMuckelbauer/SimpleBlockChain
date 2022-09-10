using System.Security.Cryptography;
using System.Text;

namespace SimpleBlockChain.BlockChain;

public class Block
{
    public string Hash { get; private set; }
    public string PreviousHash { get; }

    private long _nonce;
    private readonly DateTime _timeStamp;
    public readonly List<Transaction> Transactions;

    public Block(DateTime timeStamp, List<Transaction> transactions, string previousHash)
    {
        _timeStamp = timeStamp;
        Transactions = transactions;
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
        var hashInput = PreviousHash + _timeStamp + Transactions + _nonce;
        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashInput));
        return Convert.ToHexString(hash);
    }
}