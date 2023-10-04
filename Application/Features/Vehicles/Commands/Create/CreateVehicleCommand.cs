using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Vehicles;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Commands.Create
{
    public partial class CreateVehicleCommand : IRequest<Response<int>>
    {
        public string Vin { set; get; }
        public string Make { set; get; }
        public string Model { set; get; }
        public decimal Rate { set; get; }
        public int? LocationId { set; get; }
    }

    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Response<int>>
    {
        private readonly IVehicleRepositoryAsync _repository;
        private readonly ILocationRepositoryAsync _locationRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateVehicleCommandHandler(IVehicleRepositoryAsync repository, ILocationRepositoryAsync locationRepositoryAsync, IMapper mapper)
        {
            _repository = repository;
            _locationRepositoryAsync = locationRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            Vehicle entity = _mapper.Map<Vehicle>(request);

            if (entity.LocationId > 0) { 
                _ = await _locationRepositoryAsync.GetByIdAsync(entity.LocationId) ?? throw new ApiException($"Location with Id \"{request.LocationId}\" not found."); 
            }

            await _repository.AddAsync(entity);

            return new Response<int>(entity.Id);
        }
    }
}
