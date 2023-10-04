using Application.Interfaces.Repositories;
using Domain.Models.Reservations;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ReservationRepositoryAsync : GenericRepositoryAsync<Reservation>, IReservationRepositoryAsync
    {
        private readonly DbSet<Reservation> _context;

        public ReservationRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext.Set<Reservation>();
        }

        public override async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Include(x => x.Vehicle)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
