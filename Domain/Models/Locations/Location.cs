using Domain.Common;
using Domain.Models.Reservations;
using Domain.Models.Vehicles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Locations
{
    public class Location : AuditableBaseEntity
    {
        public Location() { }
        public string Name { get; set; }
        public string Street { get; set; }
        public int Building { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public bool Active { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
