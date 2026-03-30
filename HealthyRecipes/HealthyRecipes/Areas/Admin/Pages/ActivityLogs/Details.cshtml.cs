using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace HealthyRecipes.Web.Areas.Admin.Pages.ActivityLogs
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly HealthyRecipesDbContext _context;

        public DetailsModel(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public ActivityLogDetailsViewModel ViewModel { get; set; } = new();
        public Dictionary<string, string> OldValuesParsed { get; set; } = new();
        public Dictionary<string, string> NewValuesParsed { get; set; } = new();
        public List<ChangeDetail> Changes { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var log = await _context.ActivityLogs
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (log == null)
                return NotFound();

            ViewModel = new ActivityLogDetailsViewModel
            {
                Id = log.Id,
                UserName = log.User?.UserName ?? "System",
                UserEmail = log.User?.Email ?? "N/A",
                ActivityType = log.ActivityType,
                EntityType = log.EntityType,
                EntityId = log.EntityId,
                EntityName = log.EntityName,
                OldValue = log.OldValue,
                NewValue = log.NewValue,
                ChangesSummary = log.ChangesSummary,
                Severity = log.Severity,
                IpAddress = log.IpAddress,
                UserAgent = log.UserAgent,
                CreatedAt = log.CreatedAt
            };

            // Parse old and new values if they exist
            if (!string.IsNullOrEmpty(log.OldValue))
            {
                OldValuesParsed = ParseJsonValue(log.OldValue);
            }

            if (!string.IsNullOrEmpty(log.NewValue))
            {
                NewValuesParsed = ParseJsonValue(log.NewValue);
            }

            // Generate change details for side-by-side comparison
            if (OldValuesParsed.Any() || NewValuesParsed.Any())
            {
                Changes = GenerateChangeDetails(OldValuesParsed, NewValuesParsed);
            }

            return Page();
        }

        private Dictionary<string, string> ParseJsonValue(string json)
        {
            try
            {
                var result = new Dictionary<string, string>();
                var jsonDoc = JsonDocument.Parse(json);

                foreach (var property in jsonDoc.RootElement.EnumerateObject())
                {
                    var value = property.Value.ValueKind switch
                    {
                        JsonValueKind.String => property.Value.GetString() ?? "",
                        JsonValueKind.Number => property.Value.GetDouble().ToString(),
                        JsonValueKind.True => "True",
                        JsonValueKind.False => "False",
                        JsonValueKind.Null => "(null)",
                        _ => property.Value.ToString()
                    };
                    result[property.Name] = value;
                }

                return result;
            }
            catch
            {
                // If parsing fails, return the raw JSON
                return new Dictionary<string, string> { { "Raw Value", json } };
            }
        }

        private List<ChangeDetail> GenerateChangeDetails(
            Dictionary<string, string> oldValues,
            Dictionary<string, string> newValues)
        {
            var changes = new List<ChangeDetail>();
            var allKeys = oldValues.Keys.Union(newValues.Keys).Distinct();

            foreach (var key in allKeys)
            {
                var oldValue = oldValues.ContainsKey(key) ? oldValues[key] : "(not set)";
                var newValue = newValues.ContainsKey(key) ? newValues[key] : "(not set)";

                // Determine if this field changed
                var hasChanged = oldValue != newValue;

                changes.Add(new ChangeDetail
                {
                    FieldName = FormatFieldName(key),
                    OldValue = oldValue,
                    NewValue = newValue,
                    HasChanged = hasChanged
                });
            }

            return changes.OrderByDescending(c => c.HasChanged).ToList();
        }

        private string FormatFieldName(string fieldName)
        {
            // Convert camelCase or PascalCase to "Title Case"
            // e.g., "FirstName" -> "First Name", "calorieGoal" -> "Calorie Goal"
            return System.Text.RegularExpressions.Regex.Replace(
                fieldName,
                "([a-z])([A-Z])",
                "$1 $2");
        }
    }

    // Helper class for change details
    public class ChangeDetail
    {
        public string FieldName { get; set; } = string.Empty;
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
        public bool HasChanged { get; set; }
    }
}
