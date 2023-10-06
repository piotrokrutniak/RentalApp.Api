using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Reservations;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Commands.Update
{
    public partial class UpdateReservationByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class UpdateReservationByIdCommandHandler : IRequestHandler<UpdateReservationByIdCommand, Response<int>>
    {
        private readonly IReservationRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public UpdateReservationByIdCommandHandler(IReservationRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateReservationByIdCommand request, CancellationToken cancellationToken)
        {
            Reservation entity = await _repository.GetByIdAsync(request.Id);

            entity.VehicleId = request.VehicleId;
            entity.Email = request.Email;
            entity.StartDate = request.StartDate;
            entity.EndDate = request.EndDate;

            entity.UpdateFee();


            await _repository.UpdateAsync(entity);

            return new Response<int>(entity.Id);
        }
    }
}
