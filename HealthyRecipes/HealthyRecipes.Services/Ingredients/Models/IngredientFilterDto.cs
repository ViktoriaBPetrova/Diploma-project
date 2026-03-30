using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Ingredients.Models
{
    public class IngredientFilterDto
    {
        public string? SearchTerm { get; set; }

        public int? MinCalories { get; set; }
        public int? MaxCalories { get; set; }
        public int? MinProtein { get; set; }
        public int? MaxProtein { get; set; }
        public int? MinCarbs { get; set; }
        public int? MaxCarbs { get; set; }
        public int? MinFat { get; set; }
        public int? MaxFat { get; set; }

        public bool ExcludeUserAllergies { get; set; } = false;
        public Guid? UserId { get; set; }

      
        public string SortBy { get; set; } = "CreatedAt";
        public string SortOrder { get; set; } = "desc";
    }
}
