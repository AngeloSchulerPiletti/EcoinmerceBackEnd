using Ecoinmerce.Application;
using Ecoinmerce.Application.Interfaces;
using Ecoinmerce.Application.Services;
using Ecoinmerce.Application.Services.Interfaces;
using Ecoinmerce.Application.Services.Text;
using Ecoinmerce.Application.Services.Text.Interfaces;
using Ecoinmerce.Application.Services.Token;
using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Domain.Validators;
using Ecoinmerce.Domain.Validators.Interfaces;
using Ecoinmerce.Infra.Api.Management.Middleware;
using Ecoinmerce.Infra.MailService;
using Ecoinmerce.Infra.MailService.Interfaces;
using Ecoinmerce.Infra.Repository;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;
using Ecoinmerce.Services.Mapper.AutoMapperProfiles;
using Ecoinmerce.Services.WalletManager;
using Ecoinmerce.Services.WalletManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddApiVersioning();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<PurchaseContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddDbContext<EcommerceContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddSingleton(builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
builder.Services.AddSingleton(builder.Configuration.GetSection("HdWalletCredentials").Get<HdWalletCredentials>());
builder.Services.AddSingleton(builder.Configuration.GetSection("ApiCredentials").Get<ApiCredentialSetting>());


var relativePath = $"..\\";
var absolutePath = Path.GetFullPath(relativePath);

IConfigurationRoot sharedConfiguration = new ConfigurationBuilder()
      .SetBasePath(absolutePath)
      .AddJsonFile($"blockchainSettings.json", optional: false, reloadOnChange: true)
      .Build();

builder.Services.Configure<BlockchainSetting>(sharedConfiguration);

builder.Services.AddSingleton<IHdWalletManager, HdWalletManager>();

builder.Services.AddAutoMapper(typeof(EcommerceMappingProfiles));

builder.Services.AddSingleton<IGenericValidatorExecutor, GenericValidatorExecutor>();

builder.Services.AddSingleton<IStringFormatterService, StringFormatterService>();
builder.Services.AddSingleton<ITokenServiceEcommerceAdmin, TokenServiceEcommerceAdmin>();
builder.Services.AddSingleton<ITokenServiceEcommerceManager, TokenServiceEcommerceManager>();
builder.Services.AddSingleton<ITokenServiceEcommerce, TokenServiceEcommerce>();

builder.Services.AddSingleton<IPaginationService, PaginationService>();
builder.Services.AddSingleton<IUserMail, UserMail>();
builder.Services.AddSingleton<IHdWalletManager, HdWalletManager>();

builder.Services.AddScoped<IEcommerceBusiness, EcommerceBusiness>();
builder.Services.AddScoped<IEcommerceAdminBusiness, EcommerceAdminBusiness>();
builder.Services.AddScoped<IEcommerceManagerBusiness, EcommerceManagerBusiness>();
builder.Services.AddScoped<IApiCredentialBusiness, ApiCredentialBusiness>();
builder.Services.AddScoped<ISmartContractBusiness, SmartContractBusiness>();

builder.Services.AddScoped<IEtherWalletRepository, EtherWalletRepository>();
builder.Services.AddScoped<IEcommerceRepository, EcommerceRepository>();
builder.Services.AddScoped<IEcommerceAdminRepository, EcommerceAdminRepository>();
builder.Services.AddScoped<IEcommerceManagerRepository, EcommerceManagerRepository>();
builder.Services.AddScoped<IApiCredentialRepository, ApiCredentialRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IPurchaseCheckRepository, PurchaseCheckRepository>();
builder.Services.AddScoped<IPurchaseEventRepository, PurchaseEventRepository>();
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

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
