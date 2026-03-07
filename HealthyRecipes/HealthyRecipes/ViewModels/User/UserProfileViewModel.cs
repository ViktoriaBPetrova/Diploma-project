using HealthyRecipes.Web.ViewModels.User;
using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.ViewModels.User
{
    public class UserProfileViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}".Trim();
        public string? Bio { get; set; }
        public string? ImageUrl { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public float? ProteinGoal { get; set; }
        public float? CarbsGoal { get; set; }
        public float? FatGoal { get; set; }
        public float? CalorieGoal { get; set; }
        public int RecipeCount { get; set; }
        public int MealPlanCount { get; set; }
        public bool IsCurrentUser { get; set; }
        public IEnumerable<AllergyViewModel> Allergies { get; set; } = new List<AllergyViewModel>();
    }
}
