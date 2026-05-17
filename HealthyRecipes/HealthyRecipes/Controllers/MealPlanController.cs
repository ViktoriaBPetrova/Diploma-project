using Azure.Core;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Enums;
using HealthyRecipes.Services.Admin;
using HealthyRecipes.Services.Admin.Helpers;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Services.Allergies;
using HealthyRecipes.Services.Categories;
using HealthyRecipes.Services.CommentRatings;
using HealthyRecipes.Services.GroceryLists;
using HealthyRecipes.Services.IngredientMeals;
using HealthyRecipes.Services.Ingredients;
using HealthyRecipes.Services.MealPlanDays;
using HealthyRecipes.Services.MealPlanFollowers;
using HealthyRecipes.Services.MealPlans;
using HealthyRecipes.Services.MealPlans.Models;
using HealthyRecipes.Services.Meals;
using HealthyRecipes.Services.RecipeIngredients;
using HealthyRecipes.Services.RecipeMeals;
using HealthyRecipes.Services.Recipes;
using HealthyRecipes.Services.SavedMealPlans;
using HealthyRecipes.Services.SavedRecipes;
using HealthyRecipes.Web.Models.MealPlan;
using HealthyRecipes.Web.ViewModels.MealPlan;
using HealthyRecipes.Web.ViewModels.Recipe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthyRecipes.Web.Controllers
{
    
    public class MealPlanController : Controller
    {
        private readonly IMealPlan _mealPlanService;
        private readonly IMealPlanDay _mealPlanDayService;
        private readonly IMeal _mealService;
        private readonly IRecipeMeal _recipeMealService;
        private readonly ICategory _categoryService;
        private readonly ISavedMealPlan _savedMealPlanService;
        private readonly IMealPlanFollower _mealPlanFollowerService;
        private readonly IGroceryList _groceryListService;
        private readonly IActivityLog _activityLogService;
        private readonly IContentFilter _contentFilterService;
        private readonly IFlaggedContent _flaggedContentService;
        private readonly IRecipe _recipeService;
        private readonly IIngredient _ingredientService;
        private readonly IAllergy _allergyService;
        private readonly ISavedIngredients _savedRecipeService;
        private readonly ActivityLogHelper _activityLogHelper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIngredientMeal _ingredientMealService;

        public MealPlanController(
            IMealPlan mealPlanService,
            ICategory categoryService,
            IMealPlanDay mealPlanDayService,
            IMeal mealService,
            IRecipeMeal recipeMealService,
            IIngredientMeal ingredientMealService,
            ISavedMealPlan savedMealPlanService,
            IMealPlanFollower mealPlanFollowerService,
            UserManager<ApplicationUser> userManager,
            IGroceryList groceryListService,
            IActivityLog activityLogService,
            IContentFilter contentFilterService,
            IFlaggedContent flaggedContentService,
            IRecipe recipeService,
            IAllergy allergyService,
            IIngredient ingredientService,
            ISavedIngredients savedRecipeService,
            ActivityLogHelper activityLogHelper)
        {
            _mealPlanService = mealPlanService;
            _mealPlanDayService = mealPlanDayService;
            _mealService = mealService;
            _recipeMealService = recipeMealService;
            _ingredientMealService = ingredientMealService;
            _categoryService = categoryService;
            _savedMealPlanService = savedMealPlanService;
            _mealPlanFollowerService = mealPlanFollowerService;
            _userManager = userManager;
            _groceryListService = groceryListService;
            _activityLogService = activityLogService;
            _contentFilterService = contentFilterService;
            _flaggedContentService = flaggedContentService;
            _activityLogHelper = activityLogHelper;
            _recipeService = recipeService;
            _ingredientService = ingredientService;
            _allergyService = allergyService;
            _savedRecipeService = savedRecipeService;

        }

        // GET: /MealPlan

        public async Task<IActionResult> Index([FromQuery] MealPlanFilterViewModel filter, [FromQuery] string? view)
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
                var filterDto = new MealPlanFilterDto
                {
                    SearchTerm = filter.SearchTerm,
                    MinCaloriesPerDay = filter.MinCaloriesPerDay,
                    MaxCaloriesPerDay = filter.MaxCaloriesPerDay,
                    MinProteinPerDay = filter.MinProteinPerDay,
                    MaxProteinPerDay = filter.MaxProteinPerDay,
                    MinCarbsPerDay = filter.MinCarbsPerDay,
                    MaxCarbsPerDay = filter.MaxCarbsPerDay,
                    MinFatPerDay = filter.MinFatPerDay,
                    MaxFatPerDay = filter.MaxFatPerDay,
                    MinDays = filter.MinDays,
                    MaxDays = filter.MaxDays,
                    MaxPreparationTimePerDay = filter.MaxPreparationTimePerDay,
                    CategoryIds = filter.CategoryIds,
                    PageNumber = filter.PageNumber,
                    PageSize = filter.PageSize,
                    SortBy = filter.SortBy,
                    SortOrder = filter.SortOrder
                };

                // Get all categories for filter UI
                var categories = await _categoryService.GetAllCategoriesAsync();

                HashSet<Guid> savedIds = new();
                List<MealPlan> myPlans = new List<MealPlan>();

                if (currentUserId != null)
                {
                    // Get user's own meal plans
                    var my = await _mealPlanService.GetMealPlansByUserAsync((Guid)currentUserId);
                    myPlans = my.ToList();
                    // Get saved meal plans
                    var saved = await _savedMealPlanService.GetSavedMealPlansByUserAsync((Guid)currentUserId);
                    savedIds = saved.Select(s => s.MealPlanId).ToHashSet();
                }

                List<MealPlanCardViewModel>? browseCards = null;
                List<MealPlanCardViewModel>? myPlanCards = null;
                int count = 0;

                if (view == "mine" && currentUserId != null)
                {
                    // Get filtered mealplans from service
                    var (filtered, totalCount) = await _mealPlanService.GetFilteredMealPlansAsync(filterDto, myPlans);
                    count = totalCount;

                    myPlanCards = new List<MealPlanCardViewModel>();
                    // Map My Plans 
                    foreach (var mp in filtered)
                    {
                        var followerCount = await _mealPlanFollowerService.GetFollowerCountAsync(mp.Id);

                        myPlanCards.Add(new MealPlanCardViewModel
                        {
                            Id = mp.Id,
                            Name = mp.Name,
                            Description = mp.Description,
                            Calories = mp.Calories,
                            Protein = mp.Protein,
                            Carbs = mp.Carbs,
                            Fat = mp.Fat,
                            DayCount = mp.MealPlanDays?.Count() ?? 0,
                            IsSaved = savedIds.Contains(mp.Id),
                            AuthorId = mp.UserId,
                            CreatedAt = mp.CreatedAt,
                            FollowerCount = followerCount,
                            CategoryNames = mp.MealPlanCategories?
                                .Where(mpc => !mpc.Deleted && mpc.Category != null && !mpc.Category.Deleted)
                                .Select(mpc => mpc.Category.Name) ?? Enumerable.Empty<string>()
                        });
                    }
                }
                else
                {
                    var allMealPlans = await _mealPlanService.GetAllMealPlansAsync();

                    // Exclude user's own melplans from browse results
                    if (currentUserId != null)
                    {
                        allMealPlans = allMealPlans.Where(mp => mp.UserId != currentUserId).ToList();
                    }

                    // Get filtered mealplans from service
                    var (filtered, totalCount) = await _mealPlanService.GetFilteredMealPlansAsync(filterDto, allMealPlans);
                    count = totalCount;

                    // Map Browse All 
                    browseCards = new List<MealPlanCardViewModel>();
                    foreach (var mp in filtered)
                    {
                        var followerCount = await _mealPlanFollowerService.GetFollowerCountAsync(mp.Id);

                        browseCards.Add(new MealPlanCardViewModel
                        {
                            Id = mp.Id,
                            Name = mp.Name,
                            Description = mp.Description,
                            Calories = mp.Calories,
                            Protein = mp.Protein,
                            Carbs = mp.Carbs,
                            Fat = mp.Fat,
                            DayCount = mp.MealPlanDays?.Count() ?? 0,
                            IsSaved = savedIds.Contains(mp.Id),
                            AuthorId = mp.UserId,
                            CreatedAt = mp.CreatedAt,
                            FollowerCount = followerCount,
                            CategoryNames = mp.MealPlanCategories?
                                .Where(mpc => !mpc.Deleted && mpc.Category != null && !mpc.Category.Deleted)
                                .Select(mpc => mpc.Category.Name) ?? Enumerable.Empty<string>()
                        });
                    }
                }

                var vm = new MealPlanIndexViewModel
                {
                    MyMealPlans = myPlanCards,
                    BrowseAllMealPlans = browseCards,
                    Categories = categories.Select(c => new MealPlanCategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList(),
                    Filter = filter,
                    TotalCount = count,
                    PageNumber = filter.PageNumber,
                    PageSize = filter.PageSize,
                    TotalPages = (int)Math.Ceiling((double)count / filter.PageSize),
                    ViewMode = view
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while loading meal plans.";

                return View(new MealPlanIndexViewModel
                {
                    Filter = filter ?? new MealPlanFilterViewModel(),
                    Categories = new List<MealPlanCategoryViewModel>()
                });
            }
        }

        // GET: /MealPlan/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var mealPlan = await _mealPlanService.GetByIdAsync(id);
            if (mealPlan == null) return NotFound();
            var isSaved = false;
            var isFollowing = false;
            Guid? currentUserId = null;
            HashSet<Guid> allergyIngredientIds = new();

            if (User.Identity?.IsAuthenticated == true)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    currentUserId = user.Id;
                    isSaved = await _savedMealPlanService.IsMealPlanSavedAsync(user!.Id, id);
                    isFollowing = await _mealPlanFollowerService.IsFollowingAsync(user.Id, id);

                    var allergies = await _allergyService.GetAllergiesByUserAsync(user.Id);
                    allergyIngredientIds = allergies.Select(a => a.IngredientId).ToHashSet();

                }
            }

            var days = await _mealPlanDayService.GetDaysByMealPlanAsync(id);
            var dayVms = new List<MealPlanDayViewModel>();

            foreach (var day in days.OrderBy(d => d.DayNumber))
            {
                var meals = await _mealService.GetMealsByDayAsync(day.Id);
                var mealVms = new List<MealViewModel>();
                foreach (var meal in meals)
                {
                    var recipeMeals = await _recipeMealService.GetRecipesByMealAsync(meal.Id);
                    var ingredientMeals = await _ingredientMealService.GetIngredientsByMealAsync(meal.Id);
                    mealVms.Add(new MealViewModel
                    {
                        Id = meal.Id,
                        Type = meal.Type,
                        Calories = meal.Calories,
                        Protein = meal.Protein,
                        Carbs = meal.Carbs,
                        Fat = meal.Fat,
                        Recipes = recipeMeals.Select(rm => new MealRecipeViewModel
                        {
                            RecipeId = rm.RecipeId,
                            Name = rm.Recipe?.Title ?? "",
                            Info = rm.Recipe?.Info ?? "",
                            ImageUrl = rm.Recipe?.PrimaryImageUrl,
                            Calories = rm.Recipe?.Calories ?? 0,
                            Protein = rm.Recipe?.Protein ?? 0,
                            Carbs = rm.Recipe?.Carbs ?? 0,
                            Fat = rm.Recipe?.Fat ?? 0
                        }),
                        Ingredients = ingredientMeals.Select(im => new IngredientMealViewModel
                        {
                            IngredientId = im.IngredientId,
                            IngredientName = im.Ingredient?.Name ?? "Unknown",
                            QuantityInGrams = im.QuantityInGrams,
                            CaloriesPer100g = im.Ingredient?.CaloriesPer100g ?? 0,
                            ProteinPer100g = im.Ingredient?.ProteinPer100g ?? 0,
                            CarbsPer100g = im.Ingredient?.CarbsPer100g ?? 0,
                            FatPer100g = im.Ingredient?.FatPer100g ?? 0,
                            IsAllergen = im.Ingredient != null && allergyIngredientIds.Contains(im.IngredientId),
                            // Add measurement properties
                            OriginalUnit = im.OriginalUnit,
                            QuantityInTeaspoons = im.QuantityInTeaspoons,
                            QuantityInTablespoons = im.QuantityInTablespoons,
                            QuantityInCups = im.QuantityInCups,
                            QuantityInCoffeeCups = im.QuantityInCoffeeCups,
                            QuantityInMillilitres = im.QuantityInMillilitres
                        })
                    });
                }

                dayVms.Add(new MealPlanDayViewModel
                {
                    Id = day.Id,
                    DayNumber = day.DayNumber,
                    DayOfWeek = (Data.Enums.DayOfWeek)day.DayOfWeek,
                    Calories = day.Calories,
                    Protein = day.Protein,
                    Carbs = day.Carbs,
                    Fat = day.Fat,
                    Meals = mealVms
                });
            }

            var activeFollowerCount = await _mealPlanFollowerService.GetActiveFollowerCountAsync(id);
            var completedFollowerCount = await _mealPlanFollowerService.GetCompletionCountAsync(id);
            var completedShowcase = await _mealPlanFollowerService.GetCompletedShowcaseAsync(id);

            var vm = new MealPlanDetailsViewModel
            {
                Id = mealPlan.Id,
                Name = mealPlan.Name,
                Description = mealPlan.Description,
                Calories = mealPlan.Calories,
                Protein = mealPlan.Protein,
                Carbs = mealPlan.Carbs,
                Fat = mealPlan.Fat,
                IsSaved = isSaved,
                IsOwner = mealPlan.UserId == currentUserId,
                IsFollowing = isFollowing,
                Days = dayVms,

                // NEW: Follower statistics
                ActiveFollowerCount = activeFollowerCount,
                CompletedFollowerCount = completedFollowerCount,
                CompletedShowcase = completedShowcase.Select(f => new CompletedUserViewModel
                {
                    UserId = f.UserId,
                    UserName = f.User?.UserName ?? "Unknown",
                    CompletedAt = f.CompletedAt ?? DateTime.UtcNow,
                    HasPublicJournal = f.ShareJournalPublicly
                })
            };

            return View(vm);
        }

        // GET: /MealPlan/Create
        public IActionResult Create() => View(new CreateMealPlanViewModel());

        // POST: /MealPlan/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMealPlanViewModel vm)
        {
            // DEBUGGING: Log all ModelState errors
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new
                    {
                        Field = x.Key,
                        Errors = x.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    })
                    .ToList();

                // Log to console (you'll see this in Visual Studio output window)
                foreach (var error in errors)
                {
                    Console.WriteLine($"Field: {error.Field}");
                    foreach (var msg in error.Errors)
                    {
                        Console.WriteLine($"  Error: {msg}");
                    }
                }

                // Also show in TempData so you can see in the browser
                TempData["DebugErrors"] = string.Join("\n", errors.Select(e =>
                    $"{e.Field}: {string.Join(", ", e.Errors)}"));

                return View(vm);
            }

            var user = await _userManager.GetUserAsync(User);

            // CHECK FOR BANNED WORDS in Name and Description
            var nameFilterResult = await _contentFilterService.CheckContentAsync(vm.Name);
            var descriptionFilterResult = string.IsNullOrWhiteSpace(vm.Description)
                ? null
                : await _contentFilterService.CheckContentAsync(vm.Description);

            // Handle banned words in Name
            if (nameFilterResult.ContainsBannedWords)
            {
                await _activityLogHelper.LogBannedWordDetectedAsync(
                    user!.Id,
                    "MealPlan",
                    Guid.Empty,
                    string.Join(", ", nameFilterResult.MatchedWords));

                if (nameFilterResult.ShouldAutoBlock)
                {
                    TempData["Error"] = "The meal plan name contains prohibited content and cannot be created.";
                    return View(vm);
                }

                if (nameFilterResult.ShouldFlagForReview)
                {
                    TempData["Warning"] = "Your meal plan has been flagged for review.";
                }
            }

            // Handle banned words in Description
            if (descriptionFilterResult?.ContainsBannedWords == true)
            {
                await _activityLogHelper.LogBannedWordDetectedAsync(
                    user!.Id,
                    "MealPlan",
                    Guid.Empty,
                    string.Join(", ", descriptionFilterResult.MatchedWords));

                if (descriptionFilterResult.ShouldAutoBlock)
                {
                    TempData["Error"] = "The description contains prohibited content and cannot be created.";
                    return View(vm);
                }

                if (descriptionFilterResult.ShouldFlagForReview && !nameFilterResult.ShouldFlagForReview)
                {
                    TempData["Warning"] = "Your meal plan has been flagged for review.";
                }
            }

            // Create meal plan
            var mealPlan = new MealPlan
            {
                Name = vm.Name,
                Description = vm.Description,
                UserId = user!.Id
            };

            var mealPlanId = await _mealPlanService.CreateMealPlanAsync(mealPlan);

            // Create days, meals, and recipes
            if (vm.Days != null && vm.Days.Any())
            {
                foreach (var dayVm in vm.Days)
                {
                    var day = new MealPlanDay
                    {
                        MealPlanId = mealPlanId,
                        DayNumber = dayVm.DayNumber,
                        DayOfWeek = (Data.Enums.DayOfWeek)dayVm.DayOfWeek
                    };

                    var dayId = await _mealPlanDayService.CreateMealPlanDayAsync(day);

                    if (dayVm.Meals != null && dayVm.Meals.Any())
                    {
                        foreach (var mealVm in dayVm.Meals)
                        {
                            var meal = new Meal
                            {
                                MealPlanDayId = dayId,
                                Type = (MealType)mealVm.Type
                            };

                            var mealId = await _mealService.CreateMealAsync(meal);

                            if (mealVm.RecipeIds != null && mealVm.RecipeIds.Any())
                            {
                                foreach (var recipeId in mealVm.RecipeIds)
                                {
                                    await _recipeMealService.AddRecipeToMealAsync(recipeId, mealId);
                                }

                                // Recalculate meal nutrition after adding recipes
                                await _mealService.RecalculateNutritionAsync(mealId);
                            }

                            if (mealVm.Ingredients != null && mealVm.Ingredients.Any())
                            {
                                foreach (var ingredient in mealVm.Ingredients)
                                {
                                    await _ingredientMealService.AddIngredientToMealAsync(ingredient.IngredientId, mealId, ingredient.OriginalQuantity, ingredient.OriginalUnit);
                                }

                                // Recalculate meal nutrition after adding recipes
                                await _mealService.RecalculateNutritionAsync(mealId);
                            }
                        }

                        // Recalculate day nutrition after adding all meals
                        await _mealPlanDayService.RecalculateNutritionAsync(dayId);
                    }
                }

                // Recalculate meal plan nutrition after adding all days
                await _mealPlanService.RecalculateNutritionalTotalsAsync(mealPlanId);
            }

            // Flag content if necessary
            if (nameFilterResult.ShouldFlagForReview || descriptionFilterResult?.ShouldFlagForReview == true)
            {
                var allMatchedWords = nameFilterResult.MatchedWords
                    .Concat(descriptionFilterResult?.MatchedWords ?? Enumerable.Empty<string>())
                    .Distinct();

                await _flaggedContentService.FlagContentAsync(
                    contentType: "MealPlan",
                    contentId: mealPlanId,
                    contentPreview: $"{vm.Name} - {vm.Description?.Substring(0, Math.Min(100, vm.Description.Length))}",
                    contentAuthorId: user.Id,
                    reason: FlagReason.BannedWords,
                    details: $"Auto-flagged by content filter during creation",
                    reportedByUserId: null,
                    matchedBannedWords: string.Join(", ", allMatchedWords));
            }

            // LOG ACTIVITY
            await _activityLogHelper.LogMealPlanCreatedAsync(user.Id, mealPlanId, vm.Name);

            return RedirectToAction(nameof(Details), new { id = mealPlanId });
        }

        // GET: /MealPlan/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var mealPlan = await _mealPlanService.GetByIdAsync(id);
            if (mealPlan == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (mealPlan.UserId != user!.Id && !User.IsInRole("Admin"))
                return Forbid();

            return View(new EditMealPlanViewModel { Id = id, Name = mealPlan.Name, Description = mealPlan.Description });
        }

        // POST: /MealPlan/Edit/{id}
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditMealPlanViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var mealPlan = await _mealPlanService.GetByIdAsync(id);
            if (mealPlan == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (mealPlan.UserId != user!.Id && !User.IsInRole("Admin"))
                return Forbid();

            // CAPTURE OLD VALUES
            var oldValues = new
            {
                mealPlan.Name,
                mealPlan.Description
            };

            // CHECK FOR BANNED WORDS
            var nameFilterResult = await _contentFilterService.CheckContentAsync(vm.Name);
            var descriptionFilterResult = string.IsNullOrWhiteSpace(vm.Description)
                ? null
                : await _contentFilterService.CheckContentAsync(vm.Description);

            // Handle banned words in Name
            if (nameFilterResult.ContainsBannedWords)
            {
                await _activityLogHelper.LogBannedWordDetectedAsync(
                    user!.Id,
                    "MealPlan",
                    id,
                    string.Join(", ", nameFilterResult.MatchedWords));

                if (nameFilterResult.ShouldAutoBlock)
                {
                    TempData["Error"] = "The meal plan name contains prohibited content and cannot be updated.";
                    return View(vm);
                }

                if (nameFilterResult.ShouldFlagForReview)
                {
                    TempData["Warning"] = "Your meal plan has been flagged for review.";
                }
            }

            // Handle banned words in Description
            if (descriptionFilterResult?.ContainsBannedWords == true)
            {
                await _activityLogHelper.LogBannedWordDetectedAsync(
                    user!.Id,
                    "MealPlan",
                    id,
                    string.Join(", ", descriptionFilterResult.MatchedWords));

                if (descriptionFilterResult.ShouldAutoBlock)
                {
                    TempData["Error"] = "The description contains prohibited content and cannot be updated.";
                    return View(vm);
                }

                if (descriptionFilterResult.ShouldFlagForReview && !nameFilterResult.ShouldFlagForReview)
                {
                    TempData["Warning"] = "Your meal plan has been flagged for review.";
                }
            }

            // Update meal plan
            mealPlan.Name = vm.Name;
            mealPlan.Description = vm.Description;
            await _mealPlanService.UpdateMealPlanAsync(mealPlan);

            // Flag content if necessary
            if (nameFilterResult.ShouldFlagForReview || descriptionFilterResult?.ShouldFlagForReview == true)
            {
                var allMatchedWords = nameFilterResult.MatchedWords
                    .Concat(descriptionFilterResult?.MatchedWords ?? Enumerable.Empty<string>())
                    .Distinct();

                await _flaggedContentService.FlagContentAsync(
                    contentType: "MealPlan",
                    contentId: id,
                    contentPreview: $"{vm.Name} - {vm.Description?.Substring(0, Math.Min(100, vm.Description.Length))}",
                    contentAuthorId: user.Id,
                    reason: FlagReason.BannedWords,
                    details: $"Auto-flagged by content filter during update",
                    reportedByUserId: null,
                    matchedBannedWords: string.Join(", ", allMatchedWords));
            }

            // CAPTURE NEW VALUES and LOG
            var newValues = new
            {
                mealPlan.Name,
                mealPlan.Description
            };

            // Build change description
            var changes = new List<string>();
            if (oldValues.Name != newValues.Name)
                changes.Add($"Name: '{oldValues.Name}' → '{newValues.Name}'");
            if (oldValues.Description != newValues.Description)
                changes.Add("Description updated");

            await _activityLogHelper.LogMealPlanUpdatedAsync(
                user.Id,
                id,
                vm.Name,
                string.Join(", ", changes));

            return RedirectToAction(nameof(Details), new { id });
        }

        // POST: /MealPlan/Delete/{id}
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var mealPlan = await _mealPlanService.GetByIdAsync(id);
            if (mealPlan == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (mealPlan.UserId != user!.Id && !User.IsInRole("Admin"))
                return Forbid();

            await _mealPlanService.SoftDeleteAsync(id);

            // LOG ACTIVITY
            await _activityLogHelper.LogMealPlanDeletedAsync(
                user.Id,
                id,
                mealPlan.Name);

            TempData["Success"] = "Meal plan deleted successfully";
            return RedirectToAction(nameof(Index));
        }
        

        // POST: /MealPlan/ToggleSave/{id}
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleSave(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            bool isSaved = await _savedMealPlanService.IsMealPlanSavedAsync(user!.Id, id);
            if (isSaved)
                await _savedMealPlanService.UnsaveMealPlanAsync(user.Id, id);
            else
                await _savedMealPlanService.SaveMealPlanAsync(user.Id, id);

            return RedirectToAction(nameof(Details), new { id });
        }


        // POST: /MealPlan/DeleteDay/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDay(Guid id)
        {
            var day = await _mealPlanDayService.GetMealPlanDayByIdAsync(id);
            if (day == null) return NotFound();

            var mealPlan = await _mealPlanService.GetByIdAsync(day.MealPlanId);
            var user = await _userManager.GetUserAsync(User);

            if (mealPlan.UserId != user!.Id && !User.IsInRole("Admin"))
                return Forbid();

            await _mealPlanDayService.SoftDeleteMealPlanDayAsync(id);

            // Recalculate meal plan totals
            await _mealPlanService.RecalculateNutritionalTotalsAsync(mealPlan.Id);

            return Ok();
        }

        // POST: /MealPlan/RemoveRecipeFromMeal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveRecipeFromMeal([FromBody] RemoveRecipeRequest request)
        {
            var meal = await _mealService.GetMealByIdAsync(request.MealId);
            if (meal == null) return NotFound();

            var day = await _mealPlanDayService.GetMealPlanDayByIdAsync(meal.MealPlanDayId);
            var mealPlan = await _mealPlanService.GetByIdAsync(day.MealPlanId);
            var user = await _userManager.GetUserAsync(User);

            if (mealPlan.UserId != user!.Id && !User.IsInRole("Admin"))
                return Forbid();

            await _recipeMealService.RemoveRecipeFromMealAsync(request.RecipeId, request.MealId);

            // Recalculate meal macros
            await _mealService.RecalculateNutritionAsync(request.MealId);

            // Recalculate day macros
            await _mealPlanDayService.RecalculateNutritionAsync(day.Id);

            // Recalculate meal plan macros
            await _mealPlanService.RecalculateNutritionalTotalsAsync(mealPlan.Id);

            return Ok();
        }

        // POST: /MealPlan/AddRecipeToMeal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRecipeToMeal([FromBody] AddRecipeRequest request)
        {
            var meal = await _mealService.GetMealByIdAsync(request.MealId);
            if (meal == null) return NotFound();

            var day = await _mealPlanDayService.GetMealPlanDayByIdAsync(meal.MealPlanDayId);
            var mealPlan = await _mealPlanService.GetByIdAsync(day.MealPlanId);
            var user = await _userManager.GetUserAsync(User);

            if (mealPlan.UserId != user!.Id && !User.IsInRole("Admin"))
                return Forbid();

            await _recipeMealService.AddRecipeToMealAsync(request.RecipeId, request.MealId);

            // Recalculate meal macros
            await _mealService.RecalculateNutritionAsync(request.MealId);

            // Recalculate day macros
            await _mealPlanDayService.RecalculateNutritionAsync(day.Id);

            // Recalculate meal plan macros
            await _mealPlanService.RecalculateNutritionalTotalsAsync(mealPlan.Id);

            return Ok();
        }

        // GET: /MealPlan/SearchRecipes?query=chicken&filter=mine
        [HttpGet]
        public async Task<IActionResult> SearchRecipes([FromQuery] string query, [FromQuery] string filter = "all")
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var recipes = await _recipeService.GetAllRecipesAsync();

            switch (filter?.ToLower())
            {
                case "mine":
                    // Get only user's own recipes
                    recipes = await _recipeService.GetRecipesByUserAsync(user.Id);
                    break;

                case "saved":
                    // Get only saved recipes
                    var savedRecipes = await _savedRecipeService.GetSavedRecipesByUserAsync(user.Id);
                    recipes = savedRecipes.Select(sr => sr.Recipe).Where(r => r != null)!;
                    break;

                default: // "all"
                         // Get all recipes
                    recipes = await _recipeService.SearchRecipesAsync(query ?? "");
                    break;
            }

            // Apply search filter if query provided
            if (!string.IsNullOrWhiteSpace(query) && filter?.ToLower() != "all")
            {
                var searchLower = query.ToLower();
                recipes = recipes.Where(r => r.Info.ToLower().Contains(searchLower));
            }

            var results = recipes
                .Take(10)
                .Select(r => new
                {
                    id = r.Id,
                    name = r.Title,
                    calories = Math.Round(r.Calories, 0),
                    protein = Math.Round(r.Protein, 1),
                    carbs = Math.Round(r.Carbs, 1),
                    fat = Math.Round(r.Fat, 1)
                });

            return Ok(results);
        }

        public class RemoveRecipeRequest
        {
            public Guid MealId { get; set; }
            public Guid RecipeId { get; set; }
        }

        public class AddRecipeRequest
        {
            public Guid MealId { get; set; }
            public Guid RecipeId { get; set; }
        }

        // POST: /MealPlan/RemoveIngredientFromMeal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveIngredientFromMeal(Guid mealId, Guid ingredientId)
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return Json(new { success = false, message = "You must be logged in." });
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var meal = await _mealService.GetMealByIdAsync(mealId);

            if (meal == null)
            {
                return Json(new { success = false, message = "Meal not found." });
            }

            if (meal.MealPlanDay.MealPlan.UserId != userId && !User.IsInRole("Admin"))
            {
                return Json(new { success = false, message = "You can only edit your own mealplans." });
            }

            try
            {
                await _ingredientMealService.RemoveIngredientFromMealAsync(ingredientId, mealId);
                // Recalculate meal macros
                await _mealService.RecalculateNutritionAsync(mealId);

                // Recalculate day macros
                await _mealPlanDayService.RecalculateNutritionAsync(meal.MealPlanDay.Id);

                // Recalculate meal plan macros
                await _mealPlanService.RecalculateNutritionalTotalsAsync(meal.MealPlanDay.MealPlan.Id);

                // Get the updated recipe with recalculated nutrition
                var updatedMeal = await _mealService.GetMealByIdAsync(mealId);

                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // POST: /MealPlan/AddingredientToMeal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddIngredientToMeal(Guid mealId, Guid ingredientId, float quantity, string unit = "grams")
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return Json(new { success = false, message = "You must be logged in." });
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var meal = await _mealService.GetMealByIdAsync(mealId);

            if (meal == null)
            {
                return Json(new { success = false, message = "Meal not found." });
            }

            if (meal.MealPlanDay.MealPlan.UserId != userId && !User.IsInRole("Admin"))
            {
                return Json(new { success = false, message = "You can only edit your own mealplans." });
            }

            try
            {
                await _ingredientMealService.AddIngredientToMealAsync(ingredientId, mealId, quantity, unit);
                // Recalculate meal macros
                await _mealService.RecalculateNutritionAsync(mealId);

                // Recalculate day macros
                await _mealPlanDayService.RecalculateNutritionAsync(meal.MealPlanDay.Id);

                // Recalculate meal plan macros
                await _mealPlanService.RecalculateNutritionalTotalsAsync(meal.MealPlanDay.MealPlan.Id);

                var ingredient = await _ingredientService.GetIngredientByIdAsync(ingredientId);
                var ingredientMeal = meal.IngredientMeals.FirstOrDefault(im => im.Ingredient.Id == ingredientId);

                // Get the converted quantity in grams for display purposes
                var quantityInGrams = _ingredientMealService.ConvertToGrams(quantity, unit);
                var updatedMeal = await _mealService.GetMealByIdAsync(mealId);

                return Json(new
                {
                    success = true,
                    ingredientId,
                    ingredientName = ingredient.Name,
                    quantity,
                    unit,
                    quantityInGrams,
                    formattedQuantity = _ingredientMealService.FormatQuantity(quantity, unit),
                    quantityInTeaspoons = ingredientMeal.QuantityInTeaspoons,
                    quantityInTablespoons = ingredientMeal.QuantityInTablespoons,
                    quantityInCups = ingredientMeal.QuantityInCups,
                    quantityInCoffeeCups = ingredientMeal.QuantityInCoffeeCups,
                    quantityInMillilitres = ingredientMeal.QuantityInMillilitres,
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // GET: /MealPlan/SearchRecipes?query=chicken&filter=mine
        // Used for autocomplete in MealPlan Details, Create, Edit pages
        [HttpGet]
        public async Task<IActionResult> SearchIngredients([FromQuery] string term)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(term))
                    return Json(new List<object>());

                var user = await _userManager.GetUserAsync(User);
                if (user == null) return Unauthorized();

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConvertMeasurement([FromBody] ConversionRequest request)
        {
            try
            {
                var grams = _ingredientMealService.ConvertToGrams(request.Quantity, request.FromUnit);

                var result = new
                {
                    grams = Math.Round(grams, 1),
                    teaspoons = Math.Round(_ingredientMealService.ConvertFromGrams(grams, "teaspoons"), 1),
                    tablespoons = Math.Round(_ingredientMealService.ConvertFromGrams(grams, "tablespoons"), 1),
                    cups = Math.Round(_ingredientMealService.ConvertFromGrams(grams, "cups"), 2),
                    coffeeCups = Math.Round(_ingredientMealService.ConvertFromGrams(grams, "coffeecups"), 2),
                    millilitres = Math.Round(_ingredientMealService.ConvertFromGrams(grams, "millilitres"), 0)
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

        // GET: /MealPlan/GetGroceryList/{id}
        [HttpGet]
        public async Task<IActionResult> GetGroceryList(Guid id)
        {
            
                var mealPlan = await _mealPlanService.GetByIdAsync(id);
                if (mealPlan == null) return NotFound();

                var user = await _userManager.GetUserAsync(User);

                // Check if user has access (owner or follower)
                bool isOwner = mealPlan.UserId == user!.Id;
                bool isFollowing = await _mealPlanFollowerService.IsFollowingAsync(user.Id, id);

                if (!isOwner && !isFollowing && !User.IsInRole("Admin"))
                    return Forbid();

           
                var groceryListDto = await _groceryListService.GenerateGroceryListForMealPlanAsync(id);
               

                var viewModel = new GroceryListViewModel
                {
                    MealPlanId = groceryListDto.MealPlanId,
                    MealPlanName = groceryListDto.MealPlanName,
                    GeneratedAt = groceryListDto.GeneratedAt,
                    Items = groceryListDto.Items.Select(item => new GroceryItemViewModel
                    {
                        IngredientId = item.IngredientId,
                        IngredientName = item.IngredientName,
                        Brand = item.Brand,
                        QuantityInGrams = item.QuantityInGrams,
                        Stores = item.Stores.Select(store => new StoreAvailabilityViewModel
                        {
                            StoreName = store.StoreName,
                            StoreLocation = store.StoreLocation,
                            InStock = store.InStock,
                            Price = store.Price,
                            Currency = store.Currency,
                            ProductUrl = store.ProductUrl,
                            LastUpdated = store.LastUpdated,
                            PricePer100g = store.PricePer100g,
                            PackageQuantityInGrams = store.PackageQuantityInGrams,
                            ProductName = store.ProductName,
                            ImageUrl = store.ImageUrl,
                            StoreLogoUrl = store.StoreLogoUrl,
                            IsMockData = store.IsMockData
                        })
                    })
                };

                return Json(viewModel);
           

        }
    }
}
