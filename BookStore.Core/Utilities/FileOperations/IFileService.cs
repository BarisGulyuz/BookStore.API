using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BookStore.Core.Helpers.CloudinaryHelper
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file);
    }
}
