using Domain.Common;
using Domain.Models.Locations;

namespace Domain.Models.Vehicles
{
    public class Vehicle : AuditableBaseEntity
    {
        public Vehicle() { }
        public string Vin { set; get; }
        public string Make { set; get; }
        public string Model { set; get; }
        public decimal Rate { set; get; }
        public int LocationId { set; get; }
        public Location CurrentLocation { set; get; }
    }
}
