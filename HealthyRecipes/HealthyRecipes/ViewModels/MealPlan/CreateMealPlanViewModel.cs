using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.ViewModels.MealPlan
{
    public class CreateMealPlanViewModel
    {
        [Required, MaxLength(200)]
        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        public string? Description { get; set; }

        public List<CreateDayViewModel> Days { get; set; } = new List<CreateDayViewModel>();
    }

    public class CreateDayViewModel
    {
        public int DayNumber { get; set; }
        public int DayOfWeek { get; set; }
        public List<CreateMealViewModel> Meals { get; set; } = new List<CreateMealViewModel>();
    }

    public class CreateMealViewModel
    {
        public int Type { get; set; }
        public List<Guid> RecipeIds { get; set; } = new List<Guid>();
    }
}