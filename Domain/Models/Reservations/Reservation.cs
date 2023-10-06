﻿using Domain.Common;
using Domain.Models.Locations;
using Domain.Models.Vehicles;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Reservations
{
    public class Reservation : AuditableBaseEntity
    {
        public Reservation()
        {
            Fee = CalculateFee(Vehicle);
        }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public decimal Fee { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private decimal CalculateFee(Vehicle vehicle)
        {
            return vehicle == null ? 0.00m : vehicle.Rate * (EndDate - StartDate).Days;
        }

        public void UpdateFee(Vehicle vehicle = null)
        {
            Fee = CalculateFee(vehicle ?? Vehicle);
        }
    }
}
