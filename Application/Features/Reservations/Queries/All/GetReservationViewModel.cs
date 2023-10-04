﻿using Domain.Models.Vehicles;
using Microsoft.AspNetCore.Identity;
using System;

namespace Application.Features.Reservations.Queries.All
{
    public class GetReservationViewModel
    {
        public int Id { get; set; }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public string UserEmail { get; set; }
        public decimal Fee { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
