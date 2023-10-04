using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Vehicles;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Commands
{
    public partial class CreateVehicleCommand : IRequest<Response<int>>
    {
        public string Vin { set; get; }
        public string Make { set; get; }
        public string Model { set; get; }
        public decimal Rate { set; get; }
        public int LocationId { set; get; }
    }

    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Response<int>>
    {
        private readonly IVehicleRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public CreateVehicleCommandHandler(IVehicleRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            Vehicle entity = _mapper.Map<Vehicle>(request);

            await _repository.AddAsync(entity);

            return new Response<int>(entity.Id);
        }
    }
}
