using Application.Interfaces.Repositories;
using Domain.Models.Reservations;
using Domain.Models.Vehicles;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class VehicleRepositoryAsync : GenericRepositoryAsync<Vehicle>, IVehicleRepositoryAsync
    {
        private readonly DbSet<Vehicle> _context;

        public VehicleRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext.Set<Vehicle>();
        }

        public override async Task<Vehicle> GetByIdAsync(int id)
        {
            return await _context.Include(x => x.Reservations)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
