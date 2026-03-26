using HealthyRecipes.Services.StoreApis.Models;

namespace HealthyRecipes.Services.StoreApis
{
    /// <summary>
    /// Interface for store API integration to check product availability and pricing
    /// </summary>
    public interface IStoreApi
    {
        /// <summary>
        /// Check availability and pricing for an ingredient across multiple stores
        /// </summary>
        Task<IEnumerable<StoreProductDto>> CheckAvailabilityAsync(string ingredientName, string? bgName = null, string? brand = null);
        
        /// <summary>
        /// Get the cheapest available option for an ingredient
        /// </summary>
        Task<StoreProductDto?> GetCheapestOptionAsync(string ingredientName, string? brand = null);
        
        /// <summary>
        /// Check if a specific store has an ingredient in stock
        /// </summary>
        Task<bool> IsInStockAsync(string storeName, string ingredientName, string? brand = null);
    }
}
