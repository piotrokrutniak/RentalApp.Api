using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Reservations;
using Domain.Models.Vehicles;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Commands.Create
{
    public partial class CreateReservationCommand : IRequest<Response<int>>
    {
        public int VehicleId { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Response<int>>
    {
        private readonly IReservationRepositoryAsync _repository;
        private readonly IVehicleRepositoryAsync _vehicleRepository;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandler(IReservationRepositoryAsync repository, IVehicleRepositoryAsync vehicleRepository, IMapper mapper)
        {
            _repository = repository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            Reservation entity = _mapper.Map<Reservation>(request);

            Vehicle vehicle = await _vehicleRepository.GetByIdAsync(entity.VehicleId) ?? throw new ApiException($"Vehicle with Id \"{request.VehicleId}\" not found.");
            entity.UpdateFee(vehicle);

            await _repository.AddAsync(entity);

            return new Response<int>(entity.Id);
        }
    }
}
