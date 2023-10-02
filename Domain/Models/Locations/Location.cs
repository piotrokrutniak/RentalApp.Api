using Domain.Common;
using Domain.Models.Vehicles;
using System.Collections.Generic;

namespace Domain.Models.Locations
{
    public class Location : AuditableBaseEntity
    {
        public Location() { }
        public string Name { get; set; }
        public string Street { get; set; }
        public int Building { get; set; }
        public string City { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }
    }
}
