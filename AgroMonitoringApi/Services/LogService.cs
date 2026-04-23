using AgroMonitoringApi.Data;
using AgroMonitoringApi.Dtos;
using AgroMonitoringApi.Models;
using System;
using System.Globalization;

namespace AgroMonitoringApi.Services;

public interface ILogService
{
    Task AddLogAsync(LogDto log);
    Task BulkLogsAsync(LogsListDto dto);
}

public class LogService : ILogService
{
    private readonly AppDbContext ctx;
    
    public LogService(AppDbContext db)
    {
        ctx = db;
    }
    
    public async Task AddLogAsync(LogDto dto)
    {
        var entity = new LogEntity
        {
            Id = Guid.NewGuid(), 
            Time = DateTime.Now.ToUniversalTime(),
            Temp = double.Parse(dto.Temp, CultureInfo.InvariantCulture),
            Humi = double.Parse(dto.Humi, CultureInfo.InvariantCulture),
            Lux = dto.Lux,
            Status = dto.Status
        };

        ctx.Logs.Add(entity);
        await ctx.SaveChangesAsync();
    }
    
    public async Task BulkLogsAsync(LogsListDto dto)
    {
        var entities = dto.Logs.Select(dto => new LogEntity
        {
            Id = Guid.NewGuid(),
            Time = DateTime.Now.ToUniversalTime(),
            Temp = double.Parse(dto.Temp, CultureInfo.InvariantCulture),
            Humi = double.Parse(dto.Humi, CultureInfo.InvariantCulture),
            Lux = dto.Lux,
            Status = dto.Status
        }).ToList();
        
        ctx.Logs.AddRange(entities);
        await ctx.SaveChangesAsync();
    }
}