using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUploadImageService
    {
        Task<string> UploadImage(IFormFile file);
        Task<string> GetImages(int pageSize);
    }
}
