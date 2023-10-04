using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Reservations;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Commands.Delete
{
    public partial class DeleteReservationByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteReservationByIdCommandHandler : IRequestHandler<DeleteReservationByIdCommand, Response<int>>
    {
        private readonly IReservationRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public DeleteReservationByIdCommandHandler(IReservationRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteReservationByIdCommand request, CancellationToken cancellationToken)
        {
            Reservation entity = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(entity);

            return new Response<int>(entity.Id);
        }
    }
}
