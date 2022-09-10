using SimpleBlockChain.BlockChain.Interfaces;
using Spectre.Console;

namespace SimpleBlockChain.BlockChain;

internal class TransactionAdder : ITransactionAdder
{
    public void Add(BlockChain blockChain)
    {
        var input = AnsiConsole.Prompt(new TextPrompt<int>("What should be the value of the transaction?"));
        blockChain.AddTransaction(input);
    }
}