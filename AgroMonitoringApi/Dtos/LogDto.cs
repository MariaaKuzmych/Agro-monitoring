namespace AgroMonitoringApi.Dtos;

public record LogDto(string Temperature, string Humidity, float Light, string Status, string SoilStatus, string Ventilation, string Watering, string Window, string Phytolamp);