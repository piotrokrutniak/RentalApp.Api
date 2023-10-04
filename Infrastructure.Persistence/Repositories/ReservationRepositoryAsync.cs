using Application.Interfaces.Repositories;
using Domain.Models.Reservations;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ReservationRepositoryAsync : GenericRepositoryAsync<Reservation>, IReservationRepositoryAsync
    {
        private readonly DbSet<Reservation> _context;
        private readonly bool _inMemory;

        public ReservationRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext.Set<Reservation>();
            _inMemory = dbContext.Database.IsInMemory();
        }

        public override async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Include(x => x.Vehicle)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CheckAvailabilityAsync(DateTime start, DateTime end, int vehicleId)
        {
            if (_inMemory)
            {
                List<Reservation> reservations = await _context.Where(x => x.VehicleId == vehicleId).ToListAsync();
                return reservations.Where(x => IsOverlapping(x, start, end)).Any();
            }

            string query = @$"SELECT TOP 1 Id FROM Reservations WHERE (StartDate BETWEEN '{start}' AND '{end}' OR EndDate BETWEEN '{start}' AND '{end}') AND VehicleId={vehicleId}";
            return await _context.FromSqlRaw(query).AnyAsync();
        }

        private bool IsOverlapping(Reservation a, DateTime startDate, DateTime endDate)
        {
            bool start = a.StartDate <= startDate && startDate <= a.EndDate;
            bool end = a.StartDate <= endDate && endDate <= a.EndDate;

            return start || end;
        }
    }
}
