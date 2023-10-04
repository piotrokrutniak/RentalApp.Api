using Domain.Common;
using Domain.Models.Vehicles;
using Microsoft.AspNetCore.Identity;
using System;

namespace Domain.Models.Reservations
{
    public class Reservation : AuditableBaseEntity
    {
        public Reservation() { }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public IdentityUser User { get; set; }
        public Guid UserId { get; set; }
        public decimal Fee { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private decimal CalculateFee()
        {
            return Vehicle.Rate * (EndDate - StartDate).Days;
        }

        public void UpdateFee()
        {
            Fee = CalculateFee();
        }
    }
}
