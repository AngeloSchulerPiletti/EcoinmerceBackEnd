using Ecoinmerce.Domain.Settings;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;

        //TODO: Trocar por uma injeção de dependencia, assim tá cagado
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

        services.Configure<BlockchainSetting>(sharedConfiguration);
    })
    .Build();

await host.RunAsync();