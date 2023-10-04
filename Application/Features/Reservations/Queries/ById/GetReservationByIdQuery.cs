using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Domain.Models.Reservations;
using Application.Exceptions;

namespace Application.Features.Reservations.Queries.ById
{
    public partial class GetReservationByIdQuery : IRequest<Response<Reservation>>
    {
        public int Id { get; set; }
    }

    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, Response<Reservation>>
    {
        private readonly IReservationRepositoryAsync _repository;
        public GetReservationByIdQueryHandler(IReservationRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<Response<Reservation>> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            Reservation entity = await _repository.GetByIdAsync(request.Id) ?? throw new ApiException($"Reservation with Id \"{request.Id}\" not found.");
            return new Response<Reservation>(entity);
        }
    }
}
