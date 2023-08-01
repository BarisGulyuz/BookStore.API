using BookStore.Core.Utilities.Settings;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace BookStore.Core.Helpers.CloudinaryHelper
{
    public class CloudinaryService : IFileService
    {
        private Cloudinary _cloudinary;
        public CloudinaryService(IOptions<CloudinarySettings> cloudinarySetting)
        {
            Account account = new Account(cloudinarySetting.Value.Cloud, cloudinarySetting.Value.ApiKey, cloudinarySetting.Value.ApiSecret); 
            _cloudinary = new Cloudinary(account);

        }
        public async Task<string> UploadFile(IFormFile file)
        {
            string url = string.Empty;

            if (file.Length > 0)
            {
                var uploadResult = new ImageUploadResult();
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };
                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                }

                url = uploadResult.Url.ToString();
            }
            return url;
        }
    }
}
