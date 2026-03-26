using HealthyRecipes.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities.MappingEntities
{
    public class CommentRating
    {
        public CommentRating()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Replies = new List<CommentRating>();

        }

        public CommentRating(string recipeId, string userId, DateTime createdAt)
        {
            CreatedAt = UpdatedAt = createdAt;
            RecipeId = Guid.Parse(recipeId);
            UserId = Guid.Parse(userId);
            Replies = new List<CommentRating>();
        }
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public Rating? Rating {  get; set; } 
        public string? Comment {  get; set; }

        // Pinning (only for top-level comments)
        public bool IsPinned { get; set; } = false;

        // Self-referencing for replies
        public Guid? ParentCommentId { get; set; }
        public CommentRating? ParentComment { get; set; }
        public ICollection<CommentRating> Replies { get; set; }

        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }
    }
}
