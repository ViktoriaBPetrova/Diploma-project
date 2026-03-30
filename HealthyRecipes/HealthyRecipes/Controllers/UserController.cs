using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Helpers;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Services.Allergies;
using HealthyRecipes.Services.Users;
using HealthyRecipes.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyRecipes.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUser _userService;
        private readonly IAllergy _allergyService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IActivityLog _activityLogService;
        private readonly IContentFilter _contentFilterService;
        private readonly IFlaggedContent _flaggedContentService;
        private readonly ActivityLogHelper _activityLogHelper;

        public UserController(
            IUser userService,
            IAllergy allergyService,
            UserManager<ApplicationUser> userManager,
            IActivityLog activityLogService,
            IContentFilter contentFilterService,
            IFlaggedContent flaggedContentService,
            ActivityLogHelper activityLogHelper)
        {
            _userService = userService;
            _allergyService = allergyService;
            _userManager = userManager;
            _activityLogService = activityLogService;
            _contentFilterService = contentFilterService;
            _flaggedContentService = flaggedContentService;
            _activityLogHelper = activityLogHelper;
        }

        // GET: /User/Profile/{id?}
        public async Task<IActionResult> Profile(Guid? id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var profileId = id ?? currentUser!.Id;
            var user = await _userService.GetUserByIdAsync(profileId);
            if (user == null) return NotFound();

            var allergies = await _allergyService.GetAllergiesByUserAsync(profileId);

            var vm = new UserProfileViewModel
            {
                Id = user.Id,
                UserName = user.UserName ?? "",
                FirstName = user.FirstName,
                LastName = user.LastName,
                Bio = user.Bio,
                ImageUrl = user.ImageUrl,
                Height = user.Height,
                Weight = user.Weight,
                ProteinGoal = user.ProteinGoal,
                CarbsGoal = user.CarbsGoal,
                FatGoal = user.FatGoal,
                CalorieGoal = user.Calories,
                RecipeCount = user.CreatedRecipes?.Count() ?? 0,
                MealPlanCount = user.CreatedMealPlans?.Count() ?? 0,
                IsCurrentUser = profileId == currentUser!.Id,
                Allergies = allergies.Select(a => new AllergyViewModel
                {
                    IngredientId = a.IngredientId,
                    IngredientName = a.Ingredient?.Name ?? ""
                })
            };

            return View(vm);
        }

        // GET: /User/Edit
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            var vm = new EditProfileViewModel
            {
                FirstName = user!.FirstName,
                LastName = user.LastName,
                Bio = user.Bio,
                ImageUrl = user.ImageUrl,
                Height = user.Height,
                Weight = user.Weight,
                ProteinGoal = user.ProteinGoal,
                CarbsGoal = user.CarbsGoal,
                FatGoal = user.FatGoal,
                CalorieGoal = user.Calories
            };
            return View(vm);
        }

        // POST: /User/Edit
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProfileViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = await _userManager.GetUserAsync(User);

            // CAPTURE OLD VALUES for activity logging
            var oldValues = new
            {
                user!.FirstName,
                user.LastName,
                user.Bio,
                user.Height,
                user.Weight,
                user.ProteinGoal,
                user.CarbsGoal,
                user.FatGoal,
                Calories = user.Calories
            };

            // CHECK FOR BANNED WORDS in Bio
            if (!string.IsNullOrWhiteSpace(vm.Bio))
            {
                var filterResult = await _contentFilterService.CheckContentAsync(vm.Bio);

                if (filterResult.ContainsBannedWords)
                {
                    // Log banned word detection
                    await _activityLogHelper.LogBannedWordDetectedAsync(
                        user.Id,
                        "UserBio",
                        user.Id,
                        string.Join(", ", filterResult.MatchedWords));

                    // Auto-block high severity
                    if (filterResult.ShouldAutoBlock)
                    {
                        TempData["Error"] = "Your bio contains prohibited content and cannot be saved.";
                        return View(vm);
                    }

                    // Flag medium severity
                    if (filterResult.ShouldFlagForReview)
                    {
                        await _flaggedContentService.FlagContentAsync(
                            contentType: "UserBio",
                            contentId: user.Id,
                            contentPreview: vm.Bio.Length > 200 ? vm.Bio.Substring(0, 200) : vm.Bio,
                            contentAuthorId: user.Id,
                            reason: FlagReason.BannedWords,
                            details: $"Auto-flagged by content filter. Severity: {filterResult.HighestSeverity}",
                            reportedByUserId: null,
                            matchedBannedWords: string.Join(", ", filterResult.MatchedWords));

                        TempData["Warning"] = "Your bio has been flagged for review.";
                    }
                }
            }

            // Update user properties
            user.FirstName = vm.FirstName;
            user.LastName = vm.LastName;
            user.Bio = vm.Bio;
            user.ImageUrl = vm.ImageUrl;
            user.Height = vm.Height;
            user.Weight = vm.Weight;
            user.ProteinGoal = vm.ProteinGoal;
            user.CarbsGoal = vm.CarbsGoal;
            user.FatGoal = vm.FatGoal;
            user.Calories = vm.CalorieGoal;

            await _userService.UpdateUserAsync(user);

            // CAPTURE NEW VALUES and LOG ACTIVITY
            var newValues = new
            {
                user.FirstName,
                user.LastName,
                user.Bio,
                user.Height,
                user.Weight,
                user.ProteinGoal,
                user.CarbsGoal,
                user.FatGoal,
                Calories = user.Calories
            };

            // Build change summary
            var changes = new List<string>();
            if (oldValues.FirstName != newValues.FirstName || oldValues.LastName != newValues.LastName)
                changes.Add("Name updated");
            if (oldValues.Bio != newValues.Bio)
                changes.Add("Bio updated");
            if (oldValues.Height != newValues.Height || oldValues.Weight != newValues.Weight)
                changes.Add("Body metrics updated");
            if (oldValues.ProteinGoal != newValues.ProteinGoal ||
                oldValues.CarbsGoal != newValues.CarbsGoal ||
                oldValues.FatGoal != newValues.FatGoal ||
                oldValues.Calories != newValues.Calories)
                changes.Add("Nutrition goals updated");

            if (changes.Any())
            {
                await _activityLogService.LogAsync(
                    userId: user.Id,
                    activityType: Data.Entities.Admin.ActivityType.Update,
                    entityType: "UserProfile",
                    entityId: user.Id,
                    entityName: user.UserName ?? "User",
                    oldValue: System.Text.Json.JsonSerializer.Serialize(oldValues),
                    newValue: System.Text.Json.JsonSerializer.Serialize(newValues),
                    changesSummary: string.Join(", ", changes),
                    severity: LogSeverity.Low);
            }

            TempData["Success"] = "Profile updated successfully";
            return RedirectToAction(nameof(Profile));
        }

        // POST: /User/RemoveAllergy
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveAllergy(Guid ingredientId)
        {
            var user = await _userManager.GetUserAsync(User);
            await _allergyService.RemoveAllergyAsync(user!.Id, ingredientId);

            // LOG ACTIVITY (optional - less critical than other actions)
            // Uncomment to track allergy removals
            /*
            await _activityLogService.LogAsync(
                userId: user.Id,
                activityType: Data.Entities.Admin.ActivityType.Delete,
                entityType: "Allergy",
                entityId: ingredientId,
                entityName: "Allergy Removed",
                changesSummary: "User removed an allergy",
                severity: LogSeverity.Info);
            */

            return RedirectToAction(nameof(Profile));
        }
    }
}
