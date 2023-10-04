using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Models.Locations;

namespace Application.Features.Locations.Commands.Create
{
    public partial class CreateLocationCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public int Building { get; set; }
        public string City { get; set; }
        public bool Active { get; set; }
    }
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Response<int>>
    {
        private readonly ILocationRepositoryAsync _locationRepository;
        private readonly IMapper _mapper;

        public CreateLocationCommandHandler(ILocationRepositoryAsync locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            Location location = _mapper.Map<Location>(request);

            await _locationRepository.AddAsync(location);

            return new Response<int>(location.Id);
        }
    }
}
