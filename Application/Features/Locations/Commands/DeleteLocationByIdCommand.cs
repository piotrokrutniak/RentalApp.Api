using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Models.Locations;

namespace Application.Features.Images.Commands
{
    public partial class DeleteLocationByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteLocationByIdCommandHandler : IRequestHandler<DeleteLocationByIdCommand, Response<int>>
    {
        private readonly ILocationRepositoryAsync _locationRepository;
        public DeleteLocationByIdCommandHandler(ILocationRepositoryAsync locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<Response<int>> Handle(DeleteLocationByIdCommand request, CancellationToken cancellationToken)
        {
            Location location = await _locationRepository.GetByIdAsync(request.Id);

            await _locationRepository.DeleteAsync(location);

            return new Response<int>(location.Id);
        }
    }
}
