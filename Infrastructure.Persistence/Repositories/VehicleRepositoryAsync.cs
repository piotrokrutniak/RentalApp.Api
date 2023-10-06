using Application.Interfaces.Repositories;
using Domain.Models.Vehicles;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Vehicle> GetByVinAsync(string vin)
        {
            return await _context.FirstOrDefaultAsync(x => x.Vin == vin);
        }

        public async Task<IReadOnlyList<Vehicle>> GetPagedReponseAsync(int pageNumber, int pageSize, string model = "")
        {
            return await _context.Where(x => model == null || x.Model.Contains(model))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
