using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AgroMonitoringApi.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        if (exception is BadHttpRequestException badRequestEx)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Invalid JSON Payload",
                Detail = "The request body contains invalid data types or malformed JSON. Check that your numbers are actually numbers.",
            };
            
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            
            return true; 
        }
        
        return false;
    }
}