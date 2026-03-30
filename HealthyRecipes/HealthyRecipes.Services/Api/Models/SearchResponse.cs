using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Api.Models
{
    public class SearchResponse
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}
