using Domain.Models.Reservations;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IReservationRepositoryAsync : IGenericRepositoryAsync<Reservation>
    {
        Task<bool> CheckAvailabilityByIdAsync(DateTime start, DateTime end, int vehicleId);
        Task<bool> CheckAvailabilityByModelAsync(DateTime start, DateTime end, string model);
    }
}
 