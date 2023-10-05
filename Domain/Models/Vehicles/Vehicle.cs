using Domain.Common;
using Domain.Models.Locations;
using Domain.Models.Reservations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Vehicles
{
    public class Vehicle : AuditableBaseEntity
    {
        public Vehicle() { }

        [Column(TypeName = "nvarchar(17)")]
        public string Vin { set; get; }
        public string Make { set; get; }
        public string Model { set; get; }
        public decimal Rate { set; get; }
        public int LocationId { set; get; }
        public Location CurrentLocation { set; get; }
        public virtual List<Reservation> Reservations { set; get; }
    }
}
