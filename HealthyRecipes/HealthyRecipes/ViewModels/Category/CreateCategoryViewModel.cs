using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.ViewModels.Category
{
    public class CreateCategoryViewModel
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}
