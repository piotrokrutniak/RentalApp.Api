using Application.Interfaces;
using FluentValidation;

namespace Application.Features.Reservations.Commands.Other
{
    public class CheckAvailabilityCommandValidator : AbstractValidator<CheckAvailabilityCommand>
    {
        private readonly IDateTimeService _dateTimeService;
        public CheckAvailabilityCommandValidator(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(_dateTimeService.NowUtc);

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(x => x.StartDate.AddDays(1));
        }
    }
}