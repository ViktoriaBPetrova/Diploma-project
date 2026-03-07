using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.MealPlanDays;
using HealthyRecipes.Services.MealPlans;
using HealthyRecipes.Services.Meals;
using HealthyRecipes.Services.RecipeMeals;
using HealthyRecipes.Services.SavedMealPlans;
using HealthyRecipes.Web.ViewModels.MealPlan;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ISavedMealPlan _savedMealPlanService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MealPlanController(
            IMealPlan mealPlanService,
            IMealPlanDay mealPlanDayService,
            IMeal mealService,
            IRecipeMeal recipeMealService,
            ISavedMealPlan savedMealPlanService,
            UserManager<ApplicationUser> userManager)
        {
            _mealPlanService = mealPlanService;
            _mealPlanDayService = mealPlanDayService;
            _mealService = mealService;
            _recipeMealService = recipeMealService;
            _savedMealPlanService = savedMealPlanService;
            _userManager = userManager;
        }

        // GET: /MealPlan
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var myPlans = await _mealPlanService.GetMealPlansByUserAsync(user!.Id);
            var savedPlans = await _savedMealPlanService.GetSavedMealPlansByUserAsync(user.Id);
            var savedPlanIds = savedPlans.Select(s => s.MealPlanId).ToHashSet();

            var vm = new MealPlanIndexViewModel
            {
                MyMealPlans = myPlans.Select(mp => new MealPlanCardViewModel
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
                    CreatedAt = mp.CreatedAt
                }),
                SavedMealPlans = savedPlans.Select(smp => new MealPlanCardViewModel
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
                    CreatedAt = smp.MealPlan.CreatedAt
                })
            };

            return View(vm);
        }

        // GET: /MealPlan/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var mealPlan = await _mealPlanService.GetByIdAsync(id);
            if (mealPlan == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            bool isSaved = await _savedMealPlanService.IsMealPlanSavedAsync(user!.Id, id);
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
