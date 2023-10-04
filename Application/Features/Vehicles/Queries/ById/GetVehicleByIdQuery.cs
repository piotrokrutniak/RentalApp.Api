using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Models.Vehicles;
using Application.Exceptions;

namespace Application.Features.Vehicles.Queries.ById
{
    public partial class GetVehicleByIdQuery : IRequest<Response<Vehicle>>
    {
        public int Id { get; set; }
    }

    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, Response<Vehicle>>
    {
        private readonly IVehicleRepositoryAsync _repository;
        public GetVehicleByIdQueryHandler(IVehicleRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<Response<Vehicle>> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            Vehicle entity = await _repository.GetByIdAsync(request.Id) ?? throw new ApiException($"Vehicle with Id \"{request.Id}\" not found.");
            return new Response<Vehicle>(entity);
        }
    }
}
