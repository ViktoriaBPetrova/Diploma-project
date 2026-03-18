using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Allergies;
using HealthyRecipes.Services.Categories;
using HealthyRecipes.Services.CommentRatings;
using HealthyRecipes.Services.Ingredients;
using HealthyRecipes.Services.MealPlanFollowers;
using HealthyRecipes.Services.MealPlans;
using HealthyRecipes.Services.RecipeCategories;
using HealthyRecipes.Services.RecipeIngredients;
using HealthyRecipes.Services.Recipes;
using HealthyRecipes.Services.Recipes.Models;
using HealthyRecipes.Services.SavedRecipes;
using HealthyRecipes.Services.Statistics.Interfaces;
using HealthyRecipes.Services.Statistics.Services;
using HealthyRecipes.Services.Users;
using HealthyRecipes.Web.ViewModels.MealPlan;
using HealthyRecipes.Web.ViewModels.Recipe;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            _userManager = userManager;
        }

        // GET: /Recipe
        public async Task<IActionResult> Index([FromQuery] RecipeFilterViewModel filter)
        {
            try
            {
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
                if (User.Identity?.IsAuthenticated == true)
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        var my = await _recipeService.GetRecipesByUserAsync(user.Id);
                        myRecipes = my.ToList();

                        var saved = await _savedRecipeService.GetSavedRecipesByUserAsync(user.Id);
                        savedIds = saved.Select(sr => sr.RecipeId).ToHashSet();

                        var allergies = await _allergyService.GetAllergiesByUserAsync(user.Id);
                        allergyIngredientIds = allergies.Select(a => a.IngredientId).ToHashSet();
                    }
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
            var comments = await _commentRatingService.GetRatingsByRecipeAsync(id);
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
                            Rating = existing.Rating,
                            Comment = existing.Comment
                        };
                    }
                }
            }

            var ingredientVms = recipeIngredients.Select(ri => new RecipeIngredientViewModel
            {
                IngredientName = ri.Ingredient?.Name ?? "Unknown",
                QuantityInGrams = ri.QuantityInGrams,
                IngredientCaloriesPer100g = ri.Ingredient?.CaloriesPer100g ?? 0,
                IsAllergen = ri.Ingredient != null && allergyIngredientIds.Contains(ri.IngredientId)
            }).ToList();

            var conflictingIngredients = ingredientVms.Where(i => i.IsAllergen).Select(i => i.IngredientName).ToList();

            //var stats = await _recipeStatisticsService.GetRecipeStatisticsAsync(id);

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
                Comments = comments.Select(c => new CommentViewModel
                {
                    UserName = c.User?.UserName ?? "Unknown",
                    UserImageUrl = c.User?.ImageUrl,
                    Rating = c.Rating,
                    Comment = c.Comment,
                    CreatedAt = c.CreatedAt,
                    IsCurrentUser = c.UserId == currentUserId
                }),
                CurrentUserComment = currentUserComment,
                HasAllergyConflict = conflictingIngredients.Any(),
                ConflictingIngredients = conflictingIngredients,

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

            var user = await _userManager.GetUserAsync(User);
            var recipe = new Data.Entities.Recipe
            {
                Title = vm.Title,
                Info = vm.Info,
                PrepTime = vm.PrepTime,
                Difficulty = vm.Difficulty,
                Servings = vm.Servings,
                ImageUrl = vm.ImageUrl,
                VideoUrl = vm.VideoUrl,
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
                ImageUrl = recipe.ImageUrl,
                VideoUrl = recipe.VideoUrl,
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

            recipe.Title = vm.Title;
            recipe.Info = vm.Info;
            recipe.PrepTime = vm.PrepTime;
            recipe.Difficulty = vm.Difficulty;
            recipe.Servings = vm.Servings;
            recipe.ImageUrl = vm.ImageUrl;
            recipe.VideoUrl = vm.VideoUrl;

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

            await _recipeService.SoftDeleteRecipeAsync(id);
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
    }
}
