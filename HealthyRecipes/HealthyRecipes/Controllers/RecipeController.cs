using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Services.Admin.Helpers;
using HealthyRecipes.Services.Admin.Interfaces;
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
        private readonly ISavedIngredients _savedRecipeService;
        private readonly IAllergy _allergyService;
        private readonly IRecipeStatistics _recipeStatisticsService;
        private readonly IRecommendation _recommendationService;
        private readonly IFileUpload _fileUploadService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IActivityLog _activityLogService;
        private readonly IContentFilter _contentFilterService;
        private readonly IFlaggedContent _flaggedContentService;
        private readonly ActivityLogHelper _activityLogHelper;

        public RecipeController(
            IRecipe recipeService,
            ICategory categoryService,
            IIngredient ingredientService,
            IRecipeIngredient recipeIngredientService,
            IRecipeCategory recipeCategoryService,
            ICommentRating commentRatingService,
            ISavedIngredients savedRecipeService,
            IAllergy allergyService,
            IRecipeStatistics recipeStatisticsService,
            IRecommendation recommendationService,
            IFileUpload fileUploadService,
            UserManager<ApplicationUser> userManager,
            IActivityLog activityLogService,
            IContentFilter contentFilterService,
            IFlaggedContent flaggedContentService,
            ActivityLogHelper activityLogHelper)
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
            _activityLogService = activityLogService;
            _contentFilterService = contentFilterService;
            _flaggedContentService = flaggedContentService;
            _activityLogHelper = activityLogHelper;
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
                var filterDto = new IngredientFilterDto
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
                        ImageUrl = recipe.PrimaryImageUrl,
                        AverageRating = avgRating,
                        RatingCount = ratings.Count(),
                        CategoryNames = recipeCategories.Select(rc => rc.Category?.Name ?? "").Where(n => n != ""),
                        IsSaved = savedIds.Contains(recipe.Id),
                        AuthorName = recipe.User?.UserName ?? "Unknown",
                        AuthorId = recipe.UserId
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
                        ImageUrl = recipe.PrimaryImageUrl,
                        AverageRating = avgRating,
                        RatingCount = ratings.Count(),
                        CategoryNames = recipeCategories.Select(rc => rc.Category?.Name ?? "").Where(n => n != ""),
                        IsSaved = savedIds.Contains(recipe.Id),
                        AuthorName = recipe.User?.UserName ?? "Unknown",
                        AuthorId = recipe.UserId
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
                IsAllergen = ri.Ingredient != null && allergyIngredientIds.Contains(ri.IngredientId),
                // Add measurement properties
                OriginalUnit = ri.OriginalUnit,
                QuantityInTeaspoons = ri.QuantityInTeaspoons,
                QuantityInTablespoons = ri.QuantityInTablespoons,
                QuantityInCups = ri.QuantityInCups,
                QuantityInCoffeeCups = ri.QuantityInCoffeeCups,
                QuantityInMillilitres = ri.QuantityInMillilitres
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
                ImageUrl = recipe.PrimaryImageUrl,
                ImageUrls = recipe.ImageUrls ?? new List<string>(),
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

            // Handle multiple image uploads
            List<string> imageUrls = new();
            string? primaryImageUrl = null;

            if (vm.ImageFiles != null && vm.ImageFiles.Any())
            {
                // Validate all images first
                foreach (var file in vm.ImageFiles)
                {
                    if (!_fileUploadService.IsValidImage(file))
                    {
                        ModelState.AddModelError("ImageFiles", $"Invalid image file: {file.FileName}. Allowed: JPG, PNG, WebP. Max size: 5MB");
                        var cats = await _categoryService.GetAllCategoriesAsync();
                        vm.AvailableCategories = cats.Select(c => new CategoryFilterViewModel { Id = c.Id, Name = c.Name });
                        return View(vm);
                    }
                }

                // Upload all images (max 5)
                imageUrls = await _fileUploadService.UploadMultipleImagesAsync(vm.ImageFiles, "recipes", maxFiles: 5);

                // Set first image as primary
                if (imageUrls.Any())
                {
                    primaryImageUrl = imageUrls.First();
                }
            }

            // Handle video upload
            string? videoUrl = null;
            if (vm.VideoFile != null)
            {
                if (!_fileUploadService.IsValidVideo(vm.VideoFile))
                {
                    ModelState.AddModelError("VideoFile", "Invalid video file. Allowed: MP4, WebM. Max size: 100MB");
                    var cats = await _categoryService.GetAllCategoriesAsync();
                    vm.AvailableCategories = cats.Select(c => new CategoryFilterViewModel { Id = c.Id, Name = c.Name });
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
                PrimaryImageUrl = primaryImageUrl,
                ImageUrls = imageUrls,
                VideoUrl = videoUrl,
                UserId = user!.Id
            };

            var recipeId = await _recipeService.CreateRecipeAsync(recipe);

            foreach (var catId in vm.SelectedCategoryIds)
                await _recipeCategoryService.AddCategoryToRecipeAsync(recipeId, catId);

            foreach (var ing in vm.Ingredients.Where(i => i.IngredientId != Guid.Empty))
            {
                var originalQuantity = (ing.OriginalUnit?.ToLower()) switch
                {
                    "teaspoons" => ing.QuantityInTeaspoons ?? 0,
                    "tablespoons" => ing.QuantityInTablespoons ?? 0,
                    "cups" => ing.QuantityInCups ?? 0,
                    "coffeecups" => ing.QuantityInCoffeeCups ?? 0,
                    "millilitres" => ing.QuantityInMillilitres ?? 0,
                    _ => ing.QuantityInGrams
                };

                await _recipeIngredientService.AddIngredientToRecipeAsync(
                    recipeId,
                    ing.IngredientId,
                    originalQuantity,
                    ing.OriginalUnit ?? "grams"
                );
            }

            await _recipeService.RecalculateRecipeNutritionAsync(recipeId);

            // LOG ACTIVITY - Recipe creation
            await _activityLogHelper.LogRecipeCreatedAsync(user.Id, recipeId, vm.Title);

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
                CurrentImageUrls = recipe.ImageUrls ?? new List<string>(),
                CurrentVideoUrl = recipe.VideoUrl,
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

            // CAPTURE OLD VALUES for activity logging
            var oldValues = new
            {
                recipe.Title,
                recipe.Info,
                recipe.PrepTime,
                recipe.Difficulty,
                recipe.Servings
            };

            // Update basic properties
            recipe.Title = vm.Title;
            recipe.Info = vm.Info;
            recipe.PrepTime = vm.PrepTime;
            recipe.Difficulty = vm.Difficulty;
            recipe.Servings = vm.Servings;

            // Handle image management
            var currentImages = recipe.ImageUrls ?? new List<string>();

            // Remove images marked for deletion
            if (vm.ImagesToRemove != null && vm.ImagesToRemove.Any())
            {
                foreach (var urlToRemove in vm.ImagesToRemove)
                {
                    await _fileUploadService.DeleteFileAsync(urlToRemove);
                    currentImages.Remove(urlToRemove);
                }
            }

            // Add new images
            if (vm.NewImageFiles != null && vm.NewImageFiles.Any())
            {
                // Validate all new images first
                foreach (var file in vm.NewImageFiles)
                {
                    if (!_fileUploadService.IsValidImage(file))
                    {
                        ModelState.AddModelError("NewImageFiles", $"Invalid image file: {file.FileName}. Allowed: JPG, PNG, WebP. Max size: 5MB");
                        var cats = await _categoryService.GetAllCategoriesAsync();
                        vm.AvailableCategories = cats.Select(c => new CategoryFilterViewModel { Id = c.Id, Name = c.Name });
                        return View(vm);
                    }
                }

                // Calculate how many more images we can add (max 5 total)
                int slotsAvailable = 5 - currentImages.Count;
                if (slotsAvailable > 0)
                {
                    var newImageUrls = await _fileUploadService.UploadMultipleImagesAsync(vm.NewImageFiles, "recipes", maxFiles: slotsAvailable);
                    currentImages.AddRange(newImageUrls);
                }
            }

            // Update recipe images
            recipe.ImageUrls = currentImages;

            // Update primary image (first in the list, or null if no images)
            recipe.PrimaryImageUrl = currentImages.Any() ? currentImages.First() : null;

            // Handle video removal or replacement
            if (vm.RemoveCurrentVideo)
            {
                if (!string.IsNullOrEmpty(recipe.VideoUrl))
                {
                    await _fileUploadService.DeleteFileAsync(recipe.VideoUrl);
                    recipe.VideoUrl = null;
                }
            }
            else if (vm.NewVideoFile != null)
            {
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

                recipe.VideoUrl = await _fileUploadService.UploadVideoAsync(vm.NewVideoFile);
            }

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

            // CAPTURE NEW VALUES and log activity
            var newValues = new
            {
                recipe.Title,
                recipe.Info,
                recipe.PrepTime,
                recipe.Difficulty,
                recipe.Servings
            };

            await _activityLogHelper.LogRecipeUpdatedAsync(
               user.Id,
               id,
               vm.Title,
               oldValues,
               newValues);


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
            if (!string.IsNullOrEmpty(recipe.PrimaryImageUrl))
            {
                await _fileUploadService.DeleteFileAsync(recipe.PrimaryImageUrl);
            }

            if (!string.IsNullOrEmpty(recipe.VideoUrl))
            {
                await _fileUploadService.DeleteFileAsync(recipe.VideoUrl);
            }

            // NOW soft delete the recipe
            await _recipeService.SoftDeleteRecipeAsync(id);

            // LOG ACTIVITY - Recipe deletion
            await _activityLogHelper.LogRecipeDeletedAsync(
                user.Id,
                id,
                recipe.Title,
                isSoftDelete: true);

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
            Services.Admin.Models.ContentFilterResult? filterResult = null;

            // CHECK FOR BANNED WORDS IF COMMENT PROVIDED
            if (!string.IsNullOrWhiteSpace(vm.Comment))
            {
                filterResult = await _contentFilterService.CheckContentAsync(vm.Comment);

                if (filterResult.ContainsBannedWords)
                {
                    // LOG BANNED WORD DETECTION
                    await _activityLogHelper.LogBannedWordDetectedAsync(
                        user!.Id,
                        "Comment",
                        Guid.Empty, // Entity ID not yet available
                        string.Join(", ", filterResult.MatchedWords));

                    if (filterResult.ShouldAutoBlock)
                    {
                        // Auto-block high severity words
                        TempData["Error"] = "Your comment contains prohibited content and cannot be posted.";
                        return RedirectToAction(nameof(Details), new { id = vm.RecipeId });
                    }

                    if (filterResult.ShouldFlagForReview)
                    {
                        // Flag for admin review but allow posting
                        var recipe = await _recipeService.GetRecipeByIdAsync(vm.RecipeId);

                        await _flaggedContentService.FlagContentAsync(
                            contentType: "Comment",
                            contentId: Guid.Empty, // Will be updated after comment creation
                            contentPreview: vm.Comment.Length > 200 ? vm.Comment.Substring(0, 200) : vm.Comment,
                            contentAuthorId: user.Id,
                            reason: FlagReason.BannedWords,
                            details: $"Auto-flagged by content filter. Severity: {filterResult.HighestSeverity}",
                            reportedByUserId: null,
                            matchedBannedWords: string.Join(", ", filterResult.MatchedWords));

                        TempData["Warning"] = "Your comment has been flagged for review.";
                    }
                }
            }

            await _commentRatingService.AddOrUpdateCommentRatingAsync(user!.Id, vm.RecipeId, vm.Rating, vm.Comment);

            // LOG COMMENT POSTED
            var recipeForLog = await _recipeService.GetRecipeByIdAsync(vm.RecipeId);
            await _activityLogHelper.LogCommentPostedAsync(
                user.Id,
                Guid.NewGuid(), // Should ideally be the actual comment ID
                vm.RecipeId,
                recipeForLog?.Title ?? "Unknown Recipe",
                filterResult?.ContainsBannedWords ?? false);

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
        public async Task<IActionResult> AddIngredient(Guid recipeId, Guid ingredientId, float quantity, string unit = "grams")
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

            if (recipe.UserId != userId && !User.IsInRole("Admin"))
            {
                return Json(new { success = false, message = "You can only edit your own recipes." });
            }

            try
            {
                await _recipeIngredientService.AddIngredientToRecipeAsync(recipeId, ingredientId, quantity, unit);
                await _recipeService.RecalculateRecipeNutritionAsync(recipeId);

                var ingredient = await _ingredientService.GetIngredientByIdAsync(ingredientId);

                // Get the converted quantity in grams for display purposes
                var quantityInGrams = _recipeIngredientService.ConvertToGrams(quantity, unit);
                var updatedRecipe = await _recipeService.GetRecipeByIdAsync(recipeId);

                return Json(new
                {
                    success = true,
                    ingredientId,
                    ingredientName = ingredient.Name,
                    quantity,
                    unit,
                    quantityInGrams,
                    formattedQuantity = _recipeIngredientService.FormatQuantity(quantity, unit),
                    calories = updatedRecipe.Calories,
                    protein = updatedRecipe.Protein,
                    carbs = updatedRecipe.Carbs,
                    fat = updatedRecipe.Fat
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

            if (recipe.UserId != userId && !User.IsInRole("Admin"))
            {
                return Json(new { success = false, message = "You can only edit your own recipes." });
            }

            try
            {
                await _recipeIngredientService.RemoveIngredientFromRecipeAsync(recipeId, ingredientId);
                await _recipeService.RecalculateRecipeNutritionAsync(recipeId);

                // Get the updated recipe with recalculated nutrition
                var updatedRecipe = await _recipeService.GetRecipeByIdAsync(recipeId);

                return Json(new
                {
                    success = true,
                    // Return updated nutrition values
                    calories = updatedRecipe.Calories,
                    protein = updatedRecipe.Protein,
                    carbs = updatedRecipe.Carbs,
                    fat = updatedRecipe.Fat
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: /Recipe/SearchIngredients?term=chicken
        // Used for autocomplete in Recipe Details, Create, Edit pages
        [HttpGet]
        public async Task<IActionResult> SearchIngredients([FromQuery] string term)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(term))
                    return Json(new List<object>());

                var user = await _userManager.GetUserAsync(User);

                // This method checks DB first, then API automatically - user sees combined results
                var ingredients = await _ingredientService.SearchIngredientsWithApiAsync(
                    term,
                    maxResults: 10,
                    userId: user?.Id
                );

                var results = ingredients.Select(i => new
                {
                    id = i.Id,
                    name = i.Name,
                    brand = i.Brand,
                    caloriesPer100g = i.CaloriesPer100g, // Match the JS expectation (line 626)
                    proteinPer100g = i.ProteinPer100g,
                    carbsPer100g = i.CarbsPer100g,
                    fatPer100g = i.FatPer100g
                }).ToList();

                return Json(results);
            }
            catch (Exception)
            {
                return Json(new List<object>());
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

            // CHECK FOR BANNED WORDS
            var filterResult = await _contentFilterService.CheckContentAsync(content);

            if (filterResult.ContainsBannedWords)
            {
                // LOG BANNED WORD DETECTION
                await _activityLogHelper.LogBannedWordDetectedAsync(
                    user!.Id,
                    "Reply",
                    Guid.Empty,
                    string.Join(", ", filterResult.MatchedWords));

                if (filterResult.ShouldAutoBlock)
                {
                    TempData["Error"] = "Your reply contains prohibited content and cannot be posted.";
                    return RedirectToAction(nameof(Details), new { id = recipeId });
                }

                if (filterResult.ShouldFlagForReview)
                {
                    var recipe = await _recipeService.GetRecipeByIdAsync(recipeId);

                    await _flaggedContentService.FlagContentAsync(
                        contentType: "Reply",
                        contentId: Guid.Empty,
                        contentPreview: content.Length > 200 ? content.Substring(0, 200) : content,
                        contentAuthorId: user.Id,
                        reason: FlagReason.BannedWords,
                        details: $"Auto-flagged by content filter. Severity: {filterResult.HighestSeverity}",
                        reportedByUserId: null,
                        matchedBannedWords: string.Join(", ", filterResult.MatchedWords));

                    TempData["Warning"] = "Your reply has been flagged for review.";
                }
            }

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

            // CHECK FOR BANNED WORDS
            var filterResult = await _contentFilterService.CheckContentAsync(content);

            if (filterResult.ContainsBannedWords)
            {
                // LOG BANNED WORD DETECTION
                await _activityLogHelper.LogBannedWordDetectedAsync(
                    user!.Id,
                    "Comment",
                    commentId,
                    string.Join(", ", filterResult.MatchedWords));

                if (filterResult.ShouldAutoBlock)
                {
                    TempData["Error"] = "Your comment contains prohibited content and cannot be updated.";
                    return RedirectToAction(nameof(Details), new { id = recipeId });
                }

                if (filterResult.ShouldFlagForReview)
                {
                    await _flaggedContentService.FlagContentAsync(
                        contentType: "Comment",
                        contentId: commentId,
                        contentPreview: content.Length > 200 ? content.Substring(0, 200) : content,
                        contentAuthorId: user.Id,
                        reason: FlagReason.BannedWords,
                        details: $"Auto-flagged during edit. Severity: {filterResult.HighestSeverity}",
                        reportedByUserId: null,
                        matchedBannedWords: string.Join(", ", filterResult.MatchedWords));

                    TempData["Warning"] = "Your updated comment has been flagged for review.";
                }
            }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConvertMeasurement([FromBody] ConversionRequest request)
        {
            try
            {
                var grams = _recipeIngredientService.ConvertToGrams(request.Quantity, request.FromUnit);

                var result = new
                {
                    grams = Math.Round(grams, 1),
                    teaspoons = Math.Round(_recipeIngredientService.ConvertFromGrams(grams, "teaspoons"), 1),
                    tablespoons = Math.Round(_recipeIngredientService.ConvertFromGrams(grams, "tablespoons"), 1),
                    cups = Math.Round(_recipeIngredientService.ConvertFromGrams(grams, "cups"), 2),
                    coffeeCups = Math.Round(_recipeIngredientService.ConvertFromGrams(grams, "coffeecups"), 2),
                    millilitres = Math.Round(_recipeIngredientService.ConvertFromGrams(grams, "millilitres"), 0)
                };

                return Json(result);
            }
            catch (Exception)
            {
                return BadRequest(new { error = "Conversion failed" });
            }
        }

        public class ConversionRequest
        {
            public float Quantity { get; set; }
            public string FromUnit { get; set; } = string.Empty;
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
