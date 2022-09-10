using Spectre.Console;

namespace SimpleBlockChain.CLI;

public class Prompter : IPrompter
{
    public CliCommand Prompt()
    {
        var input = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("What do you want to do?")
            .AddChoices( CliCommandStrings.AddTransaction, CliCommandStrings.MineBlock, CliCommandStrings.PrintChain, CliCommandStrings.Quit));
        return MapInput(input);
    }

    private static CliCommand MapInput(string input)
        => input switch
        {
            CliCommandStrings.AddTransaction => CliCommand.AddTransaction,
            CliCommandStrings.MineBlock => CliCommand.MineBlock,
            CliCommandStrings.PrintChain => CliCommand.PrintBlockChain,
            CliCommandStrings.Quit => CliCommand.Quit,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null),
        };
}