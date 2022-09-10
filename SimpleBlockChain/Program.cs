using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleBlockChain.BlockChain;
using SimpleBlockChain.BlockChain.Interfaces;
using SimpleBlockChain.CLI;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services
            .AddScoped<IBlockChainApp, BlockChainApp>()
            .AddScoped<IPrompter, Prompter>()
            .AddScoped<ITransactionAdder, TransactionAdder>()
            .AddScoped<IBlockMiner, BlockMiner>()
            .AddScoped<IPrinter, Printer>())
    .Build();
using var serviceScope = host.Services.CreateScope();
var serviceProvider = serviceScope.ServiceProvider;
serviceProvider.GetRequiredService<IBlockChainApp>().Run();
