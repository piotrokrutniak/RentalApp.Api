using Domain.Models.Vehicles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IVehicleRepositoryAsync : IGenericRepositoryAsync<Vehicle>
    {
        Task<Vehicle> GetByVinAsync(string vin);
        Task<IReadOnlyList<Vehicle>> GetPagedReponseAsync(int pageNumber, int pageSize, string model = "");
    }
}
