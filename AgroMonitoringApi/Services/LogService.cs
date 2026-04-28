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
            Temperature = double.Parse(dto.Temperature, CultureInfo.InvariantCulture),
            Humidity = double.Parse(dto.Humidity, CultureInfo.InvariantCulture),
            Light = dto.Light,
            Status = dto.Status,
            SoilStatus = dto.SoilStatus,
            Ventilation = dto.Ventilation,
            Watering = dto.Watering,
            Window = dto.Window,
            Phytolamp = dto.Phytolamp
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
            Temperature = double.Parse(dto.Temperature, CultureInfo.InvariantCulture),
            Humidity = double.Parse(dto.Humidity, CultureInfo.InvariantCulture),
            Light = dto.Light,
            Status = dto.Status,
            SoilStatus = dto.SoilStatus,
            Ventilation = dto.Ventilation,
            Watering = dto.Watering,
            Window = dto.Window,
            Phytolamp = dto.Phytolamp
        }).ToList();
        
        ctx.Logs.AddRange(entities);
        await ctx.SaveChangesAsync();
    }
}