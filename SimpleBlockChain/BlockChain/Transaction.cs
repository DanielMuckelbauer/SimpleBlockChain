namespace SimpleBlockChain.BlockChain;

public class Transaction
{
    public int Data { get; set; }

    public Transaction(int data)
        => Data = data;
}