using Application.Interfaces;
using FluentValidation;
using System;

namespace Application.Features.Reservations.Commands.Other.All
{
    public class CheckAvailabilityCommandValidator : AbstractValidator<CheckAvailabilityByModelCommand>
    {
        private readonly IDateTimeService _dateTimeService;
        public CheckAvailabilityCommandValidator(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(_dateTimeService.NowUtc.Date);

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(x => x.StartDate.AddDays(1));
        }
    }
}