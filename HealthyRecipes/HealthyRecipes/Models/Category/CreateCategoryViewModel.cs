using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.Models.Category
{
    public class CreateCategoryViewModel
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}
