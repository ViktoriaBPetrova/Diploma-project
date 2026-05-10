using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
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
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _containerClient;
        private readonly long _maxImageSize;
        private readonly long _maxVideoSize;
        private readonly string[] _allowedImageExtensions;
        private readonly string[] _allowedVideoExtensions;

        public FileUploadService(IConfiguration configuration)
        {
            var storageAccountUrl = configuration["AzureBlobStorage:StorageAccountUrl"];
            /*
            var storageAccountUrl = configuration["HealthyRecipes_BlobStorage_Url"]
            ?? configuration["AzureBlobStorage:StorageAccountUrl"];*/
            var connectionString = configuration["AzureBlobStorage:ConnectionString"];
            var containerName = configuration["AzureBlobStorage:ContainerName"] ?? "recipe-images";  

            // Use connection string if available (local dev), otherwise use Managed Identity (production)
            if (!string.IsNullOrEmpty(connectionString))
            {
                // Local development - use connection string
                _blobServiceClient = new BlobServiceClient(connectionString);
            }
            else
            {
                // Production - use Managed Identity
                _blobServiceClient = new BlobServiceClient(
                    new Uri(storageAccountUrl),
                    new DefaultAzureCredential()
                );
            }

            _containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            // Create container if it doesn't exist (public read access for images)
            //_containerClient.CreateIfNotExists(PublicAccessType.Blob);

            _maxImageSize = long.Parse(configuration["AzureBlobStorage:MaxImageSizeMB"] ?? "5") * 1024 * 1024;
            _maxVideoSize = long.Parse(configuration["AzureBlobStorage:MaxVideoSizeMB"] ?? "100") * 1024 * 1024;
            _allowedImageExtensions = configuration.GetSection("AzureBlobStorage:AllowedImageExtensions").Get<string[]>()
                ?? new[] { ".jpg", ".jpeg", ".png", ".webp" };
            _allowedVideoExtensions = configuration.GetSection("AzureBlobStorage:AllowedVideoExtensions").Get<string[]>()
                ?? new[] { ".mp4", ".webm" };
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

            var contentType = file.ContentType;
            return await UploadToBlobAsync(file, subFolder, contentType);
        }

        public async Task<string?> UploadVideoAsync(IFormFile file, string subFolder = "recipes")
        {
            if (!IsValidVideo(file)) return null;

            var contentType = file.ContentType;
            return await UploadToBlobAsync(file, subFolder, contentType);
        }

        public async Task<List<string>> UploadMultipleImagesAsync(List<IFormFile>? files, string subFolder = "recipes", int maxFiles = 5)
        {
            var uploadedUrls = new List<string>();

            if (files == null || files.Count == 0)
                return uploadedUrls;

            var filesToUpload = files.Take(maxFiles).ToList();

            foreach (var file in filesToUpload)
            {
                if (IsValidImage(file))
                {
                    var url = await UploadImageAsync(file, subFolder);
                    if (url != null)
                        uploadedUrls.Add(url);
                }
            }

            return uploadedUrls;
        }

        public async Task<bool> DeleteMultipleFilesAsync(List<string>? filePaths)
        {
            if (filePaths == null || filePaths.Count == 0)
                return true;

            bool allDeleted = true;
            foreach (var filePath in filePaths)
            {
                var deleted = await DeleteFileAsync(filePath);
                if (!deleted)
                    allDeleted = false;
            }

            return allDeleted;
        }

        private async Task<string> UploadToBlobAsync(IFormFile file, string subFolder, string contentType)
        {
            // Create unique blob name
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var blobName = string.IsNullOrEmpty(subFolder)
                ? fileName
                : $"{subFolder}/{fileName}";

            // Creates container only when actually uploading
            await _containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

            var blobClient = _containerClient.GetBlobClient(blobName);

            // Set headers for optimal performance
            var blobHttpHeaders = new BlobHttpHeaders
            {
                ContentType = contentType,
                CacheControl = "public, max-age=31536000" // Cache for 1 year
            };

            // Add metadata for tracking
            var metadata = new Dictionary<string, string>
            {
                { "OriginalFileName", file.FileName },
                { "UploadedAt", DateTime.UtcNow.ToString("o") },
                { "FileSize", file.Length.ToString() }
            };

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, new BlobUploadOptions
                {
                    HttpHeaders = blobHttpHeaders,
                    Metadata = metadata
                });
            }

            // Return the full blob URL
            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<bool> DeleteFileAsync(string? filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return false;

            try
            {
                // Extract blob name from URL
                var uri = new Uri(filePath);
                var blobName = uri.AbsolutePath.TrimStart('/');

                // Remove container name from path if present
                var containerName = _containerClient.Name;
                if (blobName.StartsWith(containerName + "/"))
                {
                    blobName = blobName.Substring(containerName.Length + 1);
                }

                var blobClient = _containerClient.GetBlobClient(blobName);
                var result = await blobClient.DeleteIfExistsAsync();

                return result.Value;
            }
            catch
            {
                return false;
            }
        }
    }
}