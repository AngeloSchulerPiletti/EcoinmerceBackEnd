using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Application.Services.Token;
using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Infra.MailService;
using Ecoinmerce.Infra.Repository.Database.Context;
using Microsoft.EntityFrameworkCore;
using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Application;
using Ecoinmerce.Infra.Repository.Interfaces;
using Ecoinmerce.Infra.Repository;
using Ecoinmerce.Services.WalletManager.Interfaces;
using Ecoinmerce.Services.WalletManager;
using Ecoinmerce.Utils.Json;
using System.Text.Json.Serialization;
using Ecoinmerce.Application.Services.Text.Interfaces;
using Ecoinmerce.Application.Services.Text;
using Ecoinmerce.Infra.MailService.Interfaces;
using Ecoinmerce.Application.Services.Interfaces;
using Ecoinmerce.Application.Services;
using Ecoinmerce.Services.Mapper.AutoMapperProfiles;
using Ecoinmerce.Infra.Ratings.Interfaces;
using Ecoinmerce.Infra.Ratings;
using Ecoinmerce.Services.StorageReader;
using Ecoinmerce.Services.StorageReader.Interfaces;
using Ecoinmerce.SmartContracts.Interfaces;
using Ecoinmerce.SmartContracts;

var builder = WebApplication.CreateBuilder(args);

//THIS NEED TO BE FIXED
var corsDisabled = "_corsDisabled";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsDisabled,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddControllersWithViews()
                .AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
                    )
                .AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new CultureSpecificQuotedDecimalConverter()));

builder.Services.AddControllers();
builder.Services.AddApiVersioning();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<EcommerceContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddSingleton(builder.Configuration.GetSection("EmailSetting").Get<EmailSetting>());
builder.Services.AddSingleton(builder.Configuration.GetSection("HdWalletCredentials").Get<HdWalletCredentialSetting>());
builder.Services.AddSingleton(builder.Configuration.GetSection("ApiCredentials").Get<ApiCredentialSetting>());
builder.Services.AddSingleton(builder.Configuration.GetSection("TokenSecrets").Get<TokenSecretsSetting>());
builder.Services.AddSingleton(builder.Configuration.GetSection("Ratings").Get<RatingsSettings>());
builder.Services.AddSingleton(builder.Configuration.GetSection("Storage").Get<StorageSettings>());


var relativePath = $"..\\";
var absolutePath = Path.GetFullPath(relativePath);

IConfigurationRoot sharedConfiguration = new ConfigurationBuilder()
      .SetBasePath(absolutePath)
      .AddJsonFile($"blockchainSettings.json", optional: false, reloadOnChange: true)
      .Build();

builder.Services.Configure<BlockchainSetting>(sharedConfiguration);

builder.Services.AddAutoMapper(typeof(EcommerceMappingProfiles));

builder.Services.AddSingleton<IStringFormatterService, StringFormatterService>();
builder.Services.AddSingleton<ITokenServiceEcommerceAdmin, TokenServiceEcommerceAdmin>();
builder.Services.AddSingleton<ITokenServiceEcommerceManager, TokenServiceEcommerceManager>();
builder.Services.AddSingleton<ITokenServiceEcommerce, TokenServiceEcommerce>();
builder.Services.AddSingleton<IStorageReader, StorageReader>();
builder.Services.AddSingleton<IBinReader, BinReader>();

builder.Services.AddSingleton<IRatingsService, RatingsService>();
builder.Services.AddSingleton<IPaginationService, PaginationService>();
builder.Services.AddSingleton<IUserMail, UserMail>();
builder.Services.AddSingleton<IHdWalletManager, HdWalletManager>();

builder.Services.AddScoped<IRatingsBusiness, RatingsBusiness>();
builder.Services.AddScoped<IEcommerceBusiness, EcommerceBusiness>();
builder.Services.AddScoped<IEcommerceAdminBusiness, EcommerceAdminBusiness>();
builder.Services.AddScoped<IEcommerceManagerBusiness, EcommerceManagerBusiness>();
builder.Services.AddScoped<IApiCredentialBusiness, ApiCredentialBusiness>();
builder.Services.AddScoped<ISmartContractBusiness, SmartContractBusiness>();
builder.Services.AddScoped<IPurchaseBusiness, PurchaseBusiness>();

builder.Services.AddScoped<IEtherWalletRepository, EtherWalletRepository>();
builder.Services.AddScoped<IEcommerceRepository, EcommerceRepository>();
builder.Services.AddScoped<IEcommerceAdminRepository, EcommerceAdminRepository>();
builder.Services.AddScoped<IEcommerceManagerRepository, EcommerceManagerRepository>();
builder.Services.AddScoped<IApiCredentialRepository, ApiCredentialRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IPurchaseCheckRepository, PurchaseCheckRepository>();
builder.Services.AddScoped<IPurchaseEventFailRepository, PurchaseEventFailRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.UseCors(corsDisabled);

app.MapControllers();


app.Run();