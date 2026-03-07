using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Web.Models.Recipe
{
    public class CommentViewModel
    {
        public string UserName { get; set; } = null!;
        public string? UserImageUrl { get; set; }
        public Rating Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCurrentUser { get; set; }
    }
}
