using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Ingredients
{
    public class IngredientService : IIngredient
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly IApi _apiService;

        public IngredientService(
            HealthyRecipesDbContext context,
            IApi apiService)
        {
            _context = context;
            _apiService = apiService;
        }

        /*public async Task<Ingredient> GetOrFetchIngredientAsync(string name)
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
