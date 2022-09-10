using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleBlockChain.BlockChain.CLI;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services
            .AddScoped<IBlockChainApp, BlockChainApp>()
            .AddScoped<IPrompter, Prompter>())
    .Build();
using var serviceScope = host.Services.CreateScope();
var serviceProvider = serviceScope.ServiceProvider;
serviceProvider.GetRequiredService<IBlockChainApp>().Run();
