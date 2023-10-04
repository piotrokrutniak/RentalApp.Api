using Domain.Models.Vehicles;
using System;
using System.Collections.Generic;

namespace Application.Features.Locations.Queries.All
{
    public class GetLocationsViewModel
    {
        public virtual int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int Building { get; set; }
        public string City { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }
    }
}
