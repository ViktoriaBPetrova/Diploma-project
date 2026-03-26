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
                // ========== TOP-LEVEL COMMENTS (Your Original 15 Comments) ==========
                
                // Comment 1: User (John) on Grilled Salmon (Emma's recipe)
                new CommentRating(RecipeConstants.GrilledSalmonQuinoaId, UserConstants.UserId, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment1Id),
                    Rating = CommentRatingConstants.UserRating,
                    Comment = CommentRatingConstants.UserComment,
                    ParentCommentId = null,
                    IsPinned = false
                },

                // Comment 2: User (John) on Greek Yogurt Bowl (Sarah's recipe)
                new CommentRating(RecipeConstants.GreekYogurtBowlId, UserConstants.UserId, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment2Id),
                    Rating = CommentRatingConstants.UserRating2,
                    Comment = CommentRatingConstants.UserComment2,
                    ParentCommentId = null,
                    IsPinned = false
                },

                // Comment 3: User (John) on Buddha Bowl (Sarah's recipe)
                new CommentRating(RecipeConstants.BuddhaBowlId, UserConstants.UserId, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment3Id),
                    Rating = CommentRatingConstants.UserRating3,
                    Comment = CommentRatingConstants.UserComment3,
                    ParentCommentId = null,
                    IsPinned = false
                },

                // Comment 4: User (John) on Overnight Oats (Mike's recipe)
                new CommentRating(RecipeConstants.OvernightOatsId, UserConstants.UserId, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment4Id),
                    Rating = CommentRatingConstants.UserRating4,
                    Comment = CommentRatingConstants.UserComment4,
                    ParentCommentId = null,
                    IsPinned = false
                },

                // Comment 5: Mike on Chicken Rice Bowl (John's recipe)
                new CommentRating(RecipeConstants.ChickenRiceBowlId, UserConstants.User3Id, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment5Id),
                    Rating = CommentRatingConstants.MikeRating1,
                    Comment = CommentRatingConstants.MikeComment1,
                    ParentCommentId = null,
                    IsPinned = false
                },

                // Comment 6: Mike on Veggie Omelette (John's recipe)
                new CommentRating(RecipeConstants.VeggieOmeletteId, UserConstants.User3Id, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment6Id),
                    Rating = CommentRatingConstants.MikeRating2,
                    Comment = CommentRatingConstants.MikeComment2,
                    ParentCommentId = null,
                    IsPinned = false
                },

                // Comment 7: Mike on Mediterranean Salad (Emma's recipe)
                new CommentRating(RecipeConstants.MediterraneanSaladId, UserConstants.User3Id, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment7Id),
                    Rating = CommentRatingConstants.MikeRating3,
                    Comment = CommentRatingConstants.MikeComment3,
                    ParentCommentId = null,
                    IsPinned = false
                },

                // Comment 8: Sarah on Chicken Rice Bowl (John's recipe)
                new CommentRating(RecipeConstants.ChickenRiceBowlId, UserConstants.User2Id, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment8Id),
                    Rating = CommentRatingConstants.SarahRating1,
                    Comment = CommentRatingConstants.SarahComment1,
                    ParentCommentId = null,
                    IsPinned = false
                },

                // Comment 9: Sarah on Grilled Salmon (Emma's recipe) - PINNED by Emma
                new CommentRating(RecipeConstants.GrilledSalmonQuinoaId, UserConstants.User2Id, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment9Id),
                    Rating = CommentRatingConstants.SarahRating2,
                    Comment = CommentRatingConstants.SarahComment2,
                    ParentCommentId = null,
                    IsPinned = true // Emma pinned this glowing review!
                },

                // Comment 10: Sarah on Overnight Oats (Mike's recipe)
                new CommentRating(RecipeConstants.OvernightOatsId, UserConstants.User2Id, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment10Id),
                    Rating = CommentRatingConstants.SarahRating3,
                    Comment = CommentRatingConstants.SarahComment3,
                    ParentCommentId = null,
                    IsPinned = false
                },

                // Comment 11: Sarah on Chicken Stir-Fry (Mike's recipe)
                new CommentRating(RecipeConstants.ChickenStirFryId, UserConstants.User2Id, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment11Id),
                    Rating = CommentRatingConstants.SarahRating4,
                    Comment = CommentRatingConstants.SarahComment4,
                    ParentCommentId = null,
                    IsPinned = false
                },

                // Comment 12: Emma on Chicken Rice Bowl (John's recipe)
                new CommentRating(RecipeConstants.ChickenRiceBowlId, UserConstants.User4Id, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment12Id),
                    Rating = CommentRatingConstants.EmmaRating1,
                    Comment = CommentRatingConstants.EmmaRating1Comment,
                    ParentCommentId = null,
                    IsPinned = true // John pinned Emma's professional feedback
                },

                // Comment 13: Emma on Buddha Bowl (Sarah's recipe)
                new CommentRating(RecipeConstants.BuddhaBowlId, UserConstants.User4Id, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment13Id),
                    Rating = CommentRatingConstants.EmmaRating2,
                    Comment = CommentRatingConstants.EmmaRating2Comment,
                    ParentCommentId = null,
                    IsPinned = false
                },

                // Comment 14: Emma on Overnight Oats (Mike's recipe)
                new CommentRating(RecipeConstants.OvernightOatsId, UserConstants.User4Id, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment14Id),
                    Rating = CommentRatingConstants.EmmaRating3,
                    Comment = CommentRatingConstants.EmmaRating3Comment,
                    ParentCommentId = null,
                    IsPinned = false
                },

                // Comment 15: Emma on Chicken Stir-Fry (Mike's recipe)
                new CommentRating(RecipeConstants.ChickenStirFryId, UserConstants.User4Id, seedingDate)
                {
                    Id = Guid.Parse(CommentRatingConstants.Comment15Id),
                    Rating = CommentRatingConstants.EmmaRating4,
                    Comment = CommentRatingConstants.EmmaRating4Comment,
                    ParentCommentId = null,
                    IsPinned = false
                },

                // ========== REPLIES (New - Demonstrating Threading) ==========

                // Reply 1: Mike replies to Sarah's pinned comment on Grilled Salmon
                new CommentRating(RecipeConstants.GrilledSalmonQuinoaId, UserConstants.User3Id, seedingDate.AddHours(2))
                {
                    Id = Guid.Parse(CommentRatingConstants.Reply1Id),
                    Rating = null, // Replies don't have ratings
                    Comment = CommentRatingConstants.Reply1Text,
                    ParentCommentId = Guid.Parse(CommentRatingConstants.Comment9Id), // Reply to Sarah's comment
                    IsPinned = false
                },

                // Reply 2: John (author) replies to Emma's feedback on his Chicken Bowl
                new CommentRating(RecipeConstants.ChickenRiceBowlId, UserConstants.UserId, seedingDate.AddHours(4))
                {
                    Id = Guid.Parse(CommentRatingConstants.Reply2Id),
                    Rating = null,
                    Comment = CommentRatingConstants.Reply2Text,
                    ParentCommentId = Guid.Parse(CommentRatingConstants.Comment12Id), // Reply to Emma's comment
                    IsPinned = false
                },

                // Reply 3: Sarah replies to Mike's reply (nested - 2nd level)
                new CommentRating(RecipeConstants.GrilledSalmonQuinoaId, UserConstants.User2Id, seedingDate.AddHours(6))
                {
                    Id = Guid.Parse(CommentRatingConstants.Reply3Id),
                    Rating = null,
                    Comment = CommentRatingConstants.Reply3Text,
                    ParentCommentId = Guid.Parse(CommentRatingConstants.Reply1Id), // Reply to Mike's reply
                    IsPinned = false
                },

                // Reply 4: Sarah replies to John's Overnight Oats recipe feedback
                new CommentRating(RecipeConstants.OvernightOatsId, UserConstants.User2Id, seedingDate.AddHours(3))
                {
                    Id = Guid.Parse(CommentRatingConstants.Reply4Id),
                    Rating = null,
                    Comment = CommentRatingConstants.Reply4Text,
                    ParentCommentId = Guid.Parse(CommentRatingConstants.Comment4Id), // Reply to John's comment
                    IsPinned = false
                },

                // Reply 5: Mike (author) replies to Sarah on his Chicken Stir-Fry
                new CommentRating(RecipeConstants.ChickenStirFryId, UserConstants.User3Id, seedingDate.AddHours(5))
                {
                    Id = Guid.Parse(CommentRatingConstants.Reply5Id),
                    Rating = null,
                    Comment = CommentRatingConstants.Reply5Text,
                    ParentCommentId = Guid.Parse(CommentRatingConstants.Comment11Id), // Reply to Sarah's comment
                    IsPinned = false
                }


            };

            return commentRatings;
        }
    }
}
