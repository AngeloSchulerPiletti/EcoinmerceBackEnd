using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Application.Services.Token;
using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Infra.Repository;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;
using Ecoinmerce.SmartContractSubscriber;
using Microsoft.EntityFrameworkCore;
using Ecoinmerce.Services.WalletManager.Interfaces;
using Ecoinmerce.Services.WalletManager;

IHost host = Host.CreateDefaultBuilder(args)
                 .UseWindowsService()
                 .ConfigureServices((hostContext, services) =>
                 {
                     IConfiguration configuration = hostContext.Configuration;

                     var relativePath = $"..\\";
                     var absolutePath = Path.GetFullPath(relativePath);

                     IConfigurationRoot sharedConfiguration = new ConfigurationBuilder()
                           .SetBasePath(absolutePath)
                           .AddJsonFile($"blockchainSettings.json", optional: false, reloadOnChange: true)
                           .Build();

                     services.Configure<BlockchainSetting>(sharedConfiguration);

                     services.AddHttpContextAccessor();

                     services.AddDbContext<EcommerceContext>(options => options
                                                                        //.UseLazyLoadingProxies()
                                                                        .UseSqlServer(configuration.GetConnectionString("Default")));

                     services.AddSingleton(configuration.GetSection("TokenSecrets").Get<TokenSecretsSetting>());
                     services.AddSingleton(configuration.GetSection("HdWalletCredentials").Get<HdWalletCredentialSetting>());

                     services.AddScoped<ITokenServiceEcommerceAdmin, TokenServiceEcommerceAdmin>()
                             .AddScoped<ITokenServiceEcommerceManager, TokenServiceEcommerceManager>()
                             .AddScoped<ITokenServiceEcommerce, TokenServiceEcommerce>()
                             .AddScoped<IHdWalletManager, HdWalletManager>()
                             .AddScoped<IPurchaseRepository, PurchaseRepository>()
                             .AddScoped<IPurchaseEventFailRepository, PurchaseEventFailRepository>();

                     services.AddHostedService<Worker>();
                 })
                 .Build();

await host.RunAsync();