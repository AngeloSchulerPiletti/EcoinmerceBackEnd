using AutoMapper;
using BarterHash.Domain.AutoMapperProfiles;
using BarterHash.Infra.Repository;
using BarterHash.Infra.Repository.Database.Context;
using BarterHash.Infra.Repository.Interfaces;
using BarterHash.SmartContractSubscriber;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;

        var optionBuilder = new DbContextOptionsBuilder<PurchaseContext>();
        optionBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        services.AddSingleton(x => new PurchaseContext(optionBuilder.Options));

        var mapperConfiguration = new MapperConfiguration(mc => mc.AddProfile(new PurchaseMappingProfile()));
        IMapper mapper = mapperConfiguration.CreateMapper();
        services.AddSingleton(mapper);

        services.AddHostedService<Worker>().AddSingleton<IPurchaseRepository, PurchaseRepository>();
    })
    .Build();

await host.RunAsync();