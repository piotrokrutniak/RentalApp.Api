using Application.Interfaces.Repositories;
using Domain.Models.Vehicles;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class VehicleRepositoryAsync : GenericRepositoryAsync<Vehicle>, IVehicleRepositoryAsync
    {
        private readonly DbSet<Vehicle> _context;

        public VehicleRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext.Set<Vehicle>();
        }
    }
}
