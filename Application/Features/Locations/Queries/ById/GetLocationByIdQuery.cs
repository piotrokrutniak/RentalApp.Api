using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Models.Locations;
using Application.Exceptions;

namespace Application.Features.Images.Querys
{
    public partial class GetLocationByIdQuery : IRequest<Response<Location>>
    {
        public int Id { get; set; }
    }

    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, Response<Location>>
    {
        private readonly ILocationRepositoryAsync _locationRepository;
        public GetLocationByIdQueryHandler(ILocationRepositoryAsync locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<Response<Location>> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            Location location = await _locationRepository.GetByIdAsync(request.Id) ?? throw new ApiException($"Product with Id \"{request.Id}\" not found.");
            return new Response<Location>(location);
        }
    }
}
