using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Enums;
using HealthyRecipes.Services.Api;
using HealthyRecipes.Services.Api.Models;
using HealthyRecipes.Services.Ingredients.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.Ingredients
{
    public class IngredientService : IIngredient
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly IApi _apiService;
        private readonly ILogger<IngredientService> _logger;

        public IngredientService(
            HealthyRecipesDbContext context,
            IApi apiService,
            ILogger<IngredientService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Ingredient?> CreateIngredientAsync(Ingredient ingredient)
        {
            if (ingredient == null)
                throw new ArgumentNullException(nameof(ingredient));

            try
            {
                _context.Ingredients.Add(ingredient);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Ingredient created: {IngredientName} (ID: {IngredientId})",
                    ingredient.Name, ingredient.Id);
                return ingredient;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating ingredient: {IngredientName}", ingredient.Name);
                throw;
            }
        }


        public async Task<Ingredient?> GetIngredientByIdAsync(Guid id)
        {
            try
            {
                return await _context.Ingredients
                    .Include(i => i.RecipeIngredients)
                    .Include(i => i.Allergies)
                    .Include(i => i.User)
                    .FirstOrDefaultAsync(i => i.Id == id && !i.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient with ID: {IngredientId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync(bool includeDeleted = false)
        {
            try
            {
                return await _context.Ingredients
                    .Include(i => i.RecipeIngredients)
                    .Include(i => i.User)
                    .Where(i => includeDeleted || !i.Deleted)
                    .OrderBy(i => i.Name)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all ingredients");
                throw;
            }
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsBySourceAsync(Source source)
        {
            try
            {
                return await _context.Ingredients
                    .Where(i => i.Source == source && !i.Deleted)
                    .OrderBy(i => i.Name)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredients by source: {Source}", source);
                throw;
            }
        }

        public async Task<bool> UpdateIngredientAsync(Ingredient ingredient)
        {
            if (ingredient == null)
                throw new ArgumentNullException(nameof(ingredient));

            try
            {
                var existing = await _context.Ingredients
                    .FirstOrDefaultAsync(i => i.Id == ingredient.Id && !i.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("Ingredient with ID {IngredientId} not found for update", ingredient.Id);
                    return false;
                }

                existing.Name = ingredient.Name;
                existing.Brand = ingredient.Brand;
                existing.CaloriesPer100g = ingredient.CaloriesPer100g;
                existing.ProteinPer100g = ingredient.ProteinPer100g;
                existing.CarbsPer100g = ingredient.CarbsPer100g;
                existing.FatPer100g = ingredient.FatPer100g;
                existing.UpdatedAt = DateTime.UtcNow;

                _context.Ingredients.Update(existing);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Ingredient {IngredientId} updated successfully", ingredient.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating ingredient with ID: {IngredientId}", ingredient.Id);
                throw;
            }
        }

        public async Task<bool> SoftDeleteIngredientAsync(Guid id)
        {
            try
            {
                var existing = await _context.Ingredients
                    .FirstOrDefaultAsync(i => i.Id == id && !i.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("Ingredient with ID {IngredientId} not found for deletion", id);
                    return false;
                }

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;

                _context.Ingredients.Update(existing);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Ingredient {IngredientId} soft deleted successfully", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error soft deleting ingredient with ID: {IngredientId}", id);
                throw;
            }
        }

        public async Task<bool> RestoreIngredientAsync(Guid id)
        {
            try
            {
                var existing = await _context.Ingredients
                    .FirstOrDefaultAsync(i => i.Id == id && i.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("Deleted ingredient with ID {IngredientId} not found for restoration", id);
                    return false;
                }

                existing.Deleted = false;
                existing.DeletedAt = null;
                existing.UpdatedAt = DateTime.UtcNow;

                _context.Ingredients.Update(existing);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Ingredient {IngredientId} restored successfully", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring ingredient with ID: {IngredientId}", id);
                throw;
            }
        }

        public async Task<(IEnumerable<Ingredient> ingredients, int totalCount)> GetFilteredIngredientsWithApiAsync(
    IngredientFilterDto filter)
        {
            try
            {
                // STEP 1: Get all ingredients from DB that match search term
                var dbQuery = _context.Ingredients.Where(i => !i.Deleted);

                if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
                {
                    var searchLower = filter.SearchTerm.ToLower();
                    dbQuery = dbQuery.Where(i => i.Name.ToLower().Contains(searchLower));
                }

                var dbResults = await dbQuery.ToListAsync();
                _logger.LogInformation("Found {Count} ingredients in DB for search '{SearchTerm}'",
                    dbResults.Count, filter.SearchTerm ?? "");

                // STEP 2: If search term provided and DB has few results, enrich from API
                var allIngredients = dbResults.ToList();

                if (!string.IsNullOrWhiteSpace(filter.SearchTerm) && dbResults.Count < 20)
                {
                    try
                    {
                        _logger.LogInformation("Enriching from API for '{SearchTerm}'", filter.SearchTerm);
                        var apiResults = await FetchAndSaveFromApiAsync(filter.SearchTerm, filter.UserId);

                        if (apiResults.Any())
                        {
                            // Add API results that aren't already in DB results
                            var dbIds = dbResults.Select(d => d.Id).ToHashSet();
                            var newApiResults = apiResults.Where(a => !dbIds.Contains(a.Id));
                            allIngredients.AddRange(newApiResults);

                            _logger.LogInformation("Added {Count} ingredients from API", newApiResults.Count());
                        }
                    }
                    catch (Exception apiEx)
                    {
                        _logger.LogWarning(apiEx, "API enrichment failed, continuing with DB results only");
                    }
                }

                // STEP 3: NOW apply filters to combined DB + API results (in-memory)
                var filteredIngredients = allIngredients.AsEnumerable();

                // Exclude user allergies
                if (filter.ExcludeUserAllergies && filter.UserId.HasValue)
                {
                    var allergyIds = await _context.Allergies
                        .Where(a => a.UserId == filter.UserId.Value)
                        .Select(a => a.IngredientId)
                        .ToListAsync();

                    filteredIngredients = filteredIngredients
                        .Where(i => !allergyIds.Contains(i.Id));
                }

                // Nutrition filters
                if (filter.MinCalories.HasValue)
                    filteredIngredients = filteredIngredients.Where(i => i.CaloriesPer100g >= filter.MinCalories.Value);

                if (filter.MaxCalories.HasValue)
                    filteredIngredients = filteredIngredients.Where(i => i.CaloriesPer100g <= filter.MaxCalories.Value);

                if (filter.MinProtein.HasValue)
                    filteredIngredients = filteredIngredients.Where(i => i.ProteinPer100g >= filter.MinProtein.Value);

                if (filter.MaxProtein.HasValue)
                    filteredIngredients = filteredIngredients.Where(i => i.ProteinPer100g <= filter.MaxProtein.Value);

                if (filter.MinCarbs.HasValue)
                    filteredIngredients = filteredIngredients.Where(i => i.CarbsPer100g >= filter.MinCarbs.Value);

                if (filter.MaxCarbs.HasValue)
                    filteredIngredients = filteredIngredients.Where(i => i.CarbsPer100g <= filter.MaxCarbs.Value);

                if (filter.MinFat.HasValue)
                    filteredIngredients = filteredIngredients.Where(i => i.FatPer100g >= filter.MinFat.Value);

                if (filter.MaxFat.HasValue)
                    filteredIngredients = filteredIngredients.Where(i => i.FatPer100g <= filter.MaxFat.Value);

                // STEP 4: Apply sorting
                filteredIngredients = ApplySorting(filteredIngredients, filter.SortBy, filter.SortOrder);

                var totalCount = filteredIngredients.Count();
                var result = filteredIngredients.ToList();

                _logger.LogInformation("Returning {Count} filtered ingredients (from {Total} total)",
                    result.Count, allIngredients.Count);

                return (result, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting filtered ingredients with API");
                return (Enumerable.Empty<Ingredient>(), 0);
            }
        }

        // PRIVATE HELPER: Fetch from API and save to DB
        private async Task<List<Ingredient>> FetchAndSaveFromApiAsync(string searchTerm, Guid? userId)
        {
            var newIngredients = new List<Ingredient>();

            try
            {
                _logger.LogInformation("Fetching from OpenFoodFacts API for '{SearchTerm}'", searchTerm);

                var searchResponse = await _apiService.SearchProductsAsync(searchTerm, page: 1);

                if (searchResponse?.Products == null || !searchResponse.Products.Any())
                {
                    _logger.LogInformation("No products found in API for '{SearchTerm}'", searchTerm);
                    return newIngredients;
                }

                // Find the BEST match using scoring algorithm
                var bestProduct = FindBestMatch(searchResponse.Products, searchTerm);

                if (bestProduct == null)
                {
                    _logger.LogWarning("No valid products found in API results for '{SearchTerm}'", searchTerm);
                    return newIngredients;
                }

                var productName = bestProduct.ProductName ?? "Unknown Product";

                // Check if already exists (case-insensitive)
                var exists = await _context.Ingredients
                    .AnyAsync(i => !i.Deleted && i.Name.ToLower() == productName.ToLower());

                if (exists)
                {
                    _logger.LogInformation("Best match '{Name}' already exists in DB", productName);
                    return newIngredients;
                }

                // Create the single best ingredient
                var newIngredient = new Ingredient
                {
                    Id = Guid.NewGuid(),
                    Name = productName,
                    Brand = bestProduct.Brands,
                    CaloriesPer100g = bestProduct.Nutriments?.EnergyKcal100g ?? 0,
                    ProteinPer100g = bestProduct.Nutriments?.Proteins100g ?? 0,
                    CarbsPer100g = bestProduct.Nutriments?.Carbohydrates100g ?? 0,
                    FatPer100g = bestProduct.Nutriments?.Fat100g ?? 0,
                    Source = Source.Api,
                    CreatedByUserId = userId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.Ingredients.Add(newIngredient);
                newIngredients.Add(newIngredient);

                await _context.SaveChangesAsync();
                _logger.LogInformation("Saved best match '{Name}' (Brand: {Brand}) from API",
                    newIngredient.Name, newIngredient.Brand ?? "Generic");

                return newIngredients;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching from API for '{SearchTerm}'", searchTerm);
                return newIngredients;
            }
        }

        private Product? FindBestMatch(List<Product> products, string searchTerm)
        {
            var searchLower = searchTerm.ToLower().Trim();

            // Log what we received
            _logger.LogInformation("Finding best match among {Count} products for '{SearchTerm}'",
                products.Count, searchTerm);

            // STEP 1: Filter to products with names
            var validProducts = products
                .Where(p => !string.IsNullOrWhiteSpace(p.ProductName))
                .ToList();

            _logger.LogInformation("After name filter: {Count} products", validProducts.Count);

            if (!validProducts.Any())
                return null;

            // STEP 2: Score all products
            var scoredProducts = validProducts
                .Select(p => new
                {
                    Product = p,
                    Score = CalculateRelevanceScore(p, searchLower)
                })
                .OrderByDescending(x => x.Score)
                .ToList();

            // Log top 3 candidates
            foreach (var candidate in scoredProducts.Take(3))
            {
                _logger.LogInformation("Candidate: '{Name}' (Brand: {Brand}) - Score: {Score}, HasNutrition: {HasNut}",
                    candidate.Product.ProductName,
                    candidate.Product.Brands ?? "Generic",
                    candidate.Score,
                    candidate.Product.Nutriments != null);
            }

            // STEP 3: Pick the best one
            // Strategy: Prefer products with nutrition data, but don't require it
            var withNutrition = scoredProducts.Where(x => x.Product.Nutriments != null).ToList();

            if (withNutrition.Any())
            {
                var best = withNutrition.First();
                _logger.LogInformation("Best match for '{SearchTerm}': '{ProductName}' (Score: {Score}) - Has nutrition data",
                    searchTerm, best.Product.ProductName, best.Score);
                return best.Product;
            }

            // Fallback: Return highest scored product even without nutrition
            if (scoredProducts.Any())
            {
                var best = scoredProducts.First();
                _logger.LogWarning("Best match for '{SearchTerm}': '{ProductName}' (Score: {Score}) - NO nutrition data",
                    searchTerm, best.Product.ProductName, best.Score);
                return best.Product;
            }

            return null;
        }

        private int CalculateRelevanceScore(Product product, string searchTerm)
        {
            var productName = product.ProductName?.ToLower() ?? "";
            var brand = product.Brands?.ToLower() ?? "";

            int score = 0;

            // BASE SCORE: Does the product name contain the search term?
            if (!productName.Contains(searchTerm))
            {
                // Check if search term is contained in any word of the product name
                var productWords = productName.Split(new[] { ' ', '-', ',', '/' }, StringSplitOptions.RemoveEmptyEntries);
                var searchWords = searchTerm.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                // Check if any search word matches any product word
                var hasWordMatch = searchWords.Any(sw => productWords.Any(pw => pw.Contains(sw)));

                if (!hasWordMatch)
                {
                    // No match at all - give minimal score but don't exclude
                    score = 10; // Minimal score so it's not filtered out completely
                }
                else
                {
                    score = 100; // Partial word match
                }
            }
            else
            {
                // Product name contains search term - good match!
                score = 300;
            }

            // EXACT MATCH = highest priority
            if (productName == searchTerm)
                score += 1000;

            // STARTS WITH search term = very relevant
            if (productName.StartsWith(searchTerm))
                score += 500;

            // WORD BOUNDARY MATCH (e.g., "agave" matches "agave syrup" at word start)
            var words = productName.Split(new[] { ' ', '-', ',', '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Any(word => word == searchTerm))
                score += 400;

            if (words.Any(word => word.StartsWith(searchTerm)))
                score += 200;

            // PREFER GENERIC PRODUCTS (no brand or common brands)
            if (string.IsNullOrWhiteSpace(brand))
                score += 100; // Generic = more universal
            else if (IsCommonBrand(brand))
                score += 50; // Well-known brand = reliable data

            // PREFER SIMPLE NAMES (less processing, more universal)
            var lowerName = productName.ToLower();

            // Bonus for simple, whole food terms
            if (lowerName.Contains("organic") || lowerName.Contains("fresh") || lowerName.Contains("raw") || lowerName.Contains("natural"))
                score += 30;

            // Small penalty for overly processed
            if (lowerName.Contains("frozen") || lowerName.Contains("canned"))
                score -= 10;

            if (lowerName.Contains("microwave") || lowerName.Contains("instant") || lowerName.Contains("flavored"))
                score -= 20;

            // PREFER PRODUCTS WITH COMPLETE NUTRITION DATA
            if (product.Nutriments != null)
            {
                score += 50; // Bonus for having nutrition object

                if (product.Nutriments.EnergyKcal100g > 0) score += 10;
                if (product.Nutriments.Proteins100g > 0) score += 10;
                if (product.Nutriments.Carbohydrates100g > 0) score += 10;
                if (product.Nutriments.Fat100g > 0) score += 10;
            }

            // PENALIZE extremely long names (likely very specific branded products)
            if (productName.Length > 60)
                score -= 30;
            else if (productName.Length > 40)
                score -= 10;

            // BONUS: Shorter, simpler names
            if (productName.Length < 20)
                score += 20;

            return Math.Max(score, 1); // Ensure minimum score of 1 (never 0 or negative)
        }

        private bool IsCommonBrand(string brand)
        {
            var commonBrands = new HashSet<string>
    {
        "generic", "store brand", "great value", "kirkland",
        "trader joe's", "365", "whole foods", "organic valley",
        "simple truth", "market pantry", "good & gather",
        "aldi", "lidl", "tesco", "simply nature"
    };

            return commonBrands.Any(b => brand.ToLower().Contains(b));
        }

        // PRIVATE HELPER: Apply sorting to in-memory collection
        private IEnumerable<Ingredient> ApplySorting(
            IEnumerable<Ingredient> ingredients,
            string? sortBy,
            string? sortOrder)
        {
            var isDescending = sortOrder?.ToLower() == "desc";

            return sortBy?.ToLower() switch
            {
                "name" => isDescending
                    ? ingredients.OrderByDescending(i => i.Name)
                    : ingredients.OrderBy(i => i.Name),

                "calories" => isDescending
                    ? ingredients.OrderByDescending(i => i.CaloriesPer100g)
                    : ingredients.OrderBy(i => i.CaloriesPer100g),

                "protein" => isDescending
                    ? ingredients.OrderByDescending(i => i.ProteinPer100g)
                    : ingredients.OrderBy(i => i.ProteinPer100g),

                "carbs" => isDescending
                    ? ingredients.OrderByDescending(i => i.CarbsPer100g)
                    : ingredients.OrderBy(i => i.CarbsPer100g),

                "fat" => isDescending
                    ? ingredients.OrderByDescending(i => i.FatPer100g)
                    : ingredients.OrderBy(i => i.FatPer100g),

                _ => ingredients.OrderBy(i => i.Name) // Default: alphabetical
            };
        }

        public async Task<Ingredient?> GetIngredientByNameAsync(string name)
        {
            try
            {
                return await _context.Ingredients
                    .Where(i => !i.Deleted && i.Name.ToLower() == name.ToLower())
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient with name {Name}", name);
                return null;
            }
        }

        public async Task<IEnumerable<Ingredient>> SearchIngredientAsync(string searchTerm)
        {
            try
            {
                return await _context.Ingredients
                    .Where(i => !i.Deleted && i.Name.Contains(searchTerm))
                    .OrderBy(i => i.Name)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching ingredients with term {SearchTerm}", searchTerm);
                return Enumerable.Empty<Ingredient>();
            }
        }

        // Add this lighter method to your IngredientService for autocomplete
        public async Task<IEnumerable<Ingredient>> SearchIngredientsWithApiAsync(
            string searchTerm,
            int maxResults = 10,
            Guid? userId = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                    return Enumerable.Empty<Ingredient>();

                var searchLower = searchTerm.ToLower();

                // Get from DB
                var dbResults = await _context.Ingredients
                    .Where(i => !i.Deleted && i.Name.ToLower().Contains(searchLower))
                    .OrderBy(i => i.Name)
                    .Take(maxResults)
                    .ToListAsync();

                // If we have enough, return
                if (dbResults.Count >= maxResults)
                    return dbResults;

                // Otherwise enrich from API
                try
                {
                    var apiResults = await FetchAndSaveFromApiAsync(searchTerm, userId);
                    var combined = dbResults.Concat(apiResults)
                        .DistinctBy(i => i.Id)
                        .Take(maxResults);

                    return combined;
                }
                catch (Exception apiEx)
                {
                    _logger.LogWarning(apiEx, "API search failed, returning DB results only");
                    return dbResults;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SearchIngredientsWithApiAsync");
                return Enumerable.Empty<Ingredient>();
            }
        }

        private Ingredient MapProductToIngredient(Api.Models.Product product, Guid? userId)
        {
            return new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = product.ProductName ?? "Unknown Product",
                Brand = product.Brands,
                CaloriesPer100g = product.Nutriments?.EnergyKcal100g ?? 0,
                ProteinPer100g = product.Nutriments?.Proteins100g ?? 0,
                CarbsPer100g = product.Nutriments?.Carbohydrates100g ?? 0,
                FatPer100g = product.Nutriments?.Fat100g ?? 0,
                Source = Source.Api,
                CreatedByUserId = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
 }

