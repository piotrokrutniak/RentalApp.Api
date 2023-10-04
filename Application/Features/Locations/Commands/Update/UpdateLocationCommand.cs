using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Models.Locations;

namespace Application.Features.Locations.Commands.Update
{
    public partial class UpdateLocationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int Building { get; set; }
        public string City { get; set; }
    }

    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Response<int>>
    {
        private readonly ILocationRepositoryAsync _locationRepository;
        private readonly IMapper _mapper;

        public UpdateLocationCommandHandler(ILocationRepositoryAsync locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            Location location = _mapper.Map<Location>(request);

            await _locationRepository.UpdateAsync(location);

            return new Response<int>(location.Id);
        }
    }
}
