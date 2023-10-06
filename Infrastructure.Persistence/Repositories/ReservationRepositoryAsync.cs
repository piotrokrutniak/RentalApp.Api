using Application.Interfaces.Repositories;
using Domain.Models.Reservations;
using Domain.Models.Vehicles;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ReservationRepositoryAsync : GenericRepositoryAsync<Reservation>, IReservationRepositoryAsync
    {
        private readonly DbSet<Reservation> _context;
        private readonly DbSet<Vehicle> _vehicleContext;
        private readonly bool _inMemory;

        public ReservationRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext.Set<Reservation>();
            _vehicleContext = dbContext.Set<Vehicle>();
            _inMemory = dbContext.Database.IsInMemory();
        }

        public override async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Include(x => x.Vehicle)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CheckAvailabilityByIdAsync(DateTime start, DateTime end, int vehicleId)
        {
            if (_inMemory)
            {
                List<Reservation> reservations = await _context.Where(x => x.VehicleId == vehicleId).ToListAsync();
                return reservations.Where(x => IsOverlapping(x, start, end)).Any();
            }

            string query = @$"SELECT TOP 1 Id FROM Reservations WHERE (StartDate BETWEEN '{start}' AND '{end}' OR EndDate BETWEEN '{start}' AND '{end}') AND VehicleId IN ({vehicleId})";
            return await _context.FromSqlRaw(query).AnyAsync();
        }

        public async Task<bool> CheckAvailabilityByModelAsync(DateTime start, DateTime end, string model)
        {
            List<Vehicle> vehicles = await _vehicleContext.Where(x => model == null || x.Model.Contains(model)).ToListAsync();

            if (!vehicles.Any())
            {
                throw new ArgumentException($"No available vehicles with matching model \"{model}\" found.");
            }

            if (_inMemory)
            {
                bool available = false;
                foreach (Vehicle vehicle in vehicles)
                {
                    available = await CheckAvailabilityByIdAsync(start, end, vehicle.Id);
                    if (available) return true;
                }
            }

            string idList = string.Join(",", vehicles.Select(x => x.Id));

            string query = @$"SELECT TOP 1 Id FROM Reservations WHERE (StartDate BETWEEN '{start:yyyy-MM-dd}' AND '{end:yyyy-MM-dd}' OR EndDate BETWEEN '{start:yyyy-MM-dd}' AND '{end:yyyy-MM-dd}') AND VehicleId IN ({idList})";
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
