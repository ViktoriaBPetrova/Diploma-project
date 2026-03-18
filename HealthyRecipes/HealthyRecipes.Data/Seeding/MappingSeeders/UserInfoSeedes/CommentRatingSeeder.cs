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
             // Comment 1: User (John) on Grilled Salmon (Emma's recipe)
                new CommentRating(RecipeConstants.GrilledSalmonQuinoaId, UserConstants.UserId, seedingDate)
                {
                    Rating = CommentRatingConstants.UserRating,
                    Comment = CommentRatingConstants.UserComment
                },
 
                // Comment 2: User (John) on Greek Yogurt Bowl (Sarah's recipe)
                new CommentRating(RecipeConstants.GreekYogurtBowlId, UserConstants.UserId, seedingDate)
                {
                    Rating = CommentRatingConstants.UserRating2,
                    Comment = CommentRatingConstants.UserComment2
                },
 
                // Comment 3: User (John) on Buddha Bowl (Sarah's recipe)
                new CommentRating(RecipeConstants.BuddhaBowlId, UserConstants.UserId, seedingDate)
                {
                    Rating = CommentRatingConstants.UserRating3,
                    Comment = CommentRatingConstants.UserComment3
                },
 
                // Comment 4: User (John) on Overnight Oats (Mike's recipe)
                new CommentRating(RecipeConstants.OvernightOatsId, UserConstants.UserId, seedingDate)
                {
                    Rating = CommentRatingConstants.UserRating4,
                    Comment = CommentRatingConstants.UserComment4
                },
 
                // Comment 5: Mike on Chicken Rice Bowl (John's recipe)
                new CommentRating(RecipeConstants.ChickenRiceBowlId, UserConstants.User3Id, seedingDate)
                {
                    Rating = CommentRatingConstants.MikeRating1,
                    Comment = CommentRatingConstants.MikeComment1
                },
 
                // Comment 6: Mike on Veggie Omelette (John's recipe)
                new CommentRating(RecipeConstants.VeggieOmeletteId, UserConstants.User3Id, seedingDate)
                {
                    Rating = CommentRatingConstants.MikeRating2,
                    Comment = CommentRatingConstants.MikeComment2
                },
 
                // Comment 7: Mike on Mediterranean Salad (Emma's recipe)
                new CommentRating(RecipeConstants.MediterraneanSaladId, UserConstants.User3Id, seedingDate)
                {
                    Rating = CommentRatingConstants.MikeRating3,
                    Comment = CommentRatingConstants.MikeComment3
                },
 
                // Comment 8: Sarah on Chicken Rice Bowl (John's recipe)
                new CommentRating(RecipeConstants.ChickenRiceBowlId, UserConstants.User2Id, seedingDate)
                {
                    Rating = CommentRatingConstants.SarahRating1,
                    Comment = CommentRatingConstants.SarahComment1
                },
 
                // Comment 9: Sarah on Grilled Salmon (Emma's recipe)
                new CommentRating(RecipeConstants.GrilledSalmonQuinoaId, UserConstants.User2Id, seedingDate)
                {
                    Rating = CommentRatingConstants.SarahRating2,
                    Comment = CommentRatingConstants.SarahComment2
                },
 
                // Comment 10: Sarah on Overnight Oats (Mike's recipe)
                new CommentRating(RecipeConstants.OvernightOatsId, UserConstants.User2Id, seedingDate)
                {
                    Rating = CommentRatingConstants.SarahRating3,
                    Comment = CommentRatingConstants.SarahComment3
                },
 
                // Comment 11: Sarah on Chicken Stir-Fry (Mike's recipe)
                new CommentRating(RecipeConstants.ChickenStirFryId, UserConstants.User2Id, seedingDate)
                {
                    Rating = CommentRatingConstants.SarahRating4,
                    Comment = CommentRatingConstants.SarahComment4
                },
 
                // Comment 12: Emma on Chicken Rice Bowl (John's recipe)
                new CommentRating(RecipeConstants.ChickenRiceBowlId, UserConstants.User4Id, seedingDate)
                {
                    Rating = CommentRatingConstants.EmmaRating1,
                    Comment = CommentRatingConstants.EmmaRating1Comment
                },
 
                // Comment 13: Emma on Buddha Bowl (Sarah's recipe)
                new CommentRating(RecipeConstants.BuddhaBowlId, UserConstants.User4Id, seedingDate)
                {
                    Rating = CommentRatingConstants.EmmaRating2,
                    Comment = CommentRatingConstants.EmmaRating2Comment
                },
 
                // Comment 14: Emma on Overnight Oats (Mike's recipe)
                new CommentRating(RecipeConstants.OvernightOatsId, UserConstants.User4Id, seedingDate)
                {
                    Rating = CommentRatingConstants.EmmaRating3,
                    Comment = CommentRatingConstants.EmmaRating3Comment
                },
 
                // Comment 15: Emma on Chicken Stir-Fry (Mike's recipe)
                new CommentRating(RecipeConstants.ChickenStirFryId, UserConstants.User4Id, seedingDate)
                {
                    Rating = CommentRatingConstants.EmmaRating4,
                    Comment = CommentRatingConstants.EmmaRating4Comment
                }
            };

            return commentRatings;
        }
    }
}
