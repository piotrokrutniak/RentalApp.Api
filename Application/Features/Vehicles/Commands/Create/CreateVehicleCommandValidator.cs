using Application.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Commands.Create
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        private readonly IVehicleRepositoryAsync _repository;
        public CreateVehicleCommandValidator(IVehicleRepositoryAsync repositoryAsync)
        {
            _repository = repositoryAsync;

            RuleFor(x => x.Vin)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(17)
                .MustAsync((x, cancellation) => IsUnique(x)).WithMessage("Vehicle with this VIN already exists.");

            RuleFor(x => x.Make)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Model)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.LocationId)
                .GreaterThanOrEqualTo(0);
        }
        //Todo handle unique Vin

        private async Task<bool> IsUnique(string vin)
        {
            return await _repository.GetByVinAsync(vin) == null;
        }
    }
}
