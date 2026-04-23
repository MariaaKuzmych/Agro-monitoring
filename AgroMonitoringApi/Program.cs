using AgroMonitoringApi;
using AgroMonitoringApi.Data;
using AgroMonitoringApi.Exceptions;
using AgroMonitoringApi.Services;
using AgroMonitoringApi.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<InitialState>(client => 
{
    client.Timeout = TimeSpan.FromSeconds(5);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
    
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging(); 
        options.LogTo(Console.WriteLine, LogLevel.Information);
    }
});


builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddValidatorsFromAssemblyContaining<LogDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<LogsListDtoValidator>();

builder.Services.AddKeyedScoped<ILogService, LogService>("DatabaseLogger");
builder.Services.AddKeyedScoped<ILogService, InitialState>("InitialStateLogger");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

LogEndpoints.MapUserEndpoints(app);

app.Run();