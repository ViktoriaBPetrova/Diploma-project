using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Web.ViewModels.Recipe
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string? UserImageUrl { get; set; }
        public Rating? Rating { get; set; } // Nullable - only top-level have ratings
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsEdited => UpdatedAt > CreatedAt.AddMinutes(1);
        public bool IsCurrentUser { get; set; }
        public bool IsRecipeOwner { get; set; }
        public bool IsPinned { get; set; }
        public List<CommentViewModel> Replies { get; set; } = new();
    }
}
