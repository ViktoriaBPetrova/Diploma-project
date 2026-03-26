using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Recipes.Models
{
    public class RecipeFilterDto
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

        public int? MaxPreparationTime { get; set; }
        public string? DifficultyLevel { get; set; }

        public List<string> IncludeIngredients { get; set; } = new();
        public List<string> ExcludeIngredients { get; set; } = new();
        public List<Guid> CategoryIds { get; set; } = new();

        public bool ExcludeUserAllergies { get; set; } = false;
        public Guid? UserId { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string SortBy { get; set; } = "CreatedAt";
        public string SortOrder { get; set; } = "desc";
    }
}
