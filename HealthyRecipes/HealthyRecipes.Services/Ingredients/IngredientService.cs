using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Enums;
using HealthyRecipes.Services.Api;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.Ingredients
{
    public class IngredientService : IIngredient
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly IApi _apiService;

        public IngredientService(HealthyRecipesDbContext context, IApi apiService)
        {
            _context = context;
            _apiService = apiService;
        }

        public async Task<Guid> CreateIngredientAsync(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return ingredient.Id;
        }

        public async Task<Ingredient?> GetIngredientByIdAsync(Guid id)
        {
            return await _context.Ingredients
                .Include(i => i.RecipeIngredients)
                .Include(i => i.Allergies)
                .FirstOrDefaultAsync(i => i.Id == id && !i.Deleted);
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync(bool includeDeleted = false)
        {
            return await _context.Ingredients
                .Include(i => i.RecipeIngredients)
                .Where(i => includeDeleted || !i.Deleted)
                .OrderBy(i => i.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsBySourceAsync(Source source)
        {
            return await _context.Ingredients
                .Where(i => i.Source == source && !i.Deleted)
                .OrderBy(i => i.Name)
                .ToListAsync();
        }

        public async Task<bool> UpdateIngredientAsync(Ingredient ingredient)
        {
            var existing = await _context.Ingredients
                .FirstOrDefaultAsync(i => i.Id == ingredient.Id && !i.Deleted);

            if (existing == null)
                return false;

            existing.Name = ingredient.Name;
            existing.Brand = ingredient.Brand;
            existing.CaloriesPer100g = ingredient.CaloriesPer100g;
            existing.ProteinPer100g = ingredient.ProteinPer100g;
            existing.CarbsPer100g = ingredient.CarbsPer100g;
            existing.FatPer100g = ingredient.FatPer100g;
            existing.UpdatedAt = DateTime.UtcNow;

            _context.Ingredients.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteIngredientAsync(Guid id)
        {
            var existing = await _context.Ingredients
                .FirstOrDefaultAsync(i => i.Id == id && !i.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = true;
            existing.DeletedAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;

            _context.Ingredients.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RestoreIngredientAsync(Guid id)
        {
            var existing = await _context.Ingredients
                .FirstOrDefaultAsync(i => i.Id == id && i.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = false;
            existing.DeletedAt = null;
            existing.UpdatedAt = DateTime.UtcNow;

            _context.Ingredients.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        /*private readonly HealthyRecipesDbContext _context;
private readonly IApi _apiService;

public IngredientService(
    HealthyRecipesDbContext context,
    IApi apiService)
{
    _context = context;
    _apiService = apiService;
}

public async Task<Ingredient> GetOrFetchIngredientAsync(string name)
{
    // 1. Check YOUR database first
    var ingredient = await _context.Ingredients
        .FirstOrDefaultAsync(i => i.Name == name);

    if (ingredient != null)
        return ingredient; // Already in DB

    // 2. Not in DB? Fetch from external API
    var apiIngredient = await _apiService.GetIngredientDataAsync(name);

    if (apiIngredient == null)
        throw new NotFoundException($"Ingredient '{name}' not found");

    // 3. Save to YOUR database
    _context.Ingredients.Add(apiIngredient);
    await _context.SaveChangesAsync();

    return apiIngredient;
}

// Get from DB only (no API call)
public async Task<List<Ingredient>> GetAllIngredientsAsync()
{
    return await _context.Ingredients.ToListAsync();
}

// Update existing ingredient
public async Task UpdateIngredientAsync(int id, Ingredient ingredient)
{
    var existing = await _context.Ingredients.FindAsync(id);

    if (existing == null)
        throw new NotFoundException("Ingredient not found");

    existing.Name = ingredient.Name;
    existing.Calories = ingredient.Calories;
    // ... update other properties

    await _context.SaveChangesAsync();
}*/
    }
}
