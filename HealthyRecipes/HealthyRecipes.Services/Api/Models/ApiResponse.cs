using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Api.Models
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string StatusVerbose { get; set; }
        public Product Product { get; set; }
    }
}
