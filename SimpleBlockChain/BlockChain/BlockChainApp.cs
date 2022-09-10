using System.Xml;
using SimpleBlockChain.BlockChain.Interfaces;
using SimpleBlockChain.CLI;

namespace SimpleBlockChain.BlockChain;

public class BlockChainApp : IBlockChainApp
{
    private readonly IPrompter _prompter;
    private readonly ITransactionAdder _transactionAdder;
    private readonly IBlockMiner _miner;
    private readonly IPrinter _printer;

    private bool _quit;

    public BlockChainApp(IPrompter prompter, ITransactionAdder transactionAdder, IBlockMiner miner, IPrinter printer)
    {
        _prompter = prompter;
        _transactionAdder = transactionAdder;
        _miner = miner;
        _printer = printer;
    }

    public void Run()
    {
        var commands = CreateCommands();

        while (!_quit)
        {
            commands[_prompter.Prompt()]();
        }

        // AnsiConsole.Markup("Simple Block Chain\n");
        //
        // var blockChain = new BlockChain();
        //
        // CreateTree(blockChain);
        //
        // void CreateTree(BlockChain chain)
        // {
        //     var tree = new Tree("Blockchain");
        //     foreach (var block in chain.Chain)
        //     {
        //         var blockNode = CreateBlockNode(tree, block);
        //         AddTransactionNode(blockNode, block);
        //     }
        //
        //     AnsiConsole.Write(tree);
        //     Console.ReadLine();
        // }
        //
        // TreeNode CreateBlockNode(Tree tree, Block block)
        // {
        //     var blockNode = tree.AddNode("Block");
        //     blockNode.AddNode($"Previous Hash: {block.PreviousHash}");
        //     blockNode.AddNode($"Hash: {block.Hash}");
        //     return blockNode;
        // }
        //
        // void AddTransactionNode(TreeNode blockNode, Block block)
        // {
        //     var transactionNode = blockNode.AddNode("Transactions");
        //     foreach (var transaction in block.Transactions)
        //     {
        //         transactionNode.AddNode(transaction.Data.ToString());
        //     }
        // }
    }

    private Dictionary<CliCommand, Action> CreateCommands()
    {
        var blockChain = new BlockChain();
        return new()
        {
            { CliCommand.AddTransaction, () => _transactionAdder.Add(blockChain) },
            { CliCommand.MineBlock, () => _miner.Mine(blockChain) },
            { CliCommand.PrintBlockChain, () => _printer.Print(blockChain) },
            { CliCommand.Quit, () => _quit = true },
        };
    }
}