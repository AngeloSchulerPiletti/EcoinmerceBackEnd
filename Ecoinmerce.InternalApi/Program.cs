using Ecoinmerce.Application.Business.Auth;
using Ecoinmerce.Application.BusinessInterfaces.Auth;
using Ecoinmerce.Application.TokenService;
using Ecoinmerce.Application.TokenService.Interface;
using Ecoinmerce.Domain.AutoMapperProfiles;
using Ecoinmerce.Domain.ValidatedMappers;
using Ecoinmerce.Domain.ValidatedMappers.Interfaces;
using Ecoinmerce.Infra.Repository;
using Ecoinmerce.Infra.Repository.Database.Context;
using Ecoinmerce.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<PurchaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddDbContext<EcommerceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAutoMapper(typeof(EcommerceMappingProfile));
builder.Services.AddAutoMapper(typeof(PurchaseMappingProfile));

//builder.Services.AddSingleton<IConfiguration>

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped <IPurchaseRepository, PurchaseRepository > ();
builder.Services.AddScoped <IEcommerceRepository, EcommerceRepository > ();
//builder.Services.AddScoped <IGenericRepository, GenericRepository> ();

builder.Services.AddScoped <ISignupBusiness, SignupBusiness > ();

builder.Services.AddScoped<IValidatedMappings, ValidatedMappings>();

builder.Services.AddScoped<ITokenServiceEcommerce, TokenServiceEcommerce>();
builder.Services.AddScoped <ITokenServiceUser, TokenServiceUser> ();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
