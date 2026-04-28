namespace AgroMonitoringApi.Models;

public class LogEntity
{
    public Guid Id { get; set; } 
    public DateTime Time { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public float Light { get; set; }
    public string Status { get; set; } = string.Empty;
    public string SoilStatus { get; set; }
    public string Ventilation { get; set; }
    public string Watering { get; set; }
    public string Window { get; set; }
    public string Phytolamp { get; set; }
}