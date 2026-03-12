using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.ViewModels.MealPlanFollower
{
    public class StartFollowingViewModel
    {
        [Required]
        public Guid MealPlanId { get; set; }

        public string MealPlanName { get; set; } = null!;
        public string? MealPlanDescription { get; set; }
        public int DaysCount { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
    }
}
