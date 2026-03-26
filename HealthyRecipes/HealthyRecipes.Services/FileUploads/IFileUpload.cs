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
        Task<string?> UploadVideoAsync(IFormFile file, string subFolder = "recipes");
        Task<bool> DeleteFileAsync(string? filePath);
        bool IsValidImage(IFormFile file);
        bool IsValidVideo(IFormFile file);
    }
}
