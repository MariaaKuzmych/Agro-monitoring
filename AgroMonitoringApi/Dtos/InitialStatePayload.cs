namespace AgroMonitoringApi.Dtos;

public class InitialStatePayload
{
    public string Key { get; set; }
    public string Value { get; set; }

    public static IEnumerable<InitialStatePayload> CastDto(LogDto dto)
    {
        return new List<InitialStatePayload>()
        { 
            new InitialStatePayload { Key = "temperature", Value = dto.Temp.ToString() }, 
            new InitialStatePayload { Key = "humidity", Value = dto.Humi.ToString() },
            new InitialStatePayload { Key = "lux", Value = dto.Lux.ToString() },
            new InitialStatePayload { Key = "status", Value = dto.Status.ToString() } 
        };
    }
    
    public static IEnumerable<InitialStatePayload> CastDtoList(LogsListDto list)
    {
        var logs = new List<InitialStatePayload>();
        foreach (var dto in list.Logs)
        {
            var chunk = new  List<InitialStatePayload>()
            { 
                new InitialStatePayload { Key = "temperature", Value = dto.Temp.ToString() }, 
                new InitialStatePayload { Key = "humidity", Value = dto.Humi.ToString() },
                new InitialStatePayload { Key = "lux", Value = dto.Lux.ToString() },
                new InitialStatePayload { Key = "status", Value = dto.Status.ToString() } 
            };
            logs.AddRange(chunk);
        }

        return logs;
    }
}