namespace Application.Features.Vehicles.Queries.All
{
    public class GetVehicleViewModel
    {
        public int Id { get; set; }
        public string Vin { set; get; }
        public string Make { set; get; }
        public string Model { set; get; }
        public decimal Rate { set; get; }
        public int LocationId { set; get; }
    }
}
