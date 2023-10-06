using Application.Features.Reservations.Commands.Other.All;
using Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Commands.Other.ById
{
    public class CheckAvailabilityByIdCommandValidator : AbstractValidator<CheckAvailabilityByIdCommand>
    {
        private readonly IDateTimeService _dateTimeService;
        public CheckAvailabilityByIdCommandValidator(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;

            RuleFor(x => x.VehicleId)
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
