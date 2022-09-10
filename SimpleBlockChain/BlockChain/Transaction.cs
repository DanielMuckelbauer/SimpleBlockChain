namespace SimpleBlockChain.BlockChain;

public class Transaction
{
    public string Data { get; }

    public Transaction(string data)
        => Data = data;
}