using AgroMonitoringApi.Dtos;

namespace AgroMonitoringApi.Services;

public class InitialState : ILogService
{
    private readonly string AccessKey;
    private readonly string BucketKey;
    private readonly string Endpoint;
    
    private readonly HttpClient _httpClient;
    
    public InitialState(HttpClient httpClient)
    {
        _httpClient = httpClient;
        AccessKey = "ist_k_IdK8gRp4nFzhPZ8sffiwZTrqkU-tNj";
        BucketKey = "PSDP44N6ULE4";
        Endpoint = $"https://groker.init.st/api/events?accessKey={AccessKey}&bucketKey={BucketKey}";
    }
    
    public async Task AddLogAsync(LogDto log)
    {
        var list  = InitialStatePayload.CastDto(log);
        
        var options = new ParallelOptions { MaxDegreeOfParallelism = 5 };
        int successCount = 0;
        
        await Parallel.ForEachAsync(list, options, async (log, cancellationToken) =>
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(Endpoint, log, cancellationToken);
            
                if (response.IsSuccessStatusCode)
                {
                    Interlocked.Increment(ref successCount); 
                }
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException("Failed to add log to initial state", ex);
            }
        });
    }

    public async Task BulkLogsAsync(LogsListDto dto)
    {
        var list  = InitialStatePayload.CastDtoList(dto);
        
        var options = new ParallelOptions { MaxDegreeOfParallelism = 5 };
        int successCount = 0;
        
        await Parallel.ForEachAsync(list, options, async (log, cancellationToken) =>
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(Endpoint, log, cancellationToken);
            
                if (response.IsSuccessStatusCode)
                {
                    Interlocked.Increment(ref successCount); 
                }
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException("Failed to add log to initial state", ex);
            }
        });
    }
}