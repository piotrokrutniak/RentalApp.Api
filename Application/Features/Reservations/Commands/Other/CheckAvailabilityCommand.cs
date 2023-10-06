using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Reservations;
using Domain.Models.Vehicles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Commands.Other
{
    public partial class CheckAvailabilityCommand : IRequest<Response<bool>>
    {
        public string Model { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CheckAvailabilityCommandHandler : IRequestHandler<CheckAvailabilityCommand, Response<bool>>
    {
        private readonly IReservationRepositoryAsync _repository;
        private readonly IVehicleRepositoryAsync _vehicleRepository;
        private readonly IMapper _mapper;

        public CheckAvailabilityCommandHandler(IReservationRepositoryAsync repository, IVehicleRepositoryAsync vehicleRepository, IMapper mapper)
        {
            _repository = repository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CheckAvailabilityCommand request, CancellationToken cancellationToken)
        {
            return new Response<bool>(await _repository.CheckAvailabilityByModelAsync(request.StartDate, request.EndDate, request.Model));
        }
    }
}
