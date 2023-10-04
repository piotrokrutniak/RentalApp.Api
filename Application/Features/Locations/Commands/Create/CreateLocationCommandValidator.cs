using Application.Features.Locations.Commands.Create;
using Application.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Locations.Commands.Create
{
    internal class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
    {
        private readonly ILocationRepositoryAsync _repository;
        public CreateLocationCommandValidator(ILocationRepositoryAsync repositoryAsync)
        {
            _repository = repositoryAsync;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50);

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Active)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
