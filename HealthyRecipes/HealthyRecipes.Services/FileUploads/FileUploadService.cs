using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.FileUploads
{
    public class FileUploadService : IFileUpload
    {
        private readonly IConfiguration _configuration;
        private readonly long _maxImageSize;
        private readonly long _maxVideoSize;
        private readonly string[] _allowedImageExtensions;
        private readonly string[] _allowedVideoExtensions;
        private readonly string _storagePath;

        public FileUploadService(IConfiguration configuration)
        {
            _configuration = configuration;
            _maxImageSize = long.Parse(_configuration["FileUpload:MaxImageSizeMB"] ?? "5") * 1024 * 1024;
            _maxVideoSize = long.Parse(_configuration["FileUpload:MaxVideoSizeMB"] ?? "100") * 1024 * 1024;
            _allowedImageExtensions = _configuration.GetSection("FileUpload:AllowedImageExtensions").Get<string[]>()
                ?? new[] { ".jpg", ".jpeg", ".png", ".webp" };
            _allowedVideoExtensions = _configuration.GetSection("FileUpload:AllowedVideoExtensions").Get<string[]>()
                ?? new[] { ".mp4", ".webm" };
            _storagePath = _configuration["FileUpload:StoragePath"] ?? "wwwroot/uploads/recipes";
        }

        public bool IsValidImage(IFormFile file)
        {
            if (file == null || file.Length == 0) return false;
            if (file.Length > _maxImageSize) return false;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return _allowedImageExtensions.Contains(extension);
        }

        public bool IsValidVideo(IFormFile file)
        {
            if (file == null || file.Length == 0) return false;
            if (file.Length > _maxVideoSize) return false;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return _allowedVideoExtensions.Contains(extension);
        }

        public async Task<string?> UploadImageAsync(IFormFile file, string subFolder = "recipes")
        {
            if (!IsValidImage(file)) return null;
            return await SaveFileAsync(file, subFolder);
        }

        public async Task<string?> UploadVideoAsync(IFormFile file, string subFolder = "recipes")
        {
            if (!IsValidVideo(file)) return null;
            return await SaveFileAsync(file, subFolder);
        }

        private async Task<string> SaveFileAsync(IFormFile file, string subFolder)
        {
            // Create unique filename to prevent conflicts
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var uploadPath = Path.Combine(_storagePath, subFolder);

            // Ensure directory exists
            Directory.CreateDirectory(uploadPath);

            var filePath = Path.Combine(uploadPath, fileName);

            // Save file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return relative URL path (what gets stored in database)
            return $"/uploads/recipes/{subFolder}/{fileName}";
        }

        public async Task<bool> DeleteFileAsync(string? filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return false;

            try
            {
                // Convert URL path to physical path
                var physicalPath = Path.Combine("wwwroot", filePath.TrimStart('/'));

                if (File.Exists(physicalPath))
                {
                    await Task.Run(() => File.Delete(physicalPath));
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }
    }
}
