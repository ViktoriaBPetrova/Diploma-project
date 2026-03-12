using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.ViewModels.MealPlanFollower
{
    public class ReasonMealPlanViewModel
    {
        [Required]
        public Guid MealPlanId { get; set; }

        public string MealPlanName { get; set; } = null!;

        [MaxLength(500, ErrorMessage = "Reason cannot exceed 500 characters")]
        public string? Reason { get; set; }
    }
}
