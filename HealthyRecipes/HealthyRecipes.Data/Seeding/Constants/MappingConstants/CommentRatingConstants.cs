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

        // ========== COMMENT IDs (for the 15 existing comments) ==========
        public const string Comment1Id = "10000000-0000-0000-0000-000000000001";
        public const string Comment2Id = "10000000-0000-0000-0000-000000000002";
        public const string Comment3Id = "10000000-0000-0000-0000-000000000003";
        public const string Comment4Id = "10000000-0000-0000-0000-000000000004";
        public const string Comment5Id = "10000000-0000-0000-0000-000000000005";
        public const string Comment6Id = "10000000-0000-0000-0000-000000000006";
        public const string Comment7Id = "10000000-0000-0000-0000-000000000007";
        public const string Comment8Id = "10000000-0000-0000-0000-000000000008";
        public const string Comment9Id = "10000000-0000-0000-0000-000000000009";
        public const string Comment10Id = "10000000-0000-0000-0000-000000000010";
        public const string Comment11Id = "10000000-0000-0000-0000-000000000011";
        public const string Comment12Id = "10000000-0000-0000-0000-000000000012";
        public const string Comment13Id = "10000000-0000-0000-0000-000000000013";
        public const string Comment14Id = "10000000-0000-0000-0000-000000000014";
        public const string Comment15Id = "10000000-0000-0000-0000-000000000015";

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

        // ========== REPLY IDs ==========
        public const string Reply1Id = "20000000-0000-0000-0000-000000000001";
        public const string Reply2Id = "20000000-0000-0000-0000-000000000002";
        public const string Reply3Id = "20000000-0000-0000-0000-000000000003";
        public const string Reply4Id = "20000000-0000-0000-0000-000000000004";
        public const string Reply5Id = "20000000-0000-0000-0000-000000000005";

        // ========== REPLY TEXT ==========
        // Reply 1: Mike replies to Sarah's comment on Grilled Salmon
        public const string Reply1Text = "I totally agree! I add extra lemon zest to mine for even more flavor. Great recipe!";

        // Reply 2: John (author) replies to Emma's feedback
        public const string Reply2Text = "Thanks Emma! Great idea about adding more vegetables. I'll update the recipe with some veggie variations.";

        // Reply 3: Sarah replies to Mike's reply (nested)
        public const string Reply3Text = "Ooh, lemon zest sounds amazing! I'll try that next time.";

        // Reply 4: Sarah replies to John on Overnight Oats
        public const string Reply4Text = "Same here! I also prep mine on Sundays. Such a time-saver during the week.";

        // Reply 5: Mike (author) replies to Sarah on Chicken Stir-Fry
        public const string Reply5Text = "Love that tofu swap idea! I've tried it with tempeh too and it works great.";

        // ========== PROBLEMATIC COMMENT IDs (New - for moderation testing) ==========
        public const string SpamComment1Id = "30000000-0000-0000-0000-000000000001";
        public const string SpamComment2Id = "30000000-0000-0000-0000-000000000002";
        public const string HarassmentComment1Id = "30000000-0000-0000-0000-000000000003";
        public const string MisinfoComment1Id = "30000000-0000-0000-0000-000000000004";
        public const string MildNegativeComment1Id = "30000000-0000-0000-0000-000000000005";
        public const string ToxicComment1Id = "30000000-0000-0000-0000-000000000006";
        public const string PromoComment1Id = "30000000-0000-0000-0000-000000000007";

        // ========== PROBLEMATIC COMMENT TEXT ==========

        // Spam Comment 1 - Contains "spam" and "scam" (Critical severity)
        public const Rating SpamComment1Rating = Rating.Disgusting;
        public const string SpamComment1Text = "This recipe is spam! Total scam, don't try it! Visit my website for real recipes!";

        // Spam Comment 2 - Promotional link spam
        public const string SpamComment2Text = "Check out my website for weight loss pills! www.spam-site.com - Get 50% off today!";

        // Harassment Comment - Contains "idiot" and "stupid" (High severity)
        public const string HarassmentComment1Text = "You're such an idiot for not liking this recipe. Stupid people like you shouldn't be commenting on food.";

        // Misinformation Comment - Dangerous health claims
        public const Rating MisinfoComment1Rating = Rating.Delicious;
        public const string MisinfoComment1Text = "This salmon recipe will cure your diabetes! No need for insulin anymore! I threw away my medication after eating this!";

        // Mild Negative Comment - Contains "lame" and "sucks" (Low severity)
        public const Rating MildNegativeComment1Rating = Rating.Disgusting;
        public const string MildNegativeComment1Text = "This recipe is lame and totally sucks. What a waste of time. Not worth trying at all.";

        // Toxic Comment - Multiple banned words: "fake", "clickbait", "spam", "hate"
        public const Rating ToxicComment1Rating = Rating.Disgusting;
        public const string ToxicComment1Text = "Fake news! This is clickbait garbage. Pure spam. I hate it! Don't believe these lies!";

        // Promotional Comment - Self-promotion spam
        public const Rating PromoComment1Rating = Rating.Tasty;
        public const string PromoComment1Text = "Good recipe but mine is better! Follow my Instagram @fitnessguru for REAL healthy recipes. Link in bio!";
    }
}
