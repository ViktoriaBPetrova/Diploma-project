using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.Meals
{
    public class MealService : IMeal
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<MealService> _logger;

        public MealService(HealthyRecipesDbContext context, ILogger<MealService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> CreateMealAsync(Meal meal)
        {
            if (meal == null) throw new ArgumentNullException(nameof(meal));
            try
            {
                _context.Meals.Add(meal);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Meal created with ID: {Id}", meal.Id);
                return meal.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating meal");
                throw;
            }
        }

        public async Task<Meal?> GetMealByIdAsync(Guid id)
        {
            try
            {
                return await _context.Meals
                    .Include(m => m.RecipeMeals)
                        .ThenInclude(rm => rm.Recipe)
                    .Include(m => m.IngredientMeals)        
                        .ThenInclude(im => im.Ingredient)
                    .Include(m => m.MealPlanDay)
                        .ThenInclude(md => md.MealPlan)
                    .FirstOrDefaultAsync(m => m.Id == id && !m.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving meal with ID: {Id}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Meal>> GetMealsByDayAsync(Guid mealPlanDayId)
        {
            try
            {
                return await _context.Meals
                    .Include(m => m.RecipeMeals)
                        .ThenInclude(rm => rm.Recipe)
                    .Where(m => m.MealPlanDayId == mealPlanDayId && !m.Deleted)
                    .OrderBy(m => m.Type)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving meals for day: {DayId}", mealPlanDayId);
                throw;
            }
        }

        public async Task<bool> UpdateMealAsync(Meal meal)
        {
            if (meal == null) throw new ArgumentNullException(nameof(meal));
            try
            {
                var existing = await _context.Meals.FirstOrDefaultAsync(m => m.Id == meal.Id && !m.Deleted);
                if (existing == null) return false;

                existing.Type = meal.Type;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Meal {Id} updated", meal.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating meal: {Id}", meal.Id);
                throw;
            }
        }

        public async Task<bool> SoftDeleteMealAsync(Guid id)
        {
            try
            {
                var existing = await _context.Meals.FirstOrDefaultAsync(m => m.Id == id && !m.Deleted);
                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Meal {Id} soft deleted", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting meal: {Id}", id);
                throw;
            }
        }

        public async Task<bool> RestoreMealAsync(Guid id)
        {
            try
            {
                var existing = await _context.Meals.FirstOrDefaultAsync(m => m.Id == id && m.Deleted);
                if (existing == null) return false;

                existing.Deleted = false;
                existing.DeletedAt = null;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Meal {Id} restored", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring meal: {Id}", id);
                throw;
            }
        }

        public async Task<bool> RecalculateNutritionAsync(Guid mealId)
        {
            try
            {
                var meal = await _context.Meals
                    .Include(m => m.RecipeMeals)
                        .ThenInclude(rm => rm.Recipe)
                    .Include(m => m.IngredientMeals)       
                        .ThenInclude(im => im.Ingredient)
                    .FirstOrDefaultAsync(m => m.Id == mealId && !m.Deleted);

                if (meal == null) return false;

                var activeRecipes = meal.RecipeMeals.Where(rm => !rm.Deleted && rm.Recipe != null).ToList();
                var activeIngredients = meal.IngredientMeals.Where(im => !im.Deleted && im.Ingredient != null).ToList();

                var recipeCalories = activeRecipes.Sum(rm => rm.Recipe!.Calories);
                var ingredientCalories = activeIngredients.Sum(im => ((im.Ingredient.CaloriesPer100g / 100) * im.QuantityInGrams));

                var recipeProtein = activeRecipes.Sum(rm => rm.Recipe!.Protein);
                var ingredientProtein = activeIngredients.Sum(im => ((im.Ingredient.ProteinPer100g / 100) * im.QuantityInGrams));

                var recipeCarbs = activeRecipes.Sum(rm => rm.Recipe!.Carbs);
                var ingredientCarbs = activeIngredients.Sum(im => ((im.Ingredient.CarbsPer100g / 100) * im.QuantityInGrams));

                var recipeFat = activeRecipes.Sum(rm => rm.Recipe!.Fat);
                var ingredientFat = activeIngredients.Sum(im => ((im.Ingredient.FatPer100g / 100) * im.QuantityInGrams));


                meal.Calories = recipeCalories + ingredientCalories; 
                meal.Protein = recipeProtein + ingredientProtein; 
                meal.Carbs = recipeCarbs + ingredientCarbs; 
                meal.Fat = recipeFat + ingredientFat; 

                meal.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Meal {Id} nutrition recalculated", mealId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recalculating nutrition for meal: {Id}", mealId);
                throw;
            }
        }
    }
}
