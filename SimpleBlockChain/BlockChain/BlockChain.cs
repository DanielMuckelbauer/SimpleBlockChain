namespace SimpleBlockChain.BlockChain;

public class BlockChain
{
    private List<Transaction> _pendingTransactions = new();
    public readonly List<Block> Chain;

    public BlockChain()
        => Chain = new() { GenerateGenesisBlock() };

    public void AddTransaction(string data)
        => _pendingTransactions.Add(new(data));

    public void CreateBlock()
    {
        var block = new Block(DateTime.Now, _pendingTransactions, Chain.Last().Hash);
        block.Mine();
        Chain.Add(block);
        _pendingTransactions = new();
    }

    private static Block GenerateGenesisBlock()
        => new(DateTime.Now, new(), "0");
}