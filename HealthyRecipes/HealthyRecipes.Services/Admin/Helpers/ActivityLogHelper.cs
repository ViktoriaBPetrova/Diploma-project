using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace HealthyRecipes.Services.Admin.Helpers
{
    /// <summary>
    /// Helper class to simplify activity logging from controllers
    /// </summary>
    public class ActivityLogHelper
    {
        private readonly IActivityLog _activityLogService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ActivityLogHelper(IActivityLog activityLogService, IHttpContextAccessor httpContextAccessor)
        {
            _activityLogService = activityLogService;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Log a recipe creation
        /// </summary>
        public async Task LogRecipeCreatedAsync(Guid userId, Guid recipeId, string recipeTitle)
        {
            await LogAsync(
                userId,
                ActivityType.Create,
                "Recipe",
                recipeId,
                recipeTitle,
                null,
                null,
                $"Created recipe: {recipeTitle}",
                LogSeverity.Info);
        }

        /// <summary>
        /// Log a recipe update
        /// </summary>
        public async Task LogRecipeUpdatedAsync(Guid userId, Guid recipeId, string recipeTitle, object oldValues, object newValues)
        {
            var changes = CompareObjects(oldValues, newValues);
            
            await LogAsync(
                userId,
                ActivityType.Update,
                "Recipe",
                recipeId,
                recipeTitle,
                JsonSerializer.Serialize(oldValues),
                JsonSerializer.Serialize(newValues),
                $"Updated recipe: {recipeTitle}. Changes: {changes}",
                LogSeverity.Low);
        }

        /// <summary>
        /// Log a recipe deletion
        /// </summary>
        public async Task LogRecipeDeletedAsync(Guid userId, Guid recipeId, string recipeTitle, bool isSoftDelete = true)
        {
            await LogAsync(
                userId,
                isSoftDelete ? ActivityType.SoftDelete : ActivityType.Delete,
                "Recipe",
                recipeId,
                recipeTitle,
                null,
                null,
                $"Deleted recipe: {recipeTitle}",
                LogSeverity.Medium);
        }

        /// <summary>
        /// Log a meal plan creation
        /// </summary>
        public async Task LogMealPlanCreatedAsync(Guid userId, Guid mealPlanId, string mealPlanName)
        {
            await LogAsync(
                userId,
                ActivityType.Create,
                "MealPlan",
                mealPlanId,
                mealPlanName,
                null,
                null,
                $"Created meal plan: {mealPlanName}",
                LogSeverity.Info);
        }

        /// <summary>
        /// Log a meal plan update
        /// </summary>
        public async Task LogMealPlanUpdatedAsync(Guid userId, Guid mealPlanId, string mealPlanName, string changeDescription)
        {
            await LogAsync(
                userId,
                ActivityType.Update,
                "MealPlan",
                mealPlanId,
                mealPlanName,
                null,
                null,
                $"Updated meal plan: {mealPlanName}. {changeDescription}",
                LogSeverity.Low);
        }

        /// <summary>
        /// Log a meal plan deletion
        /// </summary>
        public async Task LogMealPlanDeletedAsync(Guid userId, Guid mealPlanId, string mealPlanName)
        {
            await LogAsync(
                userId,
                ActivityType.SoftDelete,
                "MealPlan",
                mealPlanId,
                mealPlanName,
                null,
                null,
                $"Deleted meal plan: {mealPlanName}",
                LogSeverity.Medium);
        }

        /// <summary>
        /// Log a comment posted
        /// </summary>
        public async Task LogCommentPostedAsync(Guid userId, Guid commentId, Guid recipeId, string recipeTitle, bool containsBannedWords = false)
        {
            await LogAsync(
                userId,
                ActivityType.CommentPosted,
                "Comment",
                commentId,
                $"Comment on {recipeTitle}",
                null,
                null,
                $"Posted comment on recipe: {recipeTitle}",
                containsBannedWords ? LogSeverity.High : LogSeverity.Info);
        }

        /// <summary>
        /// Log banned word detection
        /// </summary>
        public async Task LogBannedWordDetectedAsync(Guid userId, string contentType, Guid contentId, string matchedWords)
        {
            await LogAsync(
                userId,
                ActivityType.BannedWordDetected,
                contentType,
                contentId,
                $"Banned words in {contentType}",
                null,
                null,
                $"Banned words detected: {matchedWords}",
                LogSeverity.High);
        }

        /// <summary>
        /// Log user ban
        /// </summary>
        public async Task LogUserBannedAsync(Guid adminUserId, Guid bannedUserId, string bannedUserEmail, string reason)
        {
            await LogAsync(
                adminUserId,
                ActivityType.UserBanned,
                "User",
                bannedUserId,
                bannedUserEmail,
                null,
                null,
                $"Banned user {bannedUserEmail}. Reason: {reason}",
                LogSeverity.Critical);
        }

        /// <summary>
        /// Generic log method with HTTP context info
        /// </summary>
        private async Task LogAsync(
            Guid userId,
            ActivityType activityType,
            string entityType,
            Guid? entityId,
            string entityName,
            string? oldValue,
            string? newValue,
            string? changesSummary,
            LogSeverity severity)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var ipAddress = httpContext?.Connection.RemoteIpAddress?.ToString();
            var userAgent = httpContext?.Request.Headers["User-Agent"].ToString();

            await _activityLogService.LogAsync(
                userId,
                activityType,
                entityType,
                entityId,
                entityName,
                oldValue,
                newValue,
                changesSummary,
                severity,
                ipAddress,
                userAgent);
        }

        /// <summary>
        /// Compare two objects and return a summary of changes
        /// </summary>
        private string CompareObjects(object oldObj, object newObj)
        {
            var changes = new List<string>();
            var oldProps = oldObj.GetType().GetProperties();
            var newProps = newObj.GetType().GetProperties();

            foreach (var oldProp in oldProps)
            {
                var newProp = newProps.FirstOrDefault(p => p.Name == oldProp.Name);
                if (newProp != null)
                {
                    var oldValue = oldProp.GetValue(oldObj);
                    var newValue = newProp.GetValue(newObj);

                    if (!Equals(oldValue, newValue))
                    {
                        changes.Add($"{oldProp.Name}: '{oldValue}' → '{newValue}'");
                    }
                }
            }

            return changes.Any() ? string.Join(", ", changes) : "No changes detected";
        }
    }
}
