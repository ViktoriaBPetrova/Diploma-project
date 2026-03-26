using HealthyRecipes.Data.Enums;
using HealthyRecipes.Services.MealPlanFollowers;
using HealthyRecipes.Services.MealPlans;
using HealthyRecipes.Web.ViewModels.MealPlanFollower.FollowingDashboard;
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
        private readonly UserManager<Data.Entities.ApplicationUser> _userManager;

        public MealPlanFollowerController(
            IMealPlanFollower mealPlanFollowerService,
            IMealPlan mealPlanService,
            UserManager<Data.Entities.ApplicationUser> userManager)
        {
            _mealPlanFollowerService = mealPlanFollowerService ?? throw new ArgumentNullException(nameof(mealPlanFollowerService));
            _mealPlanService = mealPlanService ?? throw new ArgumentNullException(nameof(mealPlanService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        // ========== PHASE 1: NEW FOLLOWING DASHBOARD ==========
        
        // GET: /MealPlanFollower/FollowingDashboard
        public async Task<IActionResult> FollowingDashboard()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                var viewModel = new FollowingDashboardViewModel();

                // Get active plan
                var activePlan = await _mealPlanFollowerService.GetActivePlanAsync(user.Id);

                if (activePlan != null)
                {
                    var daysFollowing = (int)(DateTime.UtcNow - activePlan.StartedAt).TotalDays;
                    var totalDays = activePlan.MealPlan.MealPlanDays.Count(d => !d.Deleted);
                    var daysRemaining = Math.Max(0, totalDays - daysFollowing);
                    var progressPercentage = totalDays > 0 ? (float)daysFollowing / totalDays * 100 : 0;
                    var isOverdue = activePlan.ExpectedCompletionDate.HasValue && 
                                   DateTime.UtcNow > activePlan.ExpectedCompletionDate.Value;

                    viewModel.ActivePlan = new ActivePlanDetailViewModel
                    {
                        MealPlanId = activePlan.MealPlanId,
                        Name = activePlan.MealPlan.Name,
                        Description = activePlan.MealPlan.Description,
                        TotalDays = totalDays,
                        DaysFollowing = daysFollowing,
                        DaysRemaining = daysRemaining,
                        ProgressPercentage = Math.Min(progressPercentage, 100),
                        StartedAt = activePlan.StartedAt,
                        ExpectedCompletionDate = activePlan.ExpectedCompletionDate ?? DateTime.UtcNow.AddDays(totalDays),
                        IsOverdue = isOverdue,
                        Calories = activePlan.MealPlan.Calories,
                        Protein = activePlan.MealPlan.Protein,
                        Carbs = activePlan.MealPlan.Carbs,
                        Fat = activePlan.MealPlan.Fat,
                        CreatorName = activePlan.MealPlan.User?.UserName ?? "Unknown"
                    };

                    // Check for completion alert
                    if (isOverdue && !activePlan.HasSeenCompletionPrompt)
                    {
                        viewModel.ShowCompletionAlert = true;
                        viewModel.CompletionAlertMessage = $"You were expected to complete this plan by {activePlan.ExpectedCompletionDate:MMM dd}. Would you like to mark it as complete?";
                    }

                    // Get today's meals (calculate which day user is on)
                    var currentDayNumber = Math.Min(daysFollowing + 1, totalDays);
                    var todaysPlanDay = activePlan.MealPlan.MealPlanDays
                        .Where(d => !d.Deleted)
                        .OrderBy(d => d.DayNumber)
                        .Skip(currentDayNumber - 1)
                        .FirstOrDefault();

                    if (todaysPlanDay != null)
                    {
                        viewModel.TodaysSchedule = new TodaysMealsViewModel
                        {
                            CurrentDayNumber = currentDayNumber,
                            DayOfWeek = (Data.Enums.DayOfWeek)todaysPlanDay.DayOfWeek,
                            MealPlanDayId = todaysPlanDay.Id,
                            Calories = todaysPlanDay.Calories,
                            Protein = todaysPlanDay.Protein,
                            Carbs = todaysPlanDay.Carbs,
                            Fat = todaysPlanDay.Fat,
                            Meals = todaysPlanDay.Meals
                                .Where(m => !m.Deleted)
                                .OrderBy(m => m.Type)
                                .Select(m => new TodaysMealItemViewModel
                                {
                                    MealId = m.Id,
                                    Type = m.Type,
                                    Calories = m.Calories,
                                    Protein = m.Protein,
                                    Carbs = m.Carbs,
                                    Fat = m.Fat,
                                    Recipes = m.RecipeMeals
                                        .Where(rm => !rm.Deleted && rm.Recipe != null)
                                        .Select(rm => new MealRecipeItemViewModel
                                        {
                                            RecipeId = rm.RecipeId,
                                            Name = rm.Recipe.Title,
                                            ImageUrl = rm.Recipe.ImageUrl,
                                            PrepTime = rm.Recipe.PrepTime,
                                            Calories = rm.Recipe.Calories,
                                            Protein = rm.Recipe.Protein,
                                            Carbs = rm.Recipe.Carbs,
                                            Fat = rm.Recipe.Fat
                                        })
                                })
                        };
                    }
                }

                // Get paused plans
                var pausedPlans = await _mealPlanFollowerService.GetPausedFollowingPlansAsync(user.Id);
                viewModel.PausedPlans = pausedPlans.Select(p => new PausedPlanItemViewModel
                {
                    MealPlanId = p.MealPlanId,
                    MealPlanName = p.MealPlan.Name,
                    MealPlanDescription = p.MealPlan.Description,
                    DaysCount = p.MealPlan.MealPlanDays.Count(d => !d.Deleted),
                    PausedAt = p.UpdatedAt,
                    PauseReason = p.PauseReason,
                    CreatorName = p.MealPlan.User?.UserName ?? "Unknown",
                    Calories = p.MealPlan.Calories,
                    Protein = p.MealPlan.Protein,
                    Carbs = p.MealPlan.Carbs,
                    Fat = p.MealPlan.Fat
                });

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while loading your following dashboard.";
                return RedirectToAction("Index", "MealPlan");
            }
        }

        // POST: /MealPlanFollower/DismissCompletionAlert/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DismissCompletionAlert(Guid id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                await _mealPlanFollowerService.MarkCompletionPromptSeenAsync(user.Id, id);
                
                return RedirectToAction(nameof(FollowingDashboard));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred.";
                return RedirectToAction(nameof(FollowingDashboard));
            }
        }

        // ========== UPDATED ACTIONS WITH PHASE 1 VALIDATION ==========

        // GET: /MealPlanFollower/StartFollowing/{id}
        public async Task<IActionResult> StartFollowing(Guid id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                    return RedirectToAction("Login", "Account");

                // PHASE 1: Check if user already has an active plan
                var activePlan = await _mealPlanFollowerService.GetActivePlanAsync(user.Id);
                if (activePlan != null && activePlan.MealPlanId != id)
                {
                    TempData["ErrorMessage"] = $"You're already following '{activePlan.MealPlan.Name}'. Please pause or complete it before starting a new plan.";
                    return RedirectToAction("Details", "MealPlan", new { id });
                }

                var mealPlan = await _mealPlanService.GetByIdAsync(id);
                if (mealPlan == null)
                    return NotFound();

                var viewModel = new StartFollowingViewModel
                {
                    MealPlanId = id,
                    MealPlanName = mealPlan.Name,
                    MealPlanDescription = mealPlan.Description,
                    DaysCount = mealPlan.MealPlanDays?.Count() ?? 0,
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
                    return RedirectToAction(nameof(FollowingDashboard));
                }
                else
                {
                    TempData["ErrorMessage"] = "Could not start following this meal plan. You may already have an active plan.";
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
                    return RedirectToAction(nameof(FollowingDashboard));
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
                return RedirectToAction(nameof(FollowingDashboard));
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

                return RedirectToAction(nameof(FollowingDashboard));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while dropping the meal plan.";
                return RedirectToAction(nameof(FollowingDashboard));
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
                    return RedirectToAction(nameof(FollowingDashboard));
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
                return RedirectToAction(nameof(FollowingDashboard));
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
                    TempData["SuccessMessage"] = "You have paused this meal plan.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Could not pause this meal plan.";
                }

                return RedirectToAction(nameof(FollowingDashboard));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while pausing the meal plan.";
                return RedirectToAction(nameof(FollowingDashboard));
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
                    TempData["SuccessMessage"] = "You have resumed this meal plan.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Could not resume this meal plan. You may already have an active plan.";
                }

                return RedirectToAction(nameof(FollowingDashboard));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while resuming the meal plan.";
                return RedirectToAction(nameof(FollowingDashboard));
            }
        }

        // ========== EXISTING ACTIONS (KEPT FOR COMPATIBILITY) ==========

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
                    })
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while loading followers.";
                return RedirectToAction("Index", "MealPlan");
            }
        }
    }
}
