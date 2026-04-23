using AgroMonitoringApi.Dtos;
using FluentValidation;

namespace AgroMonitoringApi.Validators;

public class LogsListDtoValidator : AbstractValidator<LogsListDto>
{
    public LogsListDtoValidator()
    {
        RuleFor(x => x.Logs)
            .NotEmpty().WithMessage("You must provide at least one log.");
        
        RuleForEach(x => x.Logs).SetValidator(new LogDtoValidator());
    }
}