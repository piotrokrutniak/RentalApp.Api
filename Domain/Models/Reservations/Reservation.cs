using Domain.Common;
using Domain.Models.Vehicles;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Reservations
{
    public class Reservation : AuditableBaseEntity
    {
        public Reservation() { }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public decimal Fee { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private decimal CalculateFee(Vehicle vehicle)
        {
            return vehicle.Rate * (EndDate - StartDate).Days;
        }

        public void UpdateFee(Vehicle vehicle = null)
        {
            Fee = CalculateFee(vehicle ?? Vehicle);
        }
    }
}
