using Application.Interfaces.Repositories;
using Domain.Models.Images;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ImageRepositoryAsync : GenericRepositoryAsync<Image>, IImageRepositoryAsync
    {
        private readonly DbSet<Image> _images;

        public ImageRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _images = dbContext.Set<Image>();
        }
    }
}
