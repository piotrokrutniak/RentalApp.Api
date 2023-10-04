using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Vehicles;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Commands
{
    public partial class DeleteVehicleByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteVehicleByIdCommandHandler : IRequestHandler<DeleteVehicleByIdCommand, Response<int>>
    {
        private readonly IVehicleRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public DeleteVehicleByIdCommandHandler(IVehicleRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteVehicleByIdCommand request, CancellationToken cancellationToken)
        {
            Vehicle entity = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(entity);

            return new Response<int>(entity.Id);
        }
    }
}
