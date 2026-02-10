using HealthyRecipes.Services.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Api
{
    public interface IApi
    {
        Task<ApiResponse?> GetProductByBarcodeAsync(string barcode);
    }

}
