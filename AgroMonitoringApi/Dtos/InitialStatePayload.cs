namespace AgroMonitoringApi.Dtos;

public class InitialStatePayload
{
    public string Key { get; set; }
    public string Value { get; set; }

    public static IEnumerable<InitialStatePayload> CastDto(LogDto dto)
    {
        return new List<InitialStatePayload>()
        { 
            new InitialStatePayload { Key = "temperature", Value = dto.Temperature.ToString() }, 
            new InitialStatePayload { Key = "humidity", Value = dto.Humidity.ToString() },
            new InitialStatePayload { Key = "light", Value = dto.Light.ToString() },
            new InitialStatePayload { Key = "status", Value = dto.Status.ToString() },
            new InitialStatePayload { Key = "soilStatus", Value = dto.SoilStatus.ToString() },
            new InitialStatePayload { Key = "ventilation", Value = dto.Ventilation.ToString() },
            new InitialStatePayload { Key = "watering", Value = dto.Watering.ToString() },
            new InitialStatePayload { Key = "window", Value = dto.Window.ToString() },
            new InitialStatePayload { Key = "phytolamp", Value = dto.Phytolamp.ToString() }            
        };
    }
    
    public static IEnumerable<InitialStatePayload> CastDtoList(LogsListDto list)
    {
        var logs = new List<InitialStatePayload>();
        foreach (var dto in list.Logs)
        {
            var chunk = new  List<InitialStatePayload>()
            {
                new InitialStatePayload { Key = "temperature", Value = dto.Temperature.ToString() },
                new InitialStatePayload { Key = "humidity", Value = dto.Humidity.ToString() },
                new InitialStatePayload { Key = "light", Value = dto.Light.ToString() },
                new InitialStatePayload { Key = "status", Value = dto.Status.ToString() },
                new InitialStatePayload { Key = "soilStatus", Value = dto.SoilStatus.ToString() },
                new InitialStatePayload { Key = "ventilation", Value = dto.Ventilation.ToString() },
                new InitialStatePayload { Key = "watering", Value = dto.Watering.ToString() },
                new InitialStatePayload { Key = "window", Value = dto.Window.ToString() },
                new InitialStatePayload { Key = "phytolamp", Value = dto.Phytolamp.ToString() }
            };
            logs.AddRange(chunk);
        }

        return logs;
    }
}