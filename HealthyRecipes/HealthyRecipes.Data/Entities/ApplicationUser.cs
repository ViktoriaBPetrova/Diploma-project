using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Entities.MappingEntities.MealPlanTracking;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Allergies = new List<Allergy>();
            SavedRecipes  = new List<SavedRecipe>();
            SavedMealPlans = new List<SavedMealPlan>();
            MealPlansFollowed = new List<MealPlanFollower>();
            CommentRatings  = new List<CommentRating>();
           

            // (One-to-Many)
            CreatedCategories = new List<Category>();
            CreatedRecipes  = new List<Recipe>();
            CreatedIngredients  = new List<Ingredient>();
            CreatedMealPlans  = new List<MealPlan>();
            MealPlanDayEntries = new List<MealPlanDayEntry>();
            MealEntries = new List<MealEntry>();
            ActivityLogs = new List<ActivityLog>();
            CreatedBannedWords = new List<BannedWord>();
            FlaggedContentAsAuthor = new List<FlaggedContent>();
            FlaggedContentReported = new List<FlaggedContent>();
            FlaggedContentReviewed = new List<FlaggedContent>();
            WarningsReceived = new List<UserWarning>();
            WarningsIssued = new List<UserWarning>();
        }
        public ApplicationUser(DateTime createdAt):this()
        {
            CreatedAt = createdAt;
            UpdatedAt = createdAt;
        }


        // ---------- Basic Info ---------- // later change these t private sets
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; } 
        public float? Height { get; set; }  // cm
        public float? Weight { get; set; }  // kg
        public string? ImageUrl { get; set; } // nullable


        // ---------- Goals ----------// these as well
        public float? ProteinGoal { get; set; }
        public float? CarbsGoal { get; set; }
        public float? FatGoal { get; set; }

        public float? Calories { get; set; }

        // ---------- Navigation Collections ----------

        // (Many-toMany)
        public IEnumerable<Allergy> Allergies { get; set; }
        public IEnumerable<SavedRecipe> SavedRecipes { get; set; }
        public IEnumerable<SavedMealPlan> SavedMealPlans { get; set; }
        public IEnumerable<CommentRating> CommentRatings { get; set; }
        public IEnumerable<MealPlanFollower> MealPlansFollowed { get; set; }
        

        // (One-to-Many)
        public IEnumerable<Category> CreatedCategories { get; set; } 
        public IEnumerable<Recipe> CreatedRecipes { get; set; } 
        public IEnumerable<Ingredient> CreatedIngredients { get; set; } 
        public IEnumerable<MealPlan> CreatedMealPlans { get; set; }
        public IEnumerable<MealPlanDayEntry> MealPlanDayEntries { get; set; }
        public IEnumerable<MealEntry> MealEntries { get; set; }
        public IEnumerable<ActivityLog> ActivityLogs { get; set; }
        public IEnumerable<BannedWord> CreatedBannedWords { get; set; }
        public IEnumerable<FlaggedContent> FlaggedContentAsAuthor { get; set; }
        public IEnumerable<FlaggedContent> FlaggedContentReported { get; set; }
        public IEnumerable<FlaggedContent> FlaggedContentReviewed { get; set; } 
        public IEnumerable<UserWarning> WarningsReceived { get; set; } 
        public IEnumerable<UserWarning> WarningsIssued { get; set; }


        // ---------- Metadata ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; } 


        
    }
}
