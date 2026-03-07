using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.Recipes
{
    public class RecipeService : IRecipe
    {
        private readonly HealthyRecipesDbContext _context;

        public RecipeService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe.Id;
        }

        public async Task<Recipe?> GetRecipeByIdAsync(Guid id)
        {
            return await _context.Recipes
                .Include(r => r.RecipeCategories)
                    .ThenInclude(rc => rc.Category)
                .Include(r => r.CommentRatings)
                    .ThenInclude(cr => cr.User)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeMeals)
                .Include(r => r.SavedRecipes)
                .FirstOrDefaultAsync(r => r.Id == id && !r.Deleted);
        }

        public async Task<bool> UpdateRecipeAsync(Recipe recipe)
        {
            var existing = await _context.Recipes
                .FirstOrDefaultAsync(r => r.Id == recipe.Id && !r.Deleted);

            if (existing == null)
                return false;

            existing.Info       = recipe.Info;
            existing.Calories   = recipe.Calories;
            existing.Protein    = recipe.Protein;
            existing.Carbs      = recipe.Carbs;
            existing.Fat        = recipe.Fat;
            existing.PrepTime   = recipe.PrepTime;
            existing.Servings   = recipe.Servings;
            existing.Difficulty = recipe.Difficulty;
            existing.ImageUrl   = recipe.ImageUrl;
            existing.VideoUrl   = recipe.VideoUrl;
            existing.UpdatedAt  = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteRecipeAsync(Guid id)
        {
            var existing = await _context.Recipes
                .FirstOrDefaultAsync(r => r.Id == id && !r.Deleted);

            if (existing == null)
                return false;

            existing.Deleted   = true;
            existing.DeletedAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RestoreRecipeAsync(Guid id)
        {
            var existing = await _context.Recipes
                .FirstOrDefaultAsync(r => r.Id == id && r.Deleted);

            if (existing == null)
                return false;

            existing.Deleted   = false;
            existing.DeletedAt = null;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool includeDeleted = false)
        {
            return await _context.Recipes
                .Include(r => r.RecipeCategories)
                    .ThenInclude(rc => rc.Category)
                .Include(r => r.CommentRatings)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeMeals)
                .Include(r => r.SavedRecipes)
                .Where(r => includeDeleted || !r.Deleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipeAsync(Func<Recipe, bool> predicate)
        {
            // Loads into memory then filters — fine for small sets,
            // consider switching to Expression<Func<Recipe, bool>> for large data.
            return await Task.FromResult(
                _context.Recipes
                    .Where(r => !r.Deleted)
                    .Where(predicate)
                    .ToList()
            );
        }

        public async Task<bool> RecalculateRecipeNutritionAsync(Guid id)
        {
            var recipe = await _context.Recipes
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == id && !r.Deleted);

            if (recipe == null)
                return false;

            var activeIngredients = recipe.RecipeIngredients
                .Where(ri => !ri.Deleted && ri.Ingredient != null)
                .ToList();

            recipe.Calories  = activeIngredients.Sum(ri => ri.Ingredient.CaloriesPer100g  * ri.QuantityInGrams / 100f);
            recipe.Protein   = activeIngredients.Sum(ri => ri.Ingredient.ProteinPer100g   * ri.QuantityInGrams / 100f);
            recipe.Carbs     = activeIngredients.Sum(ri => ri.Ingredient.CarbsPer100g     * ri.QuantityInGrams / 100f);
            recipe.Fat       = activeIngredients.Sum(ri => ri.Ingredient.FatPer100g       * ri.QuantityInGrams / 100f);
            recipe.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
