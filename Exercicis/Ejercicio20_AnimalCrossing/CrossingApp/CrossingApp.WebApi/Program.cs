using CrossingApp.Infrastructure.Dependencies;
using CrossingApp.Application.Dependencies;
using CrossingApp.WebApi.Extensions;
using CrossingApp.CrossCutting.Dependecies;
using CrossingApp.Infrastructure.Callers;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationModule();
builder.Services.AddInfrastructureModule(config);
builder.Services.AddCrosCuttingModule(config);
builder.Services.AddConfigurations(config);
builder.Host.AddLoggingConfig();

builder.Services.AddHttpClient<ITypedHttpClient, TypedHttpClient>(client =>
{
    client.BaseAddress = new Uri(config["Urls:CrossingApi"]);
});

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
