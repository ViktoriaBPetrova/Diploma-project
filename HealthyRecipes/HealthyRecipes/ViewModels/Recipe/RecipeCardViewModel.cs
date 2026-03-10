using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Web.ViewModels.Recipe
{
    public class RecipeCardViewModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string Info { get; set; } = null!;
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        public int? PrepTime { get; set; }
        public Difficulty? Difficulty { get; set; }
        public string? ImageUrl { get; set; }
        public double AverageRating { get; set; }
        public int RatingCount { get; set; }
        public IEnumerable<string> CategoryNames { get; set; } = new List<string>();
        public bool IsSaved { get; set; }
        public string AuthorName { get; set; } = null!;
    }
}
