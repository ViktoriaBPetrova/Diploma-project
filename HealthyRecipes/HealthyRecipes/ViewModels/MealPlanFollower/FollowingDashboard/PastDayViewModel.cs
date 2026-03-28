namespace HealthyRecipes.Web.ViewModels.MealPlanFollower.FollowingDashboard
{
    public class PastDayViewModel
    {
        public int DayNumber { get; set; }
        public Data.Enums.DayOfWeek DayOfWeek { get; set; }
        public DateTime Date { get; set; }
        public bool IsToday { get; set; }
        public bool IsFuture { get; set; }
        
        // Nutrition
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        
        // Tracking data
        public int TotalMeals { get; set; }
        public int LoggedMeals { get; set; }
        public bool HasDayReflection { get; set; }
        public string? DayReflection { get; set; }
        
        // Completion percentage for this day
        public int CompletionPercentage => TotalMeals > 0 ? (int)((float)LoggedMeals / TotalMeals * 100) : 0;
    }
}
