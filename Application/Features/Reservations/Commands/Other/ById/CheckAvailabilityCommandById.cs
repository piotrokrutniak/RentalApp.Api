using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Commands.Other.ById
{
    public partial class CheckAvailabilityByIdCommand : IRequest<Response<bool>>
    {
        public int VehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CheckAvailabilityByIdCommandHandler : IRequestHandler<CheckAvailabilityByIdCommand, Response<bool>>
    {
        private readonly IReservationRepositoryAsync _repository;
        private readonly IVehicleRepositoryAsync _vehicleRepository;
        private readonly IMapper _mapper;

        public CheckAvailabilityByIdCommandHandler(IReservationRepositoryAsync repository, IVehicleRepositoryAsync vehicleRepository, IMapper mapper)
        {
            _repository = repository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CheckAvailabilityByIdCommand request, CancellationToken cancellationToken)
        {
            return new Response<bool>(await _repository.CheckAvailabilityByIdAsync(request.StartDate, request.EndDate, request.VehicleId));
        }
    }
}
