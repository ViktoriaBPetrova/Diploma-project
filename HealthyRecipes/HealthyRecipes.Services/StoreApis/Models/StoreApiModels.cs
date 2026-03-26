namespace HealthyRecipes.Services.StoreApis.Models
{
    public class StoreProductDto
    {
        public string StoreName { get; set; } = null!;
        public string StoreLocation { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? Brand { get; set; }
        public bool InStock { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = "BGN";
        public int QuantityInGrams { get; set; }
        public string? ProductUrl { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsMockData { get; set; }

        // Calculated fields
        public decimal PricePer100g => QuantityInGrams > 0 ? (Price / QuantityInGrams) * 100 : 0;
        public string StoreLogoUrl => GetStoreLogoUrl(StoreName);
        
        private string GetStoreLogoUrl(string store)
        {
            return store.ToLower() switch
            {
                "kaufland" => "/images/stores/kaufland.svg",
                "billa" => "/images/stores/billa.svg",
                "lidl" => "/images/stores/lidl.svg",
                "fantastico" => "/images/stores/fantastico.svg",
                "t-market" => "/images/stores/t-market.svg",
                _ => "/images/stores/generic.svg"
            };
        }
    }

    public class StoreSearchRequest
    {
        public string IngredientName { get; set; } = null!;
        public string? Brand { get; set; }
        public List<string>? PreferredStores { get; set; }
        public string? Location { get; set; }
    }
}
