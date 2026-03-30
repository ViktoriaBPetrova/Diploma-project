using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Api.Models
{
    public class Product
    {
        public string? Categories { get; set; }
        public string? ImageUrl { get; set; }
        public string? IngredientsText { get; set; }
        public string? NutritionGrades { get; set; }

        [JsonPropertyName("product_name")]
        public string? ProductName { get; set; }

        [JsonPropertyName("brands")]
        public string? Brands { get; set; }

        [JsonPropertyName("nutriments")]
        public Nutriments? Nutriments { get; set; }
    }
}
