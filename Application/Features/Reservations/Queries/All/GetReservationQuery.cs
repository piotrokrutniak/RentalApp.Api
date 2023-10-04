using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Queries.All
{
    public class GetReservationQuery : IRequest<PagedResponse<IEnumerable<GetReservationViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
    }
    public class GetReservationsQueryHandler : IRequestHandler<GetReservationQuery, PagedResponse<IEnumerable<GetReservationViewModel>>>
    {
        private readonly IReservationRepositoryAsync _repository;
        private readonly IMapper _mapper;
        public GetReservationsQueryHandler(IReservationRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetReservationViewModel>>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            int entityCount = await _repository.CountAsync();
            int lastPage = GetMaxPage(request.PageSize, entityCount);
            request.PageNumber = ValidatePageNumber(request, lastPage);

            var validFilter = _mapper.Map<GetReservationParameter>(request);
            var entity = await _repository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var entityViewModel = _mapper.Map<IEnumerable<GetReservationViewModel>>(entity);
            return new PagedResponse<IEnumerable<GetReservationViewModel>>(entityViewModel, validFilter.PageNumber, validFilter.PageSize, lastPage);
        }

        private static int ValidatePageNumber(GetReservationQuery request, int lastPage)
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
