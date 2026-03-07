using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.Models.User
{
    public class EditProfileViewModel
    {
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [MaxLength(500)]
        public string? Bio { get; set; }

        public string? ImageUrl { get; set; }

        [Range(50, 300)]
        public float? Height { get; set; }

        [Range(20, 500)]
        public float? Weight { get; set; }

        [Range(0, 500)]
        public float? ProteinGoal { get; set; }

        [Range(0, 1000)]
        public float? CarbsGoal { get; set; }

        [Range(0, 300)]
        public float? FatGoal { get; set; }

        [Range(500, 10000)]
        public float? CalorieGoal { get; set; }
    }
}
