using System.Globalization;
using AgroMonitoringApi.Dtos;
using FluentValidation;

namespace AgroMonitoringApi.Validators;

public class LogDtoValidator : AbstractValidator<LogDto>
{
    public LogDtoValidator()
    {        
        RuleFor(log => log.Temp)
            .NotEmpty()
            .Must(t => double.TryParse(t, NumberStyles.Float, CultureInfo.InvariantCulture, out _))
            .WithMessage("Temperature must be a valid number.");
        
        RuleFor(log => log.Humi)
            .NotEmpty()
            .Must(h => double.TryParse(h, NumberStyles.Float, CultureInfo.InvariantCulture, out var val) && val is >= 0 and <= 100)
            .WithMessage("Humidity must be between 0 and 100.");

        RuleFor(log => log.Lux).GreaterThanOrEqualTo(0);
        
        RuleFor(log => log.Status).NotEmpty();
    }
}