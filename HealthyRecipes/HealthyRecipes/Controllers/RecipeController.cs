using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Allergies;
using HealthyRecipes.Services.Categories;
using HealthyRecipes.Services.CommentRatings;
using HealthyRecipes.Services.Ingredients;
using HealthyRecipes.Services.RecipeCategories;
using HealthyRecipes.Services.RecipeIngredients;
using HealthyRecipes.Services.Recipes;
using HealthyRecipes.Services.SavedRecipes;
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
            _userManager = userManager;
        }

        // GET: /Recipe
        public async Task<IActionResult> Index(string? search, Guid? categoryId, int page = 1)
        {
            const int pageSize = 12;
            var allRecipes = await _recipeService.GetAllRecipesAsync();
            var categories = await _categoryService.GetAllCategoriesAsync();

            if (!string.IsNullOrWhiteSpace(search))
                allRecipes = allRecipes.Where(r => r.Info.Contains(search, StringComparison.OrdinalIgnoreCase));

            if (categoryId.HasValue)
            {
                var categoryRecipes = await _recipeCategoryService.GetRecipesByCategoryAsync(categoryId.Value);
                var categoryRecipeIds = categoryRecipes.Select(cr => cr.RecipeId).ToHashSet();
                allRecipes = allRecipes.Where(r => categoryRecipeIds.Contains(r.Id));
            }

            var recipeList = allRecipes.ToList();
            var totalPages = (int)Math.Ceiling(recipeList.Count / (double)pageSize);
            var paged = recipeList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            Guid? currentUserId = null;
            HashSet<Guid> savedIds = new();
            HashSet<Guid> allergyIngredientIds = new();

            if (User.Identity?.IsAuthenticated == true)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    currentUserId = user.Id;
                    var saved = await _savedRecipeService.GetSavedRecipesByUserAsync(user.Id);
                    savedIds = saved.Select(sr => sr.RecipeId).ToHashSet();
                    var allergies = await _allergyService.GetAllergiesByUserAsync(user.Id);
                    allergyIngredientIds = allergies.Select(a => a.IngredientId).ToHashSet();
                }
            }

            var cards = new List<RecipeCardViewModel>();
            foreach (var recipe in paged)
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

            var vm = new RecipeIndexViewModel
            {
                Recipes = cards,
                SearchQuery = search,
                SelectedCategoryId = categoryId,
                CurrentPage = page,
                TotalPages = totalPages,
                Categories = categories.Select(c => new CategoryFilterViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
            };

            return View(vm);
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
                ConflictingIngredients = conflictingIngredients
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
