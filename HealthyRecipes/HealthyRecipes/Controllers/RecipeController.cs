using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Services.Allergies;
using HealthyRecipes.Services.Categories;
using HealthyRecipes.Services.CommentRatings;
using HealthyRecipes.Services.FileUploads;
using HealthyRecipes.Services.Ingredients;
using HealthyRecipes.Services.RecipeCategories;
using HealthyRecipes.Services.RecipeIngredients;
using HealthyRecipes.Services.Recipes;
using HealthyRecipes.Services.Recipes.Models;
using HealthyRecipes.Services.Recommendations;
using HealthyRecipes.Services.Recommendations.NewFolder;
using HealthyRecipes.Services.SavedRecipes;
using HealthyRecipes.Services.Statistics.Interfaces;
using HealthyRecipes.Web.ViewModels.Recipe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Xml.Linq;

namespace HealthyRecipes.Web.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipe _recipeService;
        private readonly ICategory _categoryService;
        private readonly IIngredient _ingredientService;
        private readonly IRecipeIngredient _recipeIngredientService;
        private readonly IRecipeCategory _recipeCategoryService;
        private readonly ICommentRating _commentRatingService;
        private readonly ISavedRecipe _savedRecipeService;
        private readonly IAllergy _allergyService;
        private readonly IRecipeStatistics _recipeStatisticsService;
        private readonly IRecommendation _recommendationService;
        private readonly IFileUpload _fileUploadService;
        private readonly UserManager<ApplicationUser> _userManager;

        public RecipeController(
            IRecipe recipeService,
            ICategory categoryService,
            IIngredient ingredientService,
            IRecipeIngredient recipeIngredientService,
            IRecipeCategory recipeCategoryService,
            ICommentRating commentRatingService,
            ISavedRecipe savedRecipeService,
            IAllergy allergyService,
            IRecipeStatistics recipeStatisticsService,
            IRecommendation recommendationService,
            IFileUpload fileUploadService,
            UserManager<ApplicationUser> userManager)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
            _ingredientService = ingredientService;
            _recipeIngredientService = recipeIngredientService;
            _recipeCategoryService = recipeCategoryService;
            _commentRatingService = commentRatingService;
            _savedRecipeService = savedRecipeService;
            _allergyService = allergyService;
            _recipeStatisticsService = recipeStatisticsService;
            _recommendationService = recommendationService;
            _fileUploadService = fileUploadService;
            _userManager = userManager;
        }

        // GET: /Recipe
        public async Task<IActionResult> Index([FromQuery] RecipeFilterViewModel filter)
        {
            try
            {
                Guid? currentUserId = null;
                if (User.Identity?.IsAuthenticated == true)
                {
                    var user = await _userManager.GetUserAsync(User);
                    currentUserId = user?.Id;
                }

                // Map ViewModel to DTO
                var filterDto = new RecipeFilterDto
                {
                    SearchTerm = filter.SearchTerm,
                    MinCalories = filter.MinCalories,
                    MaxCalories = filter.MaxCalories,
                    MinProtein = filter.MinProtein,
                    MaxProtein = filter.MaxProtein,
                    MinCarbs = filter.MinCarbs,
                    MaxCarbs = filter.MaxCarbs,
                    MinFat = filter.MinFat,
                    MaxFat = filter.MaxFat,
                    MaxPreparationTime = filter.MaxPreparationTime,
                    DifficultyLevel = filter.DifficultyLevel,
                    IncludeIngredients = filter.IncludeIngredients,
                    ExcludeIngredients = filter.ExcludeIngredients,
                    ExcludeUserAllergies = filter.ExcludeUserAllergies,
                    UserId = currentUserId,
                    CategoryIds = filter.CategoryIds,
                    PageNumber = filter.PageNumber,
                    PageSize = filter.PageSize,
                    SortBy = filter.SortBy,
                    SortOrder = filter.SortOrder
                };

                // Get filtered recipes from service (this does all the heavy lifting)
                var (recipes, totalCount) = await _recipeService.GetFilteredRecipesAsync(filterDto);

                // Get all categories for filter UI
                var categories = await _categoryService.GetAllCategoriesAsync();

                // Get saved recipe IDs and allergies for current user
                HashSet<Guid> savedIds = new();
                HashSet<Guid> allergyIngredientIds = new();
                List<Recipe> myRecipes = new List<Recipe>();
                
                    
                    if (currentUserId != null)
                    {
                        var my = await _recipeService.GetRecipesByUserAsync((Guid)currentUserId);
                        myRecipes = my.ToList();

                        var saved = await _savedRecipeService.GetSavedRecipesByUserAsync((Guid)currentUserId);
                        savedIds = saved.Select(sr => sr.RecipeId).ToHashSet();

                        var allergies = await _allergyService.GetAllergiesByUserAsync((Guid)currentUserId);
                        allergyIngredientIds = allergies.Select(a => a.IngredientId).ToHashSet();
                    }
                

                // Map My Recipes
                var myCards = new List<RecipeCardViewModel>();
                foreach (var recipe in myRecipes)
                {
                    var avgRating = await _commentRatingService.GetAverageRatingAsync(recipe.Id);
                    var ratings = await _commentRatingService.GetRatingsByRecipeAsync(recipe.Id);
                    var recipeCategories = await _recipeCategoryService.GetCategoriesByRecipeAsync(recipe.Id);

                    myCards.Add(new RecipeCardViewModel
                    {
                        Id = recipe.Id,
                        Title = recipe.Title,
                        Info = recipe.Info,
                        Calories = recipe.Calories,
                        Protein = recipe.Protein,
                        Carbs = recipe.Carbs,
                        Fat = recipe.Fat,
                        PrepTime = recipe.PrepTime,
                        Difficulty = recipe.Difficulty,
                        ImageUrl = recipe.ImageUrl,
                        AverageRating = avgRating,
                        RatingCount = ratings.Count(),
                        CategoryNames = recipeCategories.Select(rc => rc.Category?.Name ?? "").Where(n => n != ""),
                        IsSaved = savedIds.Contains(recipe.Id),
                        AuthorName = recipe.User?.UserName ?? "Unknown"
                    });
                }

                // Map to RecipeCardViewModel
                var cards = new List<RecipeCardViewModel>();
                foreach (var recipe in recipes)
                {
                    var avgRating = await _commentRatingService.GetAverageRatingAsync(recipe.Id);
                    var ratings = await _commentRatingService.GetRatingsByRecipeAsync(recipe.Id);
                    var recipeCategories = await _recipeCategoryService.GetCategoriesByRecipeAsync(recipe.Id);

                    cards.Add(new RecipeCardViewModel
                    {
                        Id = recipe.Id,
                        Title = recipe.Title,
                        Info = recipe.Info,
                        Calories = recipe.Calories,
                        Protein = recipe.Protein,
                        Carbs = recipe.Carbs,
                        Fat = recipe.Fat,
                        PrepTime = recipe.PrepTime,
                        Difficulty = recipe.Difficulty,
                        ImageUrl = recipe.ImageUrl,
                        AverageRating = avgRating,
                        RatingCount = ratings.Count(),
                        CategoryNames = recipeCategories.Select(rc => rc.Category?.Name ?? "").Where(n => n != ""),
                        IsSaved = savedIds.Contains(recipe.Id),
                        AuthorName = recipe.User?.UserName ?? "Unknown"
                    });
                }

                // Create view model
                var vm = new RecipeIndexViewModel
                {
                    Recipes = cards,
                    MyRecipes = myCards,
                    SearchQuery = filter.SearchTerm,
                    SelectedCategoryId = filter.CategoryIds.FirstOrDefault(),
                    CurrentPage = filter.PageNumber,
                    TotalPages = (int)Math.Ceiling((double)totalCount / filter.PageSize),
                    Categories = categories.Select(c => new CategoryFilterViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    }),
                    Filter = filter,
                    TotalCount = totalCount
                };

                return View(vm);
            }
            catch (Exception ex)
            {

                TempData["Error"] = "An error occurred while loading recipes.";

                return View(new RecipeIndexViewModel
                {
                    Filter = filter ?? new RecipeFilterViewModel(),
                    Categories = new List<CategoryFilterViewModel>()
                });
            }
        }

        // GET: /Recipe/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null)
                return NotFound();

            var avgRating = await _commentRatingService.GetAverageRatingAsync(id);
            var topLevelComments = await _commentRatingService.GetTopLevelCommentsWithRepliesAsync(id);
            var recipeIngredients = await _recipeIngredientService.GetIngredientsByRecipeAsync(id);
            var recipeCategories = await _recipeCategoryService.GetCategoriesByRecipeAsync(id);

            Guid? currentUserId = null;
            bool isSaved = false;
            HashSet<Guid> allergyIngredientIds = new();
            CommentRatingFormViewModel? currentUserComment = null;

            if (User.Identity?.IsAuthenticated == true)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    currentUserId = user.Id;
                    isSaved = await _savedRecipeService.IsRecipeSavedAsync(user.Id, id);

                    var allergies = await _allergyService.GetAllergiesByUserAsync(user.Id);
                    allergyIngredientIds = allergies.Select(a => a.IngredientId).ToHashSet();

                    var existing = await _commentRatingService.GetCommentRatingAsync(user.Id, id);
                    if (existing != null)
                    {
                        currentUserComment = new CommentRatingFormViewModel
                        {
                            RecipeId = id,
                            Rating = existing.Rating!.Value, // Now Rating is nullable, so use .Value
                            Comment = existing.Comment
                        };
                    }
                }
            }

            var ingredientVms = recipeIngredients.Select(ri => new RecipeIngredientViewModel
            {
                IngredientId = ri.IngredientId,
                IngredientName = ri.Ingredient?.Name ?? "Unknown",
                QuantityInGrams = ri.QuantityInGrams,
                IngredientCaloriesPer100g = ri.Ingredient?.CaloriesPer100g ?? 0,
                IsAllergen = ri.Ingredient != null && allergyIngredientIds.Contains(ri.IngredientId)
            }).ToList();

            var conflictingIngredients = ingredientVms
                .Where(i => i.IsAllergen)
                .Select(i => i.IngredientName)
                .ToList();
            //var stats = await _recipeStatisticsService.GetRecipeStatisticsAsync(id);
            var similarRecipes = await _recommendationService.GetSimilarRecipesAsync(id, 6);

            var vm = new RecipeDetailsViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Info = recipe.Info,
                Calories = recipe.Calories,
                Protein = recipe.Protein,
                Carbs = recipe.Carbs,
                Fat = recipe.Fat,
                PrepTime = recipe.PrepTime,
                Difficulty = recipe.Difficulty,
                Servings = recipe.Servings,
                ImageUrl = recipe.ImageUrl,
                VideoUrl = recipe.VideoUrl,
                AuthorName = recipe.User?.UserName ?? "Unknown",
                AuthorId = recipe.UserId,
                CreatedAt = recipe.CreatedAt,
                AverageRating = avgRating,
                IsSaved = isSaved,
                CategoryNames = recipeCategories.Select(rc => rc.Category?.Name ?? "").Where(n => n != ""),
                Ingredients = ingredientVms,
                Comments = MapCommentViewModels(topLevelComments, currentUserId, recipe.UserId),
                TotalCommentCount = await _commentRatingService.GetTotalCommentCountAsync(id),
                CurrentUserComment = currentUserComment,
                HasAllergyConflict = conflictingIngredients.Any(),
                ConflictingIngredients = conflictingIngredients,
                SimilarRecipes = similarRecipes
            };

            return View(vm);
        }

        // GET: /Recipe/SearchIngredients
        [HttpGet]
        public async Task<IActionResult> SearchIngredients(string term)
        {
            if (string.IsNullOrWhiteSpace(term) || term.Length < 2)
            {
                return Json(new List<object>());
            }

            var ingredients = await _ingredientService.SearchIngredientsAsync(term);

            var results = ingredients.Select(i => new
            {
                id = i.Id.ToString(),
                name = i.Name,
                caloriesPer100g = i.CaloriesPer100g
            }).ToList();

            return Json(results);
        }

        // GET: /Recipe/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var vm = new CreateRecipeViewModel
            {
                AvailableCategories = categories.Select(c => new CategoryFilterViewModel { Id = c.Id, Name = c.Name })
            };
            return View(vm);
        }

        // POST: /Recipe/Create
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRecipeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var cats = await _categoryService.GetAllCategoriesAsync();
                vm.AvailableCategories = cats.Select(c => new CategoryFilterViewModel { Id = c.Id, Name = c.Name });
                return View(vm);
            }

            // Handle image upload
            string? imageUrl = null;
            if (vm.ImageFile != null)
            {
                if (!_fileUploadService.IsValidImage(vm.ImageFile))
                {
                    ModelState.AddModelError("ImageFile", "Invalid image file. Allowed: JPG, PNG, WebP. Max size: 5MB");
                    return View(vm);
                }
                imageUrl = await _fileUploadService.UploadImageAsync(vm.ImageFile);
            }

            // Handle video upload
            string? videoUrl = null;
            if (vm.VideoFile != null)
            {
                if (!_fileUploadService.IsValidVideo(vm.VideoFile))
                {
                    ModelState.AddModelError("VideoFile", "Invalid video file. Allowed: MP4, WebM. Max size: 100MB");
                    return View(vm);
                }
                videoUrl = await _fileUploadService.UploadVideoAsync(vm.VideoFile);
            }

            var user = await _userManager.GetUserAsync(User);
            var recipe = new Recipe
            {
                Title = vm.Title,
                Info = vm.Info,
                PrepTime = vm.PrepTime,
                Difficulty = vm.Difficulty,
                Servings = vm.Servings,
                ImageUrl = imageUrl,
                VideoUrl = videoUrl,
                UserId = user!.Id
            };

            var recipeId = await _recipeService.CreateRecipeAsync(recipe);

            foreach (var catId in vm.SelectedCategoryIds)
                await _recipeCategoryService.AddCategoryToRecipeAsync(recipeId, catId);

            foreach (var ing in vm.Ingredients.Where(i => i.IngredientId != Guid.Empty))
                await _recipeIngredientService.AddIngredientToRecipeAsync(recipeId, ing.IngredientId, ing.QuantityInGrams);

            await _recipeService.RecalculateRecipeNutritionAsync(recipeId);

            return RedirectToAction(nameof(Details), new { id = recipeId });
        }

        // GET: /Recipe/Edit/{id}
        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (recipe.UserId != user!.Id && !User.IsInRole("Admin"))
                return Forbid();

            var categories = await _categoryService.GetAllCategoriesAsync();
            var recipeCategories = await _recipeCategoryService.GetCategoriesByRecipeAsync(id);
            var recipeIngredients = await _recipeIngredientService.GetIngredientsByRecipeAsync(id);

            

            var vm = new EditRecipeViewModel
            {
                Id = id,
                Title = recipe.Title,
                Info = recipe.Info,
                PrepTime = recipe.PrepTime,
                Difficulty = recipe.Difficulty,
                Servings = recipe.Servings,
                CurrentImageUrl = recipe.ImageUrl,  // Store current image
                CurrentVideoUrl = recipe.VideoUrl,  // Store current video
                SelectedCategoryIds = recipeCategories.Select(rc => rc.CategoryId).ToList(),
                AvailableCategories = categories.Select(c => new CategoryFilterViewModel { Id = c.Id, Name = c.Name }),
                Ingredients = recipeIngredients.Select(ri => new RecipeIngredientInputViewModel
                {
                    IngredientId = ri.IngredientId,
                    QuantityInGrams = ri.QuantityInGrams
                }).ToList()
            };

            return View(vm);
        }

        // POST: /Recipe/Edit/{id}
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditRecipeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var cats = await _categoryService.GetAllCategoriesAsync();
                vm.AvailableCategories = cats.Select(c => new CategoryFilterViewModel { Id = c.Id, Name = c.Name });
                return View(vm);
            }

            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (recipe.UserId != user!.Id && !User.IsInRole("Admin"))
                return Forbid();

            // Update basic properties
            recipe.Title = vm.Title;
            recipe.Info = vm.Info;
            recipe.PrepTime = vm.PrepTime;
            recipe.Difficulty = vm.Difficulty;
            recipe.Servings = vm.Servings;

            // Handle NEW image upload
            if (vm.NewImageFile != null)
            {
                // Validate image
                if (!_fileUploadService.IsValidImage(vm.NewImageFile))
                {
                    ModelState.AddModelError("NewImageFile", "Invalid image file. Allowed: JPG, PNG, WebP. Max size: 5MB");
                    var cats = await _categoryService.GetAllCategoriesAsync();
                    vm.AvailableCategories = cats.Select(c => new CategoryFilterViewModel { Id = c.Id, Name = c.Name });
                    return View(vm);
                }

                // Delete old image if exists
                if (!string.IsNullOrEmpty(recipe.ImageUrl))
                {
                    await _fileUploadService.DeleteFileAsync(recipe.ImageUrl);
                }

                // Upload new image
                recipe.ImageUrl = await _fileUploadService.UploadImageAsync(vm.NewImageFile);
            }


            // Handle NEW video upload
            if (vm.NewVideoFile != null)
            {
                // Validate video
                if (!_fileUploadService.IsValidVideo(vm.NewVideoFile))
                {
                    ModelState.AddModelError("NewVideoFile", "Invalid video file. Allowed: MP4, WebM. Max size: 100MB");
                    var cats = await _categoryService.GetAllCategoriesAsync();
                    vm.AvailableCategories = cats.Select(c => new CategoryFilterViewModel { Id = c.Id, Name = c.Name });
                    return View(vm);
                }

                // Delete old video if exists
                if (!string.IsNullOrEmpty(recipe.VideoUrl))
                {
                    await _fileUploadService.DeleteFileAsync(recipe.VideoUrl);
                }

                // Upload new video
                recipe.VideoUrl = await _fileUploadService.UploadVideoAsync(vm.NewVideoFile);
            }

            // ===== ADD THIS SECTION - Update Categories =====
            // Get current category associations
            var currentCategories = await _recipeCategoryService.GetCategoriesByRecipeAsync(id);
            var currentCategoryIds = currentCategories.Select(rc => rc.CategoryId).ToHashSet();

            // Remove categories that are no longer selected
            foreach (var currentCategoryId in currentCategoryIds)
            {
                if (!vm.SelectedCategoryIds.Contains(currentCategoryId))
                {
                    await _recipeCategoryService.RemoveCategoryFromRecipeAsync(id, currentCategoryId);
                }
            }

            // Add newly selected categories
            foreach (var selectedCategoryId in vm.SelectedCategoryIds)
            {
                if (!currentCategoryIds.Contains(selectedCategoryId))
                {
                    await _recipeCategoryService.AddCategoryToRecipeAsync(id, selectedCategoryId);
                }
            }

            await _recipeService.UpdateRecipeAsync(recipe);
            await _recipeService.RecalculateRecipeNutritionAsync(id);

            return RedirectToAction(nameof(Details), new { id });
        }

        // POST: /Recipe/Delete/{id}
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (recipe.UserId != user!.Id && !User.IsInRole("Admin"))
                return Forbid();

            // DELETE FILES FIRST (before soft-deleting recipe)
            if (!string.IsNullOrEmpty(recipe.ImageUrl))
            {
                await _fileUploadService.DeleteFileAsync(recipe.ImageUrl);
            }

            if (!string.IsNullOrEmpty(recipe.VideoUrl))
            {
                await _fileUploadService.DeleteFileAsync(recipe.VideoUrl);
            }

            // NOW soft delete the recipe
            await _recipeService.SoftDeleteRecipeAsync(id);

            TempData["Success"] = "Recipe deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        // POST: /Recipe/ToggleSave/{id}
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleSave(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            bool isSaved = await _savedRecipeService.IsRecipeSavedAsync(user!.Id, id);
            if (isSaved)
                await _savedRecipeService.UnsaveRecipeAsync(user.Id, id);
            else
                await _savedRecipeService.SaveRecipeAsync(user.Id, id);

            return RedirectToAction(nameof(Details), new { id });
        }

        // POST: /Recipe/Rate
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Rate(CommentRatingFormViewModel vm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Details), new { id = vm.RecipeId });

            var user = await _userManager.GetUserAsync(User);
            await _commentRatingService.AddOrUpdateCommentRatingAsync(user!.Id, vm.RecipeId, vm.Rating, vm.Comment);

            return RedirectToAction(nameof(Details), new { id = vm.RecipeId });
        }

        // POST: /Recipe/DeleteComment
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComment(Guid recipeId)
        {
            var user = await _userManager.GetUserAsync(User);
            await _commentRatingService.RemoveCommentRatingAsync(user!.Id, recipeId);
            return RedirectToAction(nameof(Details), new { id = recipeId });
        }

        /// <summary>
        /// Netflix-style "For You" recommendation page
        /// </summary>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Recommended()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var userName = User.Identity?.Name ?? "there";

            // Check if user has goals set
            var user = await _userManager.GetUserAsync(User);
            var hasGoals = user?.Calories != null && user?.ProteinGoal != null;

            var personalizedRecipes = await _recommendationService
                .GetPersonalizedRecipesAsync(userId, 12);

            var goalsRecipes = hasGoals
                ? await _recommendationService.GetRecommendedForGoalsAsync(userId, 12)
                : Enumerable.Empty<RecipeRecommendationDto>();

            var collaborativeRecipes = await _recommendationService
                .GetCollaborativeRecommendationsAsync(userId, 12);

            var viewModel = new RecommendedRecipesViewModel
            {
                PersonalizedRecipes = personalizedRecipes.ToList(),
                ForYourGoals = goalsRecipes.ToList(),
                Collaborative = collaborativeRecipes.ToList(),
                HasGoals = hasGoals,
                UserName = userName
            };

            return View(viewModel);
        }

        /// <summary>
        /// Trending recipes in a category
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Trending(Guid? categoryId)
        {
            var userId = User.Identity?.IsAuthenticated == true
                ? Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!)
                : Guid.Empty;

            IEnumerable<RecipeRecommendationDto> trending;

            if (categoryId.HasValue && userId != Guid.Empty)
            {
                // Trending in specific category
                trending = await _recommendationService.GetTrendingInCategoryAsync(categoryId.Value, userId, 20);
                var category = await _categoryService.GetCategoryByIdAsync(categoryId.Value);
                ViewBag.CategoryName = category?.Name ?? "Unknown Category";
            }
            else
            {
                // Return empty or redirect to index
                TempData["Info"] = "Please select a category to view trending recipes.";
                return RedirectToAction(nameof(Index));
            }

            return View(trending);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddIngredient(Guid recipeId, Guid ingredientId, float quantity)
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return Json(new { success = false, message = "You must be logged in." });
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var recipe = await _recipeService.GetRecipeByIdAsync(recipeId);

            if (recipe == null)
            {
                return Json(new { success = false, message = "Recipe not found." });
            }

            if (recipe.UserId != userId)
            {
                return Json(new { success = false, message = "You can only edit your own recipes." });
            }

            try
            {
                await _recipeService.AddIngredientToRecipeAsync(recipeId, ingredientId, quantity);
                await _recipeService.RecalculateRecipeNutritionAsync(recipeId);
                var ingredient = await _ingredientService.GetIngredientByIdAsync(ingredientId);

                return Json(new
                {
                    success = true,
                    ingredientId = ingredientId,
                    ingredientName = ingredient.Name,
                    quantity = quantity
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveIngredient(Guid recipeId, Guid ingredientId)
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return Json(new { success = false, message = "You must be logged in." });
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var recipe = await _recipeService.GetRecipeByIdAsync(recipeId);

            if (recipe == null)
            {
                return Json(new { success = false, message = "Recipe not found." });
            }

            if (recipe.UserId != userId)
            {
                return Json(new { success = false, message = "You can only edit your own recipes." });
            }

            try
            {
                await _recipeService.RemoveIngredientFromRecipeAsync(recipeId, ingredientId);
                await _recipeService.RecalculateRecipeNutritionAsync(recipeId);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // POST: /Recipe/AddReply
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReply(Guid recipeId, Guid parentCommentId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return RedirectToAction(nameof(Details), new { id = recipeId });

            var user = await _userManager.GetUserAsync(User);
            await _commentRatingService.AddReplyAsync(parentCommentId, user!.Id, content);

            return RedirectToAction(nameof(Details), new { id = recipeId });
        }

        // POST: /Recipe/UpdateComment
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateComment(Guid commentId, Guid recipeId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return RedirectToAction(nameof(Details), new { id = recipeId });

            var user = await _userManager.GetUserAsync(User);
            var success = await _commentRatingService.UpdateCommentAsync(commentId, user!.Id, content);

            if (!success)
                TempData["Error"] = "Unable to update comment";

            return RedirectToAction(nameof(Details), new { id = recipeId });
        }

        // POST: /Recipe/DeleteCommentById
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCommentById(Guid commentId, Guid recipeId)
        {
            var user = await _userManager.GetUserAsync(User);
            var success = await _commentRatingService.DeleteCommentAsync(commentId, user!.Id);

            if (!success)
                TempData["Error"] = "Unable to delete comment";

            return RedirectToAction(nameof(Details), new { id = recipeId });
        }

        // POST: /Recipe/TogglePinComment
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> TogglePinComment(Guid commentId, Guid recipeId)
        {
            var user = await _userManager.GetUserAsync(User);
            var success = await _commentRatingService.TogglePinAsync(commentId, user!.Id);

            if (!success)
                TempData["Error"] = "Unable to pin/unpin comment";

            return RedirectToAction(nameof(Details), new { id = recipeId });
        }

        private List<CommentViewModel> MapCommentViewModels(IEnumerable<CommentRating> comments, Guid? currentUserId, Guid recipeOwnerId)
        {
            return comments.Select(c => new CommentViewModel
            {
                Id = c.Id,
                UserId = c.UserId,
                UserName = c.User?.UserName ?? "Unknown",
                UserImageUrl = c.User?.ImageUrl,
                Rating = c.Rating,
                Comment = c.Comment,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
                IsCurrentUser = currentUserId.HasValue && c.UserId == currentUserId.Value,
                IsRecipeOwner = c.UserId == recipeOwnerId,
                IsPinned = c.IsPinned,
                Replies = MapCommentViewModels(c.Replies.OrderBy(r => r.CreatedAt), currentUserId, recipeOwnerId)
            }).ToList();
        }
    }
}
