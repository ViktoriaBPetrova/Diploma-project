using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Web.Models.MealPlan
{
    public class MealViewModel
    {
        public Guid Id { get; set; }
        public MealType Type { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        public IEnumerable<MealRecipeViewModel> Recipes { get; set; } = new List<MealRecipeViewModel>();
    }
}
