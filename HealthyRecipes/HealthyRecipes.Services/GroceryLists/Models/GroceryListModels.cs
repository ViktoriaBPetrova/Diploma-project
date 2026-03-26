using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Services.GroceryLists.Models
{
    public class GroceryListDto
    {
        public Guid MealPlanId { get; set; }
        public string MealPlanName { get; set; } = null!;
        public DateTime GeneratedAt { get; set; }
        public IEnumerable<GroceryItemDto> Items { get; set; } = new List<GroceryItemDto>();
    }

    public class GroceryItemDto
    {
        public Guid IngredientId { get; set; }
        public string IngredientName { get; set; } = null!;
        
        public string? Brand { get; set; }
        public float QuantityInGrams { get; set; }
        
        // Future: Store availability and pricing
        public IEnumerable<StoreAvailabilityDto> Stores { get; set; } = new List<StoreAvailabilityDto>();
    }

    /// <summary>
    /// Store availability and pricing information
    /// </summary>
    public class StoreAvailabilityDto
    {
        public string StoreName { get; set; } = null!;
        public string? StoreLocation { get; set; }
        public bool InStock { get; set; }
        public decimal? Price { get; set; }
        public string? Currency { get; set; }
        public string? ProductUrl { get; set; }
        public DateTime LastUpdated { get; set; }
        
        // Additional fields for better comparison
        public decimal PricePer100g { get; set; }
        public int PackageQuantityInGrams { get; set; }
        public string? ProductName { get; set; }
        public string? ImageUrl { get; set; }
        public string? StoreLogoUrl { get; set; }
        public bool IsMockData { get; set; }
    }
}
