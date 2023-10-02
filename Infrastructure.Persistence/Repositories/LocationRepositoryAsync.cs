using Application.Interfaces.Repositories;
using Domain.Models.Images;
using Domain.Models.Locations;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class LocationRepositoryAsync : GenericRepositoryAsync<Location>, ILocationRepositoryAsync
    {
        private readonly DbSet<Location> _locations;

        public LocationRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _locations = dbContext.Set<Location>();
        }
    }
}
