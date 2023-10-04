using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Vehicles;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Commands
{
    public partial class UpdateVehicleByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Vin { set; get; }
        public string Make { set; get; }
        public string Model { set; get; }
        public decimal Rate { set; get; }
        public int LocationId { set; get; }
    }

    public class UpdateVehicleByIdCommandHandler : IRequestHandler<UpdateVehicleByIdCommand, Response<int>>
    {
        private readonly IVehicleRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public UpdateVehicleByIdCommandHandler(IVehicleRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateVehicleByIdCommand request, CancellationToken cancellationToken)
        {
            Vehicle entity = await _repository.GetByIdAsync(request.Id);

            entity.Vin = request.Vin;
            entity.Make = request.Make;
            entity.Model = request.Model;
            entity.Rate = request.Rate;
            entity.LocationId = request.LocationId;

            await _repository.UpdateAsync(entity);

            return new Response<int>(entity.Id);
        }
    }
}
