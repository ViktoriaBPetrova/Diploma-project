using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.FileUploads
{
    public interface IFileUpload
    {
        Task<string?> UploadImageAsync(IFormFile file, string subFolder = "recipes");
        Task<List<string>> UploadMultipleImagesAsync(List<IFormFile>? files, string subFolder = "recipes", int maxFiles = 5);
        Task<string?> UploadVideoAsync(IFormFile file, string subFolder = "recipes");
        Task<bool> DeleteFileAsync(string? filePath);
        Task<bool> DeleteMultipleFilesAsync(List<string>? filePaths);
        bool IsValidImage(IFormFile file);
        bool IsValidVideo(IFormFile file);
    }
}
