using HealthyRecipes.Data.Enums;
using HealthyRecipes.Services.FileUploads;
using HealthyRecipes.Services.MealEntries;
using HealthyRecipes.Services.MealPlanDayEntries;
using HealthyRecipes.Services.MealPlanFollowers;
using HealthyRecipes.Services.MealPlans;
using HealthyRecipes.Web.ViewModels.MealPlanFollower;
using HealthyRecipes.Web.ViewModels.MealPlanFollower.FollowingDashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;




namespace HealthyRecipes.Web.Controllers
{
    [Authorize]
    public class MealPlanFollowerController : Controller
    {
        private readonly IMealPlanFollower _mealPlanFollowerService;
        private readonly IMealPlan _mealPlanService;
        private readonly IMealEntry _mealEntryService;
        private readonly IMealPlanDayEntry _mealPlanDayEntryService;
        private readonly IFileUpload _fileUploadService;
        private readonly UserManager<Data.Entities.ApplicationUser> _userManager;

        public MealPlanFollowerController(
            IMealEntry mealEntryService,
        IMealPlanDayEntry mealPlanDayEntryService,
            IMealPlanFollower mealPlanFollowerService,
            IMealPlan mealPlanService,
            IFileUpload fileUploadService,
            UserManager<Data.Entities.ApplicationUser> userManager)
        {
            _mealEntryService = mealEntryService ?? throw new ArgumentNullException(nameof(mealEntryService));
            _mealPlanDayEntryService = mealPlanDayEntryService ?? throw new ArgumentNullException(nameof(mealPlanDayEntryService));
            _mealPlanFollowerService = mealPlanFollowerService ?? throw new ArgumentNullException(nameof(mealPlanFollowerService));
            _mealPlanService = mealPlanService ?? throw new ArgumentNullException(nameof(mealPlanService));
            _fileUploadService = fileUploadService ?? throw new ArgumentNullException(nameof(fileUploadService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        // ========== FOLLOWING DASHBOARD ==========

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
                        .Where(d => !d.Deleted && d.DayNumber == currentDayNumber)
                        .FirstOrDefault();

                    if (todaysPlanDay != null)
                    {
                        //Load existing meal entries for today's meals
                        var mealIds = todaysPlanDay.Meals.Where(m => !m.Deleted).Select(m => m.Id).ToList();
                        var mealEntries = await _mealEntryService.GetEntriesForMealsAsync(user.Id, mealIds);

                        // NEW: Load day reflection if exists
                        var dayEntry = await _mealPlanDayEntryService.GetEntryAsync(user.Id, todaysPlanDay.Id);

                        viewModel.TodaysSchedule = new TodaysMealsViewModel
                        {
                            CurrentDayNumber = currentDayNumber,
                            DayOfWeek = (Data.Enums.DayOfWeek)todaysPlanDay.DayOfWeek,
                            MealPlanDayId = todaysPlanDay.Id,
                            Calories = todaysPlanDay.Calories,
                            Protein = todaysPlanDay.Protein,
                            Carbs = todaysPlanDay.Carbs,
                            Fat = todaysPlanDay.Fat,

                            // NEW: Map day reflection data
                            HasDayEntry = dayEntry != null,
                            DayOverallFeeling = dayEntry?.OverallFeeling,
                            DayCompletedAt = dayEntry?.CompletedAt,

                            Meals = todaysPlanDay.Meals
                                .Where(m => !m.Deleted)
                                .OrderBy(m => m.Type)
                                .Select(m =>
                                {
                                    // NEW: Find existing entry for this meal
                                    var existingEntry = mealEntries.FirstOrDefault(e => e.MealId == m.Id);

                                    return new TodaysMealItemViewModel
                                    {
                                        MealId = m.Id,
                                        Type = m.Type,
                                        Calories = m.Calories,
                                        Protein = m.Protein,
                                        Carbs = m.Carbs,
                                        Fat = m.Fat,

                                        // NEW: Map meal entry data
                                        HasEntry = existingEntry != null,
                                        FeelingComment = existingEntry?.FeelingComment,
                                        PhotoUrl = existingEntry?.PhotoUrl,
                                        ConsumedAt = existingEntry?.ConsumedAt,

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
                                    };
                                })
                        };
                    }
                }

                // Load ALL days with their meal entry status ==========
                if (activePlan != null)
                {
                    var allDays = activePlan.MealPlan.MealPlanDays
                        .Where(d => !d.Deleted)
                        .OrderBy(d => d.DayNumber)
                        .ToList();

                    var pastDaysList = new List<PastDayViewModel>();
                    var startDate = activePlan.StartedAt.Date;

                    foreach (var day in allDays)
                    {
                        var dayDate = startDate.AddDays(day.DayNumber - 1);
                        var isToday = dayDate.Date == DateTime.UtcNow.Date;
                        var isFuture = dayDate.Date > DateTime.UtcNow.Date;

                        // Get all meals for this day
                        var dayMeals = day.Meals.Where(m => !m.Deleted).ToList();
                        var mealIds = dayMeals.Select(m => m.Id).ToList();

                        // Get meal entries for this day
                        var dayMealEntries = await _mealEntryService.GetEntriesForMealsAsync(user.Id, mealIds);
                        var loggedMealsCount = dayMealEntries.Count();

                        // Get day reflection
                        var dayEntry = await _mealPlanDayEntryService.GetEntryAsync(user.Id, day.Id);

                        pastDaysList.Add(new PastDayViewModel
                        {
                            DayNumber = day.DayNumber,
                            DayOfWeek = (Data.Enums.DayOfWeek)day.DayOfWeek,
                            Date = dayDate,
                            IsToday = isToday,
                            IsFuture = isFuture,
                            Calories = day.Calories,
                            Protein = day.Protein,
                            Carbs = day.Carbs,
                            Fat = day.Fat,
                            TotalMeals = dayMeals.Count,
                            LoggedMeals = loggedMealsCount,
                            HasDayReflection = dayEntry != null,
                            DayReflection = dayEntry?.OverallFeeling
                        });
                    }

                    viewModel.PastDays = pastDaysList;
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
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while loading your following dashboard.";
                return RedirectToAction("Index", "MealPlan");
            }
        }

        // ========== UPDATED ACTIONS WITH VALIDATION ==========

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
                            Status = f.Status,
                            DropoutReason = f.DropoutReason,
                            DroppedAt = f.UpdatedAt,
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
                            Status = f.Status,
                            PauseReason = f.PauseReason,
                            PausedAt = f.UpdatedAt,
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
                            DroppedAt = f.UpdatedAt,
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

        /// <summary>
        /// Shows completion consent form when user completes or drops a meal plan.
        /// GET: /MealPlanFollower/CompletionConsent/{mealPlanId}
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CompletionConsent(Guid mealPlanId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            try
            {
                var follower = await _mealPlanFollowerService.GetFollowerDetailsAsync(userId, mealPlanId);

                if (follower == null)
                {
                    TempData["Error"] = "You are not following this meal plan.";
                    return RedirectToAction("Index", "MealPlan");
                }

                // Only show consent form if they haven't given consent yet
                if (follower.ConsentGivenAt != null)
                {
                    TempData["Info"] = "You have already provided your consent for this plan.";
                    return RedirectToAction("ActiveMealPlans", "MealPlanFollower");
                }

                // Calculate DaysCount
                var daysCount = follower.MealPlan?.MealPlanDays?.Count(d => !d.Deleted) ?? 0;

                var viewModel = new CompletionConsentViewModel
                {
                    MealPlanId = mealPlanId,
                    MealPlanName = follower.MealPlan?.Name ?? "Meal Plan",
                    DaysCount = daysCount,
                    StartedAt = follower.StartedAt,
                    Status = follower.Status,
                    CompletedAt = follower.CompletedAt
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred loading the consent form.";
                return RedirectToAction("ActiveMealPlans", "MealPlanFollower");
            }
        }

        /// <summary>
        /// Processes completion consent form submission.
        /// POST: /MealPlanFollower/CompletionConsent
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompletionConsent(CompletionConsentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            try
            {
                // Save consent choices
                var consentSaved = await _mealPlanFollowerService.SaveCompletionConsentsAsync(
                    userId,
                    model.MealPlanId,
                    model.ShowOnProfileAsCompleted,
                    model.ShareJournalPublicly
                );

                if (!consentSaved)
                {
                    TempData["Error"] = "Failed to save your consent choices.";
                    return View(model);
                }

                // If user consented to share journal publicly, bulk update all entry visibility
                if (model.ShareJournalPublicly)
                {
                    await _mealEntryService.BulkUpdateVisibilityForMealPlanAsync(
                        userId,
                        model.MealPlanId,
                        isPublic: true
                    );

                    await _mealPlanDayEntryService.BulkUpdateVisibilityForMealPlanAsync(
                        userId,
                        model.MealPlanId,
                        isPublic: true
                    );
                }

                TempData["Success"] = model.ShareJournalPublicly
                    ? "Thank you for sharing your journey! Your progress is now visible to inspire others."
                    : "Your privacy choices have been saved. Your journal entries remain private.";

                return RedirectToAction("ActiveMealPlans", "MealPlanFollower");
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred while saving your choices.";
                return View(model);
            }
        }



        // ========== MEAL LOGGING ACTIONS ==========

        /// <summary>
        /// Shows meal logging form
        /// GET: /MealPlanFollower/LogMeal/{mealId}
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LogMeal(Guid mealId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            try
            {
                // Get existing entry if any
                var existingEntry = await _mealEntryService.GetEntryAsync(user.Id, mealId);

                var viewModel = new LogMealViewModel
                {
                    MealId = mealId,
                    FeelingComment = existingEntry?.FeelingComment,
                    PhotoUrl = existingEntry?.PhotoUrl,
                    ConsumedAt = existingEntry?.ConsumedAt
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred loading the meal log form.";
                return RedirectToAction("FollowingDashboard");
            }
        }

        /// <summary>
        /// Processes meal logging form submission
        /// POST: /MealPlanFollower/LogMeal
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogMeal(LogMealViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            try
            {
                string? photoUrl = model.PhotoUrl; // Keep existing if no new photo

                // Upload new photo if provided
                if (model.PhotoFile != null)
                {
                    // Delete old photo if exists
                    if (!string.IsNullOrEmpty(model.PhotoUrl))
                    {
                        await _fileUploadService.DeleteFileAsync(model.PhotoUrl);
                    }

                    // Upload new photo
                    photoUrl = await _fileUploadService.UploadImageAsync(model.PhotoFile, "meal-entries");

                    if (photoUrl == null)
                    {
                        ModelState.AddModelError("PhotoFile", "Invalid image file. Please upload a valid image (max 5MB).");
                        return View(model);
                    }
                }

                // Save meal entry
                var entry = await _mealEntryService.UpsertMealEntryAsync(
                    user.Id,
                    model.MealId,
                    model.FeelingComment,
                    photoUrl

                );

                if (entry == null)
                {
                    TempData["Error"] = "Failed to save meal entry.";
                    return View(model);
                }

                TempData["Success"] = "Meal logged successfully!";
                return RedirectToAction("FollowingDashboard");
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred while saving the meal entry.";
                return View(model);
            }
        }

        // ========== DAY REFLECTION ACTIONS ==========

        /// <summary>
        /// Shows day reflection form
        /// GET: /MealPlanFollower/LogDayReflection/{mealPlanDayId}
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LogDayReflection(Guid mealPlanDayId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            try
            {
                // Get existing entry if any
                var existingEntry = await _mealPlanDayEntryService.GetEntryAsync(user.Id, mealPlanDayId);

                var viewModel = new LogDayReflectionViewModel
                {
                    MealPlanDayId = mealPlanDayId,
                    OverallFeeling = existingEntry?.OverallFeeling,
                    CompletedAt = existingEntry?.CompletedAt
                };

                return View(viewModel);
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred loading the reflection form.";
                return RedirectToAction("FollowingDashboard");
            }
        }

        /// <summary>
        /// Processes day reflection form submission
        /// POST: /MealPlanFollower/LogDayReflection
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogDayReflection(LogDayReflectionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            try
            {
                var entry = await _mealPlanDayEntryService.UpsertDayEntryAsync(
                    user.Id,
                    model.MealPlanDayId,
                    model.OverallFeeling

                );

                if (entry == null)
                {
                    TempData["Error"] = "Failed to save day reflection.";
                    return View(model);
                }

                TempData["Success"] = "Day reflection saved successfully!";
                return RedirectToAction("FollowingDashboard");
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred while saving the reflection.";
                return View(model);
            }
        }

        /// <summary>
        /// Marks plan as complete and redirects to consent form.
        /// POST: /MealPlanFollower/CompletePlan/{id}
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompletePlan(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            try
            {

                var follower = await _mealPlanFollowerService.GetFollowerDetailsAsync(user.Id, id);

                if (follower == null)
                {
                    TempData["Error"] = "You are not following this meal plan.";
                    return RedirectToAction("FollowingDashboard");
                }

                var success = await _mealPlanFollowerService.CompleteMealPlanAsync(user.Id, id);

                if (success)
                {
                    TempData["SuccessMessage"] = "Congratulations! You've completed this meal plan!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Could not mark meal plan as completed.";
                }

                // Update status to Completed
                follower.Status = Data.Enums.MealPlanFollowerStatus.Completed;
                follower.CompletedAt = DateTime.UtcNow;
                follower.IsActive = false;
                follower.UpdatedAt = DateTime.UtcNow;

                await _mealPlanFollowerService.UpdateFollowerAsync(follower);

                // Redirect to consent form
                return RedirectToAction("CompletionConsent", new { mealPlanId = id });
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred while completing the plan.";
                return RedirectToAction("FollowingDashboard");
            }
        }

        /// <summary>
        /// Dismisses the completion alert without completing the plan.
        /// POST: /MealPlanFollower/DismissCompletionAlert/{id}
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DismissCompletionAlert(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            try
            {
                var follower = await _mealPlanFollowerService.GetFollowerDetailsAsync(user.Id, id);

                if (follower == null)
                {
                    TempData["Error"] = "You are not following this meal plan.";
                    return RedirectToAction("FollowingDashboard");
                }

                await _mealPlanFollowerService.MarkCompletionPromptSeenAsync(user.Id, id);

                TempData["Info"] = "You can mark the plan as complete whenever you're ready.";
                return RedirectToAction("FollowingDashboard");
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred.";
                return RedirectToAction("FollowingDashboard");
            }
        }
    }
}
