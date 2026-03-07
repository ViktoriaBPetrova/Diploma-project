using HealthyRecipes.Data.Enums;
using HealthyRecipes.Web.ViewModels.Recipe;

namespace HealthyRecipes.Web.ViewModels.Recipe
{
    public class RecipeDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Info { get; set; } = null!;
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        public int? PrepTime { get; set; }
        public Difficulty? Difficulty { get; set; }
        public int? Servings { get; set; }
        public string? ImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string AuthorName { get; set; } = null!;
        public Guid AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public double AverageRating { get; set; }
        public bool IsSaved { get; set; }
        public IEnumerable<string> CategoryNames { get; set; } = new List<string>();
        public IEnumerable<RecipeIngredientViewModel> Ingredients { get; set; } = new List<RecipeIngredientViewModel>();
        public IEnumerable<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
        public CommentRatingFormViewModel? CurrentUserComment { get; set; }
        public bool HasAllergyConflict { get; set; }
        public IEnumerable<string> ConflictingIngredients { get; set; } = new List<string>();
    }
}
