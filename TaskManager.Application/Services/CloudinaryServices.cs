using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Services
{
    public class CloudinaryServices
    {

        private readonly Cloudinary _cloudinary;

        public CloudinaryServices(IConfiguration config)
        {
            var cloudName = Environment.GetEnvironmentVariable("CLOUDINARY_CLOUD_NAME")
                ?? config["Cloudinary:CloudName"];

            var apiKey = Environment.GetEnvironmentVariable("CLOUDINARY_API_KEY")
                ?? config["Cloudinary:ApiKey"];

            var apiSecret = Environment.GetEnvironmentVariable("CLOUDINARY_API_SECRET")
                ?? config["Cloudinary:ApiSecret"];

            var account = new Account(cloudName, apiKey, apiSecret);

            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = "products"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl.ToString();
        }








    }
}
