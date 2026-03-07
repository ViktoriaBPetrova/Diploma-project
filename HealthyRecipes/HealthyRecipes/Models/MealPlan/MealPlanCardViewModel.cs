namespace HealthyRecipes.Web.Models.MealPlan
{
    public class MealPlanCardViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        public int DayCount { get; set; }
        public bool IsSaved { get; set; }
        public bool IsOwner { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
