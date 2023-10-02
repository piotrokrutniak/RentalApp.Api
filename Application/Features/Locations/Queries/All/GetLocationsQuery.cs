using Application.Filters;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Locations.Queries.All
{
    public class GetLocationsQuery : IRequest<PagedResponse<IEnumerable<GetLocationsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
    }
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, PagedResponse<IEnumerable<GetLocationsViewModel>>>
    {
        private readonly ILocationRepositoryAsync _locationRepository;
        private readonly IMapper _mapper;
        public GetLocationsQueryHandler(ILocationRepositoryAsync locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetLocationsViewModel>>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            int locationCount = await _locationRepository.CountAsync();
            int lastPage = GetMaxPage(request.PageSize, locationCount);
            request.PageNumber = ValidatePageNumber(request, lastPage);

            var validFilter = _mapper.Map<GetLocationsParameter>(request);
            var location = await _locationRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var locationViewModel = _mapper.Map<IEnumerable<GetLocationsViewModel>>(location);
            return new PagedResponse<IEnumerable<GetLocationsViewModel>>(locationViewModel, validFilter.PageNumber, validFilter.PageSize, lastPage);
        }

        private int ValidatePageNumber(GetLocationsQuery request, int lastPage)
        private static int ValidatePageNumber(GetLocationsQuery request, int lastPage)
        {
            if (request.PageNumber > lastPage)
            {
                request.PageNumber = lastPage;
            }

            return request.PageNumber;
        }

        private int GetMaxPage(int pageSize, int totalCount)
        private static int GetMaxPage(int pageSize, int totalCount)
        {
            double rawCount = totalCount / pageSize;
            double rawCount = (double)totalCount/pageSize;

            return (int)Math.Ceiling(rawCount);
        }
    }
}
