using Domain.Models.Vehicles;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IVehicleRepositoryAsync : IGenericRepositoryAsync<Vehicle>
    {
        Task<Vehicle> GetByVinAsync(string vin);
    }
}
