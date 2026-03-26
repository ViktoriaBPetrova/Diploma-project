using HealthyRecipes.Web.ViewModels.Recipe;
using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.ViewModels.Recipe
{
    public class EditRecipeViewModel : CreateRecipeViewModel
    {
        public Guid Id { get; set; }

        // Current media (for display and preservation)
        public string? CurrentImageUrl { get; set; }
        public string? CurrentVideoUrl { get; set; }

        // New uploads (optional - only if user wants to replace)
        [Display(Name = "New Image (leave empty to keep current)")]
        public IFormFile? NewImageFile { get; set; }

        [Display(Name = "New Video (leave empty to keep current)")]
        public IFormFile? NewVideoFile { get; set; }
    }
}
