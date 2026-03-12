using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Categories;
using HealthyRecipes.Services.MealPlanDays;
using HealthyRecipes.Services.MealPlanFollowers;
using HealthyRecipes.Services.MealPlans;
using HealthyRecipes.Services.MealPlans.Models;
using HealthyRecipes.Services.Meals;
using HealthyRecipes.Services.RecipeMeals;
using HealthyRecipes.Services.SavedMealPlans;
using HealthyRecipes.Web.ViewModels.MealPlan;
using Microsoft.AspNetCore.Authorization;
using HealthyRecipes.Services.MealPlanFollowers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyRecipes.Web.Controllers
{
    [Authorize]
    public class MealPlanController : Controller
    {
        private readonly IMealPlan _mealPlanService;
        private readonly IMealPlanDay _mealPlanDayService;
        private readonly IMeal _mealService;
        private readonly IRecipeMeal _recipeMealService;
        private readonly ICategory _categoryService;
        private readonly ISavedMealPlan _savedMealPlanService;
        private readonly IMealPlanFollower _mealPlanFollowerService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MealPlanController(
            IMealPlan mealPlanService,
            ICategory categoryService,
            IMealPlanDay mealPlanDayService,
            IMeal mealService,
            IRecipeMeal recipeMealService,
            ISavedMealPlan savedMealPlanService,
            IMealPlanFollower mealPlanFollowerService,
            UserManager<ApplicationUser> userManager)
        {
            _mealPlanService = mealPlanService;
            _mealPlanDayService = mealPlanDayService;
            _mealService = mealService;
            _recipeMealService = recipeMealService;
            _categoryService = categoryService;
            _savedMealPlanService = savedMealPlanService;
            _mealPlanFollowerService = mealPlanFollowerService;
            _userManager = userManager;
        }

        // GET: /MealPlan

        public async Task<IActionResult> Index([FromQuery] MealPlanFilterViewModel filter)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    return RedirectToAction("Login", "Account");
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

                // Get filtered meal plans (for Browse All section)
                var (allMealPlans, totalCount) = await _mealPlanService.GetFilteredMealPlansAsync(filterDto);

                // Get user's own meal plans
                var myPlans = await _mealPlanService.GetMealPlansByUserAsync(user.Id);

                // Get saved meal plans
                var savedPlans = await _savedMealPlanService.GetSavedMealPlansByUserAsync(user.Id);
                var savedPlanIds = savedPlans.Select(s => s.MealPlanId).ToHashSet();

                // Get all categories for filter UI
                var categories = await _categoryService.GetAllCategoriesAsync();

                // Map My Plans 
                var myPlanCards = new List<MealPlanCardViewModel>();
                foreach (var mp in myPlans)
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
                        IsSaved = savedPlanIds.Contains(mp.Id),
                        IsOwner = true,
                        CreatedAt = mp.CreatedAt,
                        FollowerCount = followerCount,  // ADD THIS
                        CategoryNames = mp.MealPlanCategories?
                            .Where(mpc => !mpc.Deleted && mpc.Category != null && !mpc.Category.Deleted)
                            .Select(mpc => mpc.Category.Name) ?? Enumerable.Empty<string>()
                    });
                }

                // Map Saved Plans 
                var savedPlanCards = new List<MealPlanCardViewModel>();
                foreach (var smp in savedPlans)
                {
                    var followerCount = await _mealPlanFollowerService.GetFollowerCountAsync(smp.MealPlan.Id);

                    savedPlanCards.Add(new MealPlanCardViewModel
                    {
                        Id = smp.MealPlan.Id,
                        Name = smp.MealPlan.Name,
                        Description = smp.MealPlan.Description,
                        Calories = smp.MealPlan.Calories,
                        Protein = smp.MealPlan.Protein,
                        Carbs = smp.MealPlan.Carbs,
                        Fat = smp.MealPlan.Fat,
                        DayCount = smp.MealPlan.MealPlanDays?.Count() ?? 0,
                        IsSaved = true,
                        IsOwner = smp.MealPlan.UserId == user.Id,
                        CreatedAt = smp.MealPlan.CreatedAt,
                        FollowerCount = followerCount,  // ADD THIS
                        CategoryNames = smp.MealPlan.MealPlanCategories?
                            .Where(mpc => !mpc.Deleted && mpc.Category != null && !mpc.Category.Deleted)
                            .Select(mpc => mpc.Category.Name) ?? Enumerable.Empty<string>()
                    });
                }

                // Map Browse All 
                var browseCards = new List<MealPlanCardViewModel>();
                foreach (var mp in allMealPlans.Where(mp => mp.UserId != user.Id))
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
                        IsSaved = savedPlanIds.Contains(mp.Id),
                        IsOwner = false,
                        CreatedAt = mp.CreatedAt,
                        FollowerCount = followerCount,  // ADD THIS
                        CategoryNames = mp.MealPlanCategories?
                            .Where(mpc => !mpc.Deleted && mpc.Category != null && !mpc.Category.Deleted)
                            .Select(mpc => mpc.Category.Name) ?? Enumerable.Empty<string>()
                    });
                }

                var vm = new MealPlanIndexViewModel
                {
                    MyMealPlans = myPlanCards,
                    SavedMealPlans = savedPlanCards,
                    BrowseAllMealPlans = browseCards,
                    Categories = categories.Select(c => new MealPlanCategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList(),
                    Filter = filter,
                    TotalCount = totalCount,
                    PageNumber = filter.PageNumber,
                    PageSize = filter.PageSize,
                    TotalPages = (int)Math.Ceiling((double)totalCount / filter.PageSize)
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

            var user = await _userManager.GetUserAsync(User);
            bool isSaved = await _savedMealPlanService.IsMealPlanSavedAsync(user!.Id, id);
            bool isFollowing = await _mealPlanFollowerService.IsFollowingAsync(user.Id, id);
            var days = await _mealPlanDayService.GetDaysByMealPlanAsync(id);

            var dayVms = new List<MealPlanDayViewModel>();
            foreach (var day in days.OrderBy(d => d.DayNumber))
            {
                var meals = await _mealService.GetMealsByDayAsync(day.Id);
                var mealVms = new List<MealViewModel>();
                foreach (var meal in meals)
                {
                    var recipeMeals = await _recipeMealService.GetRecipesByMealAsync(meal.Id);
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
                            Info = rm.Recipe?.Info ?? "",
                            ImageUrl = rm.Recipe?.ImageUrl,
                            Calories = rm.Recipe?.Calories ?? 0,
                            Protein = rm.Recipe?.Protein ?? 0,
                            Carbs = rm.Recipe?.Carbs ?? 0,
                            Fat = rm.Recipe?.Fat ?? 0
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
                IsOwner = mealPlan.UserId == user.Id,
                IsFollowing = isFollowing,
                Days = dayVms
            };

            return View(vm);
        }

        // GET: /MealPlan/Create
        public IActionResult Create() => View(new CreateMealPlanViewModel());

        // POST: /MealPlan/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMealPlanViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = await _userManager.GetUserAsync(User);
            var mealPlan = new MealPlan
            {
                Name = vm.Name,
                Description = vm.Description,
                UserId = user!.Id
            };

            var id = await _mealPlanService.CreateMealPlanAsync(mealPlan);
            return RedirectToAction(nameof(Details), new { id });
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

            mealPlan.Name = vm.Name;
            mealPlan.Description = vm.Description;
            await _mealPlanService.UpdateMealPlanAsync(mealPlan);

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
    }
}
