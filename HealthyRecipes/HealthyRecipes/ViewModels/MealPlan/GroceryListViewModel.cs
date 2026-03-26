namespace HealthyRecipes.Web.Models.MealPlan
{
    public class GroceryListViewModel
    {
        public Guid MealPlanId { get; set; }
        public string MealPlanName { get; set; } = null!;
        public DateTime GeneratedAt { get; set; }
        public IEnumerable<GroceryItemViewModel> Items { get; set; } = new List<GroceryItemViewModel>();
    }

    public class GroceryItemViewModel
    {
        public Guid IngredientId { get; set; }
        public string IngredientName { get; set; } = null!;
        public string? Brand { get; set; }
        public float QuantityInGrams { get; set; }
        
        // Display-friendly quantity
        public string DisplayQuantity
        {
            get
            {
                if (QuantityInGrams >= 1000)
                    return $"{Math.Round(QuantityInGrams / 1000, 2)} kg";
                else
                    return $"{Math.Round(QuantityInGrams, 0)} g";
            }
        }

        // Future: Store data
        public IEnumerable<StoreAvailabilityViewModel> Stores { get; set; } = new List<StoreAvailabilityViewModel>();
    }

    public class StoreAvailabilityViewModel
    {
        public string StoreName { get; set; } = null!;
        public string? StoreLocation { get; set; }
        public bool InStock { get; set; }
        public decimal? Price { get; set; }
        public string? Currency { get; set; }
        public string? ProductUrl { get; set; }
        public DateTime LastUpdated { get; set; }

        public bool IsMockData { get; set; }

        // Additional properties for price comparison
        public decimal PricePer100g { get; set; }
        public int PackageQuantityInGrams { get; set; }
        public string? ProductName { get; set; }
        public string? ImageUrl { get; set; }
        public string? StoreLogoUrl { get; set; }

        // Display-friendly properties
        public string DisplayPrice => Price.HasValue ? $"{Price.Value:F2} {Currency}" : "N/A";
        public string DisplayPricePer100g => $"{PricePer100g:F2} {Currency}/100g";
        public string DisplayPackageSize => PackageQuantityInGrams >= 1000 
            ? $"{PackageQuantityInGrams / 1000.0:F1} kg" 
            : $"{PackageQuantityInGrams} g";

        public string DisplayLastUpdated
        {
            get
            {
                var timeSpan = DateTime.UtcNow - LastUpdated;
                if (timeSpan.TotalMinutes < 1)
                    return "Just now";
                if (timeSpan.TotalMinutes < 60)
                    return $"{(int)timeSpan.TotalMinutes} min ago";
                if (timeSpan.TotalHours < 24)
                    return $"{(int)timeSpan.TotalHours} hours ago";
                return LastUpdated.ToString("MMM d, h:mm tt");
            }
        }
    }
}
