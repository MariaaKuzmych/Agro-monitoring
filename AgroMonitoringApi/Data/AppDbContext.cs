using AgroMonitoringApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroMonitoringApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<LogEntity> Logs => Set<LogEntity>(); 
}