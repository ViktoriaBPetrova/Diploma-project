using HealthyRecipes.Data.Entities.MappingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.IngredientMeals
{
    public interface IIngredientMeal
    {
        Task AddIngredientToMealAsync(Guid ingredientId, Guid mealId, float quantity, string unit);
        Task<bool> RemoveIngredientFromMealAsync(Guid ingredientId, Guid mealId);
        Task<IEnumerable<IngredientMeal>> GetIngredientsByMealAsync(Guid mealId);
        Task<bool> UpdateQuantityAsync(Guid mealId, Guid ingredientId, float quantity, string unit);
        float ConvertToGrams(float quantity, string unit);
        float ConvertFromGrams(float grams, string unit);
        string FormatQuantity(float? quantity, string? unit);
    }
}
