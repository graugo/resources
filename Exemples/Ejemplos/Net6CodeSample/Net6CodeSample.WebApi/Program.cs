using Net6CodeSample.Application.Depencies;
using Net6CodeSample.CrossCutting.Dependencies;
using Net6CodeSample.Infranstructure.Callers;
using Net6CodeSample.Infranstructure.Dependencies;
using Net6CodeSample.WebApi.Autentication;
using Net6CodeSample.WebApi.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddConfigurations(config);
builder.Host.AddLoggingConfig();
builder.Services.AddApplicationModule();
builder.Services.AddCrosCuttingModule();
builder.Services.AddInfrastructureModule(config);
builder.Services.AddHttpClient();

builder.Services.AddHttpClient<ITypedHttpClient, TypedHttpClient>(client => 
{
    client.BaseAddress = new Uri(config["Urls:Empire"]);
});

builder.Services.AddMemoryCache();
builder.Services.AddStackExchangeRedisCache(
    options => options.Configuration = config["Redis:Host"]);

builder.Services.AddScoped<IAutenticationService, AutenticationService>();

builder.Services.AddCustomAuthentication(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
