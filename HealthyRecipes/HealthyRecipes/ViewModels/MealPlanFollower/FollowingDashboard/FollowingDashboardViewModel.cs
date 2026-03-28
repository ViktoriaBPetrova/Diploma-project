using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Web.ViewModels.MealPlanFollower.FollowingDashboard
{
    public class FollowingDashboardViewModel
    {
        // Active plan (prominently displayed at top)
        public ActivePlanDetailViewModel? ActivePlan { get; set; }

        // Today's meals for the active plan (SIDEBAR)
        public TodaysMealsViewModel? TodaysSchedule { get; set; }

        // NEW: Past days history (MAIN CONTENT)
        public IEnumerable<PastDayViewModel> PastDays { get; set; } = new List<PastDayViewModel>();

        // Paused plans (can resume)
        public IEnumerable<PausedPlanItemViewModel> PausedPlans { get; set; } = new List<PausedPlanItemViewModel>();

        // Completion alert
        public bool ShowCompletionAlert { get; set; }
        public string? CompletionAlertMessage { get; set; }
    }
}
