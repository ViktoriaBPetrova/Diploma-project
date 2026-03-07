using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Web.Models.MealPlan
{
    public class MealPlanDayViewModel
    {
        public Guid Id { get; set; }
        public int DayNumber { get; set; }
        public Data.Enums.DayOfWeek DayOfWeek { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        public IEnumerable<MealViewModel> Meals { get; set; } = new List<MealViewModel>();
    }
}
