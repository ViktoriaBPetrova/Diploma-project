using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Enums;
using HealthyRecipes.Services.MealPlanFollowers;
using HealthyRecipes.Services.MealPlanDays;
using HealthyRecipes.Services.MealPlans;
using HealthyRecipes.Web.ViewModels.MealPlanFollower;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyRecipes.Web.Controllers
{
    [Authorize]
    public class MealPlanFollowerController : Controller
    {
        private readonly IMealPlanFollower _mealPlanFollowerService;
        private readonly IMealPlan _mealPlanService;
        private readonly IMealPlanDay _mealPlanDayService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MealPlanFollowerController(
            IMealPlanFollower mealPlanFollowerService,
            IMealPlan mealPlanService,
            IMealPlanDay mealPlanDayService,
            UserManager<ApplicationUser> userManager)
        {
            _mealPlanFollowerService = mealPlanFollowerService;
            _mealPlanService = mealPlanService;
            _mealPlanDayService = mealPlanDayService;
            _userManager = userManager;
        }

        // GET: /MealPlanFollower/StartFollowing/{id}
        public async Task<IActionResult> StartFollowing(Guid id)
        {
            try
            {
                var mealPlan = await _mealPlanService.GetByIdAsync(id);
                if (mealPlan == null)
                    return NotFound();

                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                // Check if already following
                var isFollowing = await _mealPlanFollowerService.IsFollowingAsync(user.Id, id);
                if (isFollowing)
                {
                    TempData["ErrorMessage"] = "You are already following this meal plan.";
                    return RedirectToAction("Details", "MealPlan", new { id });
                }

                var days = await _mealPlanDayService.GetDaysByMealPlanAsync(id);

                var viewModel = new StartFollowingViewModel
                {
                    MealPlanId = id,
                    MealPlanName = mealPlan.Name,
                    MealPlanDescription = mealPlan.Description,
                    DaysCount = days.Count(),
                    Calories = mealPlan.Calories,
                    Protein = mealPlan.Protein,
                    Carbs = mealPlan.Carbs,
                    Fat = mealPlan.Fat
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while loading the meal plan.";
                return RedirectToAction("Index", "MealPlan");
            }
        }

        // POST: /MealPlanFollower/StartFollowing/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StartFollowing(Guid id, StartFollowingViewModel vm)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                var success = await _mealPlanFollowerService.StartFollowingAsync(user.Id, id);

                if (success)
                {
                    TempData["SuccessMessage"] = "You are now following this meal plan!";
                    return RedirectToAction(nameof(MyActivePlans));
                }
                else
                {
                    TempData["ErrorMessage"] = "Could not start following this meal plan.";
                    return RedirectToAction("Details", "MealPlan", new { id });
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while starting to follow the meal plan.";
                return RedirectToAction("Details", "MealPlan", new { id });
            }
        }

        // POST: /MealPlanFollower/CompletePlan/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompletePlan(Guid id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                var success = await _mealPlanFollowerService.CompleteMealPlanAsync(user.Id, id);

                if (success)
                {
                    TempData["SuccessMessage"] = "Congratulations! You've completed this meal plan!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Could not mark meal plan as completed.";
                }

                return RedirectToAction(nameof(MyActivePlans));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while completing the meal plan.";
                return RedirectToAction(nameof(MyActivePlans));
            }
        }

        // GET: /MealPlanFollower/DropPlan/{id}
        public async Task<IActionResult> DropPlan(Guid id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                var followerDetails = await _mealPlanFollowerService.GetFollowerDetailsAsync(user.Id, id);
                if (followerDetails == null)
                {
                    TempData["ErrorMessage"] = "You are not following this meal plan.";
                    return RedirectToAction(nameof(MyActivePlans));
                }

                var viewModel = new ReasonMealPlanViewModel
                {
                    MealPlanId = id,
                    MealPlanName = followerDetails.MealPlan.Name
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while loading the page.";
                return RedirectToAction(nameof(MyActivePlans));
            }
        }

        // POST: /MealPlanFollower/DropPlan/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DropPlan(Guid id, ReasonMealPlanViewModel vm)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                var success = await _mealPlanFollowerService.DropMealPlanAsync(user.Id, id, vm.Reason);

                if (success)
                {
                    TempData["SuccessMessage"] = "You have stopped following this meal plan.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Could not stop following this meal plan.";
                }

                return RedirectToAction(nameof(MyActivePlans));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while dropping the meal plan.";
                return RedirectToAction(nameof(MyActivePlans));
            }
        }

        // GET: /MealPlanFollower/PausePlan/{id}
        public async Task<IActionResult> PausePlan(Guid id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                var followerDetails = await _mealPlanFollowerService.GetFollowerDetailsAsync(user.Id, id);
                if (followerDetails == null)
                {
                    TempData["ErrorMessage"] = "You are not following this meal plan.";
                    return RedirectToAction(nameof(MyActivePlans));
                }

                var viewModel = new ReasonMealPlanViewModel
                {
                    MealPlanId = id,
                    MealPlanName = followerDetails.MealPlan.Name
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while loading the page.";
                return RedirectToAction(nameof(MyActivePlans));
            }
        }

        // POST: /MealPlanFollower/PausePlan/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PausePlan(Guid id, ReasonMealPlanViewModel vm)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                var success = await _mealPlanFollowerService.PauseMealPlanAsync(user.Id, id, vm.Reason);

                if (success)
                {
                    TempData["SuccessMessage"] = "Meal plan paused successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Could not pause this meal plan.";
                }

                return RedirectToAction(nameof(MyActivePlans));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while pausing the meal plan.";
                return RedirectToAction(nameof(MyActivePlans));
            }
        }

        // POST: /MealPlanFollower/ResumePlan/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResumePlan(Guid id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                var success = await _mealPlanFollowerService.ResumeMealPlanAsync(user.Id, id);

                if (success)
                {
                    TempData["SuccessMessage"] = "Meal plan resumed successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Could not resume this meal plan.";
                }

                return RedirectToAction(nameof(MyActivePlans));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while resuming the meal plan.";
                return RedirectToAction(nameof(MyActivePlans));
            }
        }

        // GET: /MealPlanFollower/MyActivePlans
        public async Task<IActionResult> MyActivePlans()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                var allPlans = await _mealPlanFollowerService.GetAllFollowingPlansAsync(user.Id);

                var viewModel = new ActiveMealPlansViewModel
                {
                    ActivePlans = allPlans
                        .Where(f => f.Status == MealPlanFollowerStatus.Active)
                        .Select(f => new MealPlanFollowerItemViewModel
                        {
                            MealPlanId = f.MealPlanId,
                            MealPlanName = f.MealPlan.Name,
                            MealPlanDescription = f.MealPlan.Description,
                            DaysCount = f.MealPlan.MealPlanDays.Count(),
                            Calories = f.MealPlan.Calories,
                            Protein = f.MealPlan.Protein,
                            Carbs = f.MealPlan.Carbs,
                            Fat = f.MealPlan.Fat,
                            StartedAt = f.StartedAt,
                            CompletedAt = f.CompletedAt,
                            Status = f.Status,
                            DropoutReason = f.DropoutReason,
                            IsActive = f.IsActive,
                            DaysFollowing = (int)(DateTime.UtcNow - f.StartedAt).TotalDays,
                            CreatorName = f.MealPlan.User.UserName ?? "Unknown"
                        }),
                    CompletedPlans = allPlans
                        .Where(f => f.Status == MealPlanFollowerStatus.Completed)
                        .Select(f => new MealPlanFollowerItemViewModel
                        {
                            MealPlanId = f.MealPlanId,
                            MealPlanName = f.MealPlan.Name,
                            MealPlanDescription = f.MealPlan.Description,
                            DaysCount = f.MealPlan.MealPlanDays.Count(),
                            Calories = f.MealPlan.Calories,
                            Protein = f.MealPlan.Protein,
                            Carbs = f.MealPlan.Carbs,
                            Fat = f.MealPlan.Fat,
                            StartedAt = f.StartedAt,
                            CompletedAt = f.CompletedAt,
                            Status = f.Status,
                            DropoutReason = f.DropoutReason,
                            IsActive = f.IsActive,
                            DaysFollowing = (int)(DateTime.UtcNow - f.StartedAt).TotalDays,
                            CreatorName = f.MealPlan.User.UserName ?? "Unknown"
                        }),
                    PausedPlans = allPlans
                        .Where(f => f.Status == MealPlanFollowerStatus.Paused)
                        .Select(f => new MealPlanFollowerItemViewModel
                        {
                            MealPlanId = f.MealPlanId,
                            MealPlanName = f.MealPlan.Name,
                            MealPlanDescription = f.MealPlan.Description,
                            DaysCount = f.MealPlan.MealPlanDays.Count(),
                            Calories = f.MealPlan.Calories,
                            Protein = f.MealPlan.Protein,
                            Carbs = f.MealPlan.Carbs,
                            Fat = f.MealPlan.Fat,
                            StartedAt = f.StartedAt,
                            CompletedAt = f.CompletedAt,
                            Status = f.Status,
                            DropoutReason = f.DropoutReason,
                            IsActive = f.IsActive,
                            DaysFollowing = (int)(DateTime.UtcNow - f.StartedAt).TotalDays,
                            CreatorName = f.MealPlan.User.UserName ?? "Unknown"
                        }),
                    DroppedPlans = allPlans
                        .Where(f => f.Status == MealPlanFollowerStatus.Dropped)
                        .Select(f => new MealPlanFollowerItemViewModel
                        {
                            MealPlanId = f.MealPlanId,
                            MealPlanName = f.MealPlan.Name,
                            MealPlanDescription = f.MealPlan.Description,
                            DaysCount = f.MealPlan.MealPlanDays.Count(),
                            Calories = f.MealPlan.Calories,
                            Protein = f.MealPlan.Protein,
                            Carbs = f.MealPlan.Carbs,
                            Fat = f.MealPlan.Fat,
                            StartedAt = f.StartedAt,
                            CompletedAt = f.CompletedAt,
                            Status = f.Status,
                            DropoutReason = f.DropoutReason,
                            IsActive = f.IsActive,
                            DaysFollowing = (int)(DateTime.UtcNow - f.StartedAt).TotalDays,
                            CreatorName = f.MealPlan.User.UserName ?? "Unknown"
                        })
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while loading your meal plans.";
                return RedirectToAction("Index", "MealPlan");
            }
        }

        // GET: /MealPlanFollower/Followers/{id}
        public async Task<IActionResult> Followers(Guid id)
        {
            try
            {
                var mealPlan = await _mealPlanService.GetByIdAsync(id);
                if (mealPlan == null)
                    return NotFound();

                var followers = await _mealPlanFollowerService.GetPlanFollowersAsync(id);

                var viewModel = new PlanFollowersViewModel
                {
                    MealPlanId = id,
                    MealPlanName = mealPlan.Name,
                    TotalFollowers = followers.Count(),
                    ActiveFollowers = followers.Count(f => f.IsActive),
                    CompletedFollowers = followers.Count(f => f.Status == MealPlanFollowerStatus.Completed),
                    Followers = followers.Select(f => new FollowerItemViewModel
                    {
                        UserId = f.UserId,
                        UserName = f.User.UserName ?? "Unknown",
                        UserEmail = f.User.Email,
                        StartedAt = f.StartedAt,
                        CompletedAt = f.CompletedAt,
                        Status = f.Status,
                        IsActive = f.IsActive,
                        DaysFollowing = (int)(DateTime.UtcNow - f.StartedAt).TotalDays
                    }).OrderByDescending(f => f.StartedAt)
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while loading followers.";
                return RedirectToAction("Details", "MealPlan", new { id });
            }
        }
    }
}
