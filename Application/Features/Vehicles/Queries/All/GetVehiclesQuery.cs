using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Vehicles.Queries.All
{
    public class GetVehicleQuery : IRequest<PagedResponse<IEnumerable<GetVehicleViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
    }
    public class GetVehiclesQueryHandler : IRequestHandler<GetVehicleQuery, PagedResponse<IEnumerable<GetVehicleViewModel>>>
    {
        private readonly IVehicleRepositoryAsync _repository;
        private readonly IMapper _mapper;
        public GetVehiclesQueryHandler(IVehicleRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetVehicleViewModel>>> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
        {
            int entityCount = await _repository.CountAsync();
            int lastPage = GetMaxPage(request.PageSize, entityCount);
            request.PageNumber = ValidatePageNumber(request, lastPage);

            var validFilter = _mapper.Map<GetVehicleParameter>(request);
            var entity = await _repository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var entityViewModel = _mapper.Map<IEnumerable<GetVehicleViewModel>>(entity);
            return new PagedResponse<IEnumerable<GetVehicleViewModel>>(entityViewModel, validFilter.PageNumber, validFilter.PageSize, lastPage);
        }

        private static int ValidatePageNumber(GetVehicleQuery request, int lastPage)
        {
            if (request.PageNumber > lastPage)
            {
                request.PageNumber = lastPage;
            }

            return request.PageNumber;
        }

        private static int GetMaxPage(int pageSize, int totalCount)
        {
            double rawCount = (double)totalCount / pageSize;

            return (int)Math.Ceiling(rawCount);
        }
    }
}
