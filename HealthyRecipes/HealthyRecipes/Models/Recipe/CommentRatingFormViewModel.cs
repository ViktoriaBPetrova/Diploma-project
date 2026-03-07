using HealthyRecipes.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.Models.Recipe
{
    public class CommentRatingFormViewModel
    {
        public Guid RecipeId { get; set; }
        public Rating Rating { get; set; } = Rating.Ok;

        [MaxLength(1000)]
        public string? Comment { get; set; }
    }
}
