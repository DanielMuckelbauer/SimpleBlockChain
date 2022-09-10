using Spectre.Console;

namespace SimpleBlockChain.CLI;

public class Prompter : IPrompter
{
    public Actions Prompt()
    {
        var input = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("What do you want to do?")
            .AddChoices( "Add Transaction", "Mine Block", "Print Chain", "Quit")
        );
        return MapInput(input);
    }

    private static Actions MapInput(string input)
        => input switch
        {
            "Add Transaction" => Actions.AddTransaction,
            "Mine Block" => Actions.MineBlock,
            "Print Chain" => Actions.PrintBlockChain,
            "Quit" => Actions.Quit,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null),
        };
}