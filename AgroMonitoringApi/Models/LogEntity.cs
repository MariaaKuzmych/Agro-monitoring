namespace AgroMonitoringApi.Models;

public class LogEntity
{
    public Guid Id { get; set; } 
    public DateTime Time { get; set; }
    public double Temp { get; set; }
    public double Humi { get; set; }
    public float Lux { get; set; }
    public string Status { get; set; } = string.Empty;
}