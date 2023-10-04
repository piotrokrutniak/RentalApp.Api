﻿using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Reservations;
using Domain.Models.Vehicles;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservations.Commands
{
    public partial class UpdateReservationByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Guid UserId { get; set; }
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
            entity.UserId = request.UserId;
            entity.StartDate = request.StartDate;
            entity.EndDate = request.EndDate;

            entity.UpdateFee();


            await _repository.UpdateAsync(entity);

            return new Response<int>(entity.Id);
        }
    }
}
