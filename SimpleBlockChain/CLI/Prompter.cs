using Spectre.Console;

namespace SimpleBlockChain.CLI;

public class Prompter : IPrompter
{
    public CliCommand Prompt()
    {
        var input = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("What do you want to do?")
            .AddChoices( "Add Transaction", "Mine Block", "Print Chain", "Quit")
        );
        return MapInput(input);
    }

    private static CliCommand MapInput(string input)
        => input switch
        {
            "Add Transaction" => CliCommand.AddTransaction,
            "Mine Block" => CliCommand.MineBlock,
            "Print Chain" => CliCommand.PrintBlockChain,
            "Quit" => CliCommand.Quit,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null),
        };
}