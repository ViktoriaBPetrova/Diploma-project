using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Web.ViewModels.MealPlanFollower
{
    public class PlanFollowersViewModel
    {
        public Guid MealPlanId { get; set; }
        public string MealPlanName { get; set; } = null!;
        public IEnumerable<FollowerItemViewModel> Followers { get; set; } = new List<FollowerItemViewModel>();
        public int TotalFollowers { get; set; }
        public int ActiveFollowers { get; set; }
        public int CompletedFollowers { get; set; }
    }

    public class FollowerItemViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string? UserEmail { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public MealPlanFollowerStatus Status { get; set; }
        public bool IsActive { get; set; }
        public int DaysFollowing { get; set; }
    }
}
