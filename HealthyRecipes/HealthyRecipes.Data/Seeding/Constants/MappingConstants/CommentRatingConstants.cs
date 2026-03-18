using HealthyRecipes.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.Constants.MappingConstants
{
    public class CommentRatingConstants
    {
        // ---------- Comment 1: User (John) on Grilled Salmon (Emma's recipe) ----------
        public const Rating UserRating = Rating.Delicious;
        public const string UserComment = "This salmon recipe is amazing! The lemon quinoa pairs perfectly. Already made it twice!";

        // ---------- Comment 2: User (John) on Greek Yogurt Bowl (Sarah's recipe) ----------
        public const Rating UserRating2 = Rating.Tasty;
        public const string UserComment2 =
            "Simple but effective breakfast. I add a scoop of protein powder to hit my macros.";

        // ---------- Comment 3: User (John) on Buddha Bowl (Sarah's recipe) ----------
        public const Rating UserRating3 = Rating.Tasty;
        public const string UserComment3 =
            "Not usually into plant-based meals but this one actually filled me up. Surprisingly good!";

        // ---------- Comment 4: User (John) on Overnight Oats (Mike's recipe) ----------
        public const Rating UserRating4 = Rating.Delicious;
        public const string UserComment4 =
            "Perfect pre-workout meal! The peanut butter gives sustained energy. I prep 5 jars every Sunday.";

        // ---------- Comment 5: Mike on Chicken Rice Bowl (John's recipe) ----------
        public const Rating MikeRating1 = Rating.Tasty;
        public const string MikeComment1 =
            "Good macro split for athletes. I double the chicken portion for extra protein.";

        // ---------- Comment 6: Mike on Veggie Omelette (John's recipe) ----------
        public const Rating MikeRating2 = Rating.Delicious;
        public const string MikeComment2 =
            "Quick and protein-packed! Perfect post-run meal. I add extra veggies for more nutrients.";

        // ---------- Comment 7: Mike on Mediterranean Salad (Emma's recipe) ----------
        public const Rating MikeRating3 = Rating.Tasty;
        public const string MikeComment3 =
            "Light and refreshing after long runs. I add some grilled chicken for extra protein.";

        // ---------- Comment 8: Sarah on Chicken Rice Bowl (John's recipe) ----------
        public const Rating SarahRating1 = Rating.Disgusting;
        public const string SarahComment1 =
            "Not bad, but I prefer more vegetables in my bowls. A bit too heavy on the rice for me.";

        // ---------- Comment 9: Sarah on Grilled Salmon (Emma's recipe) ----------
        public const Rating SarahRating2 = Rating.Delicious;
        public const string SarahComment2 =
            "Absolutely love this! The lemon quinoa is the perfect pairing. Made it three times this week.";

        // ---------- Comment 10: Sarah on Overnight Oats (Mike's recipe) ----------
        public const Rating SarahRating3 = Rating.Delicious;
        public const string SarahComment3 =
            "Perfect pre-yoga breakfast! The peanut butter gives sustained energy. Great for meal prep!";

        // ---------- Comment 11: Sarah on Chicken Stir-Fry (Mike's recipe) ----------
        public const Rating SarahRating4 = Rating.Tasty;
        public const string SarahComment4 =
            "Quick weeknight dinner! I swap the chicken for tofu to keep it plant-based.";

        // ---------- Comment 12: Emma on Chicken Rice Bowl (John's recipe) ----------
        public const Rating EmmaRating1 = Rating.Tasty;
        public const string EmmaRating1Comment =
            "Good balanced meal! I recommend my clients add more vegetables to boost the nutrient density.";

        // ---------- Comment 13: Emma on Buddha Bowl (Sarah's recipe) ----------
        public const Rating EmmaRating2 = Rating.Delicious;
        public const string EmmaRating2Comment =
            "Great plant-based option! I recommend adding chickpeas for extra protein. My clients love this recipe.";

        // ---------- Comment 14: Emma on Overnight Oats (Mike's recipe) ----------
        public const Rating EmmaRating3 = Rating.Ok;
        public const string EmmaRating3Comment =
            "Convenient but a bit sweet for my taste. I'd reduce the honey next time.";

        // ---------- Comment 15: Emma on Chicken Stir-Fry (Mike's recipe) ----------
        public const Rating EmmaRating4 = Rating.Delicious;
        public const string EmmaRating4Comment =
            "Quick and nutritious! Done in 20 minutes, exactly as promised. Perfect for busy weeknights.";
    }
}
