using AgroMonitoringApi.Dtos;
using AgroMonitoringApi.Services;
using AgroMonitoringApi.Validators;

namespace AgroMonitoringApi;

public static class LogEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/logs").WithTags("Logs");

        group.MapPost("/add", async (LogDto dto, [FromKeyedServices("DatabaseLogger")] ILogService dbLogger, [FromKeyedServices("InitialStateLogger")] ILogService initialStateLogger) =>
        {
            await dbLogger.AddLogAsync(dto);
            await initialStateLogger.AddLogAsync(dto);
            return Results.Ok("Log added.");
        }).AddEndpointFilter<ValidationFilter<LogDto>>();
        
        group.MapPost("/bulk", async (LogsListDto dto, [FromKeyedServices("DatabaseLogger")] ILogService dbLogger, [FromKeyedServices("InitialStateLogger")] ILogService initialStateLogger) =>
        {
            await dbLogger.BulkLogsAsync(dto);
            await initialStateLogger.BulkLogsAsync(dto);
            return Results.Ok("Logs bulked.");
            
        }).AddEndpointFilter<ValidationFilter<LogsListDto>>();
    }
}