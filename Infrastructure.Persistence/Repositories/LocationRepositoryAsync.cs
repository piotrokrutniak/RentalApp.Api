using Application.Interfaces.Repositories;
using Domain.Models.Locations;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class LocationRepositoryAsync : GenericRepositoryAsync<Location>, ILocationRepositoryAsync
    {
        private readonly DbSet<Location> _context;

        public LocationRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext.Set<Location>();
        }
    }
}
