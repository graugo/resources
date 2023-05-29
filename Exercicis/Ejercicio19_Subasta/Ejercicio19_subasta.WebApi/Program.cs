using Ejercicio19_Subasta.Infrastructure.Callers;
using Ejercicio19_Subasta.Infrastructure.Dependencies;
using Ejercicio19_Subasta.Application.Dependencies;
using Ejercicio19_Subasta.CrossCutting.Dependencies;
using Ejercicio19_subasta.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationModule();
builder.Services.AddCrosCuttingModule();
builder.Services.AddInfrastructureModule(config);

builder.Services.AddHttpClient<ITypedHttpClient, TypedHttpClient>(client =>
{
    client.BaseAddress = new Uri(config["Urls:PokeApi"]);
});

builder.Services.AddStackExchangeRedisCache(
    options => options.Configuration = config["Redis:Host"]);

builder.Services.AddMemoryCache();
builder.Host.AddLoggingConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
