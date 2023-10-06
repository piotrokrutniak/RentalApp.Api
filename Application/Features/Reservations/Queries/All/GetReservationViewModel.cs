using Domain.Models.Locations;
using Domain.Models.Vehicles;
using System;

namespace Application.Features.Reservations.Queries.All
{
    public class GetReservationViewModel
    {
        public int Id { get; set; }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public string Email { get; set; }
        public decimal Fee { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
