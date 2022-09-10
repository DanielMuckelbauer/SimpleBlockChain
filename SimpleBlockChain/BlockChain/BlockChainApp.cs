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