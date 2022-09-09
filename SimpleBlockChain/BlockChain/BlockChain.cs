namespace SimpleBlockChain.BlockChain;

public class BlockChain
{
    private List<Transaction> _pendingTransactions = new();
    private List<Block> _chain;

    public BlockChain()
        => _chain = new() { GenerateGenesisBlock() };

    public void AddTransaction(int data)
        => _pendingTransactions.Add(new(data));

    public void CreateBlock()
    {
        var block = new Block(DateTime.Now, _pendingTransactions);
        block.Mine();
        block.PreviousHash = _chain.Last().Hash;
        _chain.Add(block);
    }

    private static Block GenerateGenesisBlock()
        => new(DateTime.Now, new(), "0");
}