using AutoMapper;
using Ecoinmerce.Domain.AutoMapperProfiles;
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

        //TODO: Trocar por uma injeção de dependencia, assim tá cagado
        var optionBuilder = new DbContextOptionsBuilder<PurchaseContext>();
        optionBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        services.AddSingleton(x => new PurchaseContext(optionBuilder.Options));

        //TODO: Trocar pela maneira utilizada no InternalApi
        var mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new PurchaseMappingProfile()));
        IMapper mapper = mapperConfiguration.CreateMapper();
        services.AddSingleton(mapper);

        services.AddHostedService<Worker>().AddSingleton<IPurchaseRepository, PurchaseRepository>();

        var relativePath = $"..\\";
        var absolutePath = Path.GetFullPath(relativePath);

        IConfigurationRoot builder = new ConfigurationBuilder()
              .SetBasePath(absolutePath)
              .AddJsonFile($"blockchainSettings.json", optional: false, reloadOnChange: true)
              .Build();

        services.Configure<BlockchainSettings>(builder);
    })
    .Build();

await host.RunAsync();