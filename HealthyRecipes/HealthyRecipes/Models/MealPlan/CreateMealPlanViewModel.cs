using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.Models.MealPlan
{
    public class CreateMealPlanViewModel
    {
        [Required, MaxLength(200)]
        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        public string? Description { get; set; }
    }
}
