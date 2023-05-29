using DDDCodeSample.Infrastructure.Contracts.Contracts;
using DDDCodeSample.Infrastructure.Implementations.Implementations;
using DDDCodeSample.ServiceLibrary.Contracts.Contracts;
using DDDCodeSample.ServiceLibrary.Implementations.Implementations;
using DDDCodeSample.WebApi.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IWeatherForecastMapper, WeatherForecastMapper>();
builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

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
