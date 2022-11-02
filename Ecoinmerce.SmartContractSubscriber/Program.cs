using AutoMapper;
using Ecoinmerce.Infra.Blockchain;
using Ecoinmerce.Infra.Repository;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;
using Ecoinmerce.SmartContractSubscriber;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;

        //TODO: Trocar por uma inje��o de dependencia, assim t� cagado
        //var optionBuilder = new DbContextOptionsBuilder<PurchaseContext>();
        //optionBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        //services.AddDbContext(x => new PurchaseContext(optionBuilder.Options));

        //services.AddHostedService<Worker>().AddSingleton<IPurchaseRepository, PurchaseRepository>();
        //services.AddHostedService<Worker>().AddSingleton<IPurchaseEventFailRepository, PurchaseEventFailRepository>();

        var relativePath = $"..\\";
        var absolutePath = Path.GetFullPath(relativePath);

        IConfigurationRoot sharedConfiguration = new ConfigurationBuilder()
              .SetBasePath(absolutePath)
              .AddJsonFile($"blockchainSettings.json", optional: false, reloadOnChange: true)
              .Build();

        services.Configure<BlockchainSettings>(sharedConfiguration);
    })
    .Build();

await host.RunAsync();