using Application.Filters;

namespace Application.Features.Vehicles.Queries.All
{
    public class GetVehicleParameter : RequestParameter
    {
        public string Model { get; set; }
    }
}
