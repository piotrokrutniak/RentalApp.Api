using Domain.Models.Reservations;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IReservationRepositoryAsync : IGenericRepositoryAsync<Reservation>
    {
        Task<bool> CheckAvailabilityAsync(DateTime start, DateTime end, int vehicleId);
    }
}
 