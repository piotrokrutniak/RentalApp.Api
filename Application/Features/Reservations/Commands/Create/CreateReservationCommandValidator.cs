using Application.Features.Reservations.Commands.Create;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Commands.Create
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        private readonly IReservationRepositoryAsync _repository;
        private readonly IDateTimeService _dateTimeService;
        public CreateReservationCommandValidator(IReservationRepositoryAsync repositoryAsync, IDateTimeService dateTimeService)
        {
            _repository = repositoryAsync;
            _dateTimeService = dateTimeService;

            RuleFor(x => x.VehicleId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(_dateTimeService.NowUtc);

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(x => x.StartDate.AddDays(1));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x)
                .MustAsync((x, cancellation) => IsAvailable(x)).WithMessage("Vehicle not available during this period.");
        }

        public async Task<bool> IsAvailable(CreateReservationCommand command)
        {
            return !await _repository.CheckAvailabilityAsync(command.StartDate, command.EndDate, command.VehicleId);
        }
    }
}
