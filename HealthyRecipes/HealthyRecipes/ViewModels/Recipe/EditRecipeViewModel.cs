using HealthyRecipes.Web.ViewModels.Recipe;
using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.ViewModels.Recipe
{
    public class EditRecipeViewModel : CreateRecipeViewModel
    {
        public Guid Id { get; set; }

        // Current media (for display and preservation)
        public List<string> CurrentImageUrls { get; set; } = new();
        public string? CurrentVideoUrl { get; set; }

        // New uploads (optional - only if user wants to add more)
        [Display(Name = "Add More Images (up to 5 total)")]
        public List<IFormFile>? NewImageFiles { get; set; }

        [Display(Name = "New Video (leave empty to keep current)")]
        public IFormFile? NewVideoFile { get; set; }

        // Removal flags
        public List<string> ImagesToRemove { get; set; } = new();
        public bool RemoveCurrentVideo { get; set; }
    }
}
