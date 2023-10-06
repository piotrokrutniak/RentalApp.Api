using Application.Interfaces;
using Domain.Models.Vehicles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public class DefaultVehiclesSeed
    {
        public static async Task SeedAsync(IGenericRepositoryAsync<Vehicle> repositoryAsync)
        {
            List<Vehicle> vehicles = new()
            {
                new Vehicle
                {
                    Vin = "5YJSA1H20FFP78357",
                    Make = "Tesla",
                    Model = "Model S",
                    Rate = 180,
                    LocationId = 1,
                },
                new Vehicle
                {
                    Vin = "5YJSA1DN0DFP11416",
                    Make = "Tesla",
                    Model = "Model S",
                    Rate = 180,
                    LocationId = 1,
                },
                new Vehicle
                {
                    Vin = "5YJSA1E25GF132382",
                    Make = "Tesla",
                    Model = "Model S",
                    Rate = 180,
                    LocationId = 1,
                },
                new Vehicle
                {
                    Vin = "5YJXCBE42GFS00614",
                    Make = "Tesla",
                    Model = "Model X",
                    Rate = 300,
                    LocationId = 1,
                },
                new Vehicle
                {
                    Vin = "5YJRE1A12A1000586",
                    Make = "Tesla",
                    Model = "Roadster",
                    Rate = 100,
                    LocationId = 2,
                },
                new Vehicle
                {
                    Vin = "5YJXCBE42GFS00614",
                    Make = "Tesla",
                    Model = "Model X",
                    Rate = 300,
                    LocationId = 3,
                },
                new Vehicle
                {
                    Vin = "5YJSA1H14EFP30592",
                    Make = "Tesla",
                    Model = "Model S",
                    Rate = 180,
                    LocationId = 4,
                },
                new Vehicle
                {
                    Vin = "5YJRE1A31B1001232",
                    Make = "Tesla",
                    Model = "Model Roadster",
                    Rate = 100,
                    LocationId = 5,
                },

            };

            if(await repositoryAsync.CountAsync() == 0)
            {
                foreach (Vehicle vehicle in vehicles)
                {
                    await repositoryAsync.AddAsync(vehicle);
                }
            }
        }
    }
}