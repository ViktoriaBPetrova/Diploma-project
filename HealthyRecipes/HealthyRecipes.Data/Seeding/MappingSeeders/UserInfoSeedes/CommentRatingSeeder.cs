using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Seeding.Constants;
using HealthyRecipes.Data.Seeding.Constants.MappingConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.MappingSeeders.UserInfoSeedes
{
    public class CommentRatingSeeder
    {
        public static ICollection<CommentRating> GenerateCommentRatings()
        {
            DateTime seedingDate = new DateTime(2025, 12, 18);

            ICollection<CommentRating> commentRatings = new HashSet<CommentRating>()
            {
            new CommentRating(RecipeConstants.ChickenRiceBowlId, UserConstants.UserId, seedingDate)
            {
                Rating = CommentRatingConstants.UserRating,
                Comment = CommentRatingConstants.UserComment
            }
            };

            return commentRatings;
        }
    }
}
