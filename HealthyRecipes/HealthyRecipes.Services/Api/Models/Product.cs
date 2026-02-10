using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Api.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public string Brands { get; set; }
        public string Categories { get; set; }
        public string ImageUrl { get; set; }
        public string IngredientsText { get; set; }
        public Nutriments Nutriments { get; set; }
        public string NutritionGrades { get; set; }
    }
}
