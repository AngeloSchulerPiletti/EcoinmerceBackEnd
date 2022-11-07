using Ecoinmerce.Domain.Settings;
using Ecoinmerce.Infra.MailService;
using Ecoinmerce.Infra.Repository.Database.Context;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
builder.Services.AddApiVersioning();
builder.Services.AddDbContext<PurchaseContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddDbContext<EcommerceContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddSingleton(builder.Configuration.GetSection("EmailSetting").Get<EmailSetting>());
builder.Services.AddSingleton(builder.Configuration.GetSection("TokenSecrets").Get<TokenSecretsSetting>());

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

app.MapControllers();


app.Run();