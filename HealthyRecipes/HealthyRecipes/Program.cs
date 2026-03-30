using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Admin;
using HealthyRecipes.Services.Admin.Helpers;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Services.Allergies;
using HealthyRecipes.Services.Api;
using HealthyRecipes.Services.Categories;
using HealthyRecipes.Services.CommentRatings;
using HealthyRecipes.Services.FileUploads;
using HealthyRecipes.Services.GroceryLists;
using HealthyRecipes.Services.Ingredients;
using HealthyRecipes.Services.MealEntries;
using HealthyRecipes.Services.MealPlanDayEntries;
using HealthyRecipes.Services.MealPlanDays;
using HealthyRecipes.Services.MealPlanFollowers;
using HealthyRecipes.Services.MealPlans;
using HealthyRecipes.Services.Meals;
using HealthyRecipes.Services.RecipeCategories;
using HealthyRecipes.Services.RecipeIngredients;
using HealthyRecipes.Services.RecipeMeals;
using HealthyRecipes.Services.Recipes;
using HealthyRecipes.Services.Recommendations;
using HealthyRecipes.Services.SavedMealPlans;
using HealthyRecipes.Services.SavedRecipes;
using HealthyRecipes.Services.Statistics;
using HealthyRecipes.Services.Statistics.Interfaces;
using HealthyRecipes.Services.Statistics.Services;
using HealthyRecipes.Services.StoreApis;
using HealthyRecipes.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// ─── Database ────────────────────────────────────────────────────────────────
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<HealthyRecipesDbContext>(options =>
    options.UseSqlServer(connectionString,
        sqlOptions => sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// ─── Identity ────────────────────────────────────────────────────────────────
/*builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddRoles<IdentityRole<Guid>>()
.AddEntityFrameworkStores<HealthyRecipesDbContext>();*/

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddRoles<IdentityRole<Guid>>()
.AddEntityFrameworkStores<HealthyRecipesDbContext>()
.AddDefaultUI()//should i keep there ***
.AddDefaultTokenProviders();//***

// ─── MVC ─────────────────────────────────────────────────────────────────────
builder.Services.AddControllersWithViews();

// ─── External API ─────────────────────────────────────────────────────────────
builder.Services.AddHttpClient<IApi, ApiService>(client => //A bIg pROBlEM ask MISTUR
{
    client.BaseAddress = new Uri("https://world.openfoodfacts.org/");
    client.DefaultRequestHeaders.Add("User-Agent", "HealthyRecipesApp"); // Optional but recommended
    client.Timeout = TimeSpan.FromSeconds(30); // Optional
});

// ─── Application Services ─────────────────────────────────────────────────────
builder.Services.AddScoped<IRecipe, RecipeService>();
builder.Services.AddScoped<IIngredient, IngredientService>();
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IMealPlan, MealPlanService>();
builder.Services.AddScoped<IMealPlanDay, MealPlanDayService>();
builder.Services.AddScoped<IMeal, MealService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IAllergy, AllergyService>();
builder.Services.AddScoped<ICommentRating, CommentRatingService>();
builder.Services.AddScoped<ISavedRecipe, SavedRecipeService>();
builder.Services.AddScoped<ISavedMealPlan, SavedMealPlanService>();
builder.Services.AddScoped<IRecipeIngredient, RecipeIngredientService>();
builder.Services.AddScoped<IRecipeCategory, RecipeCategoryService>();
builder.Services.AddScoped<IRecipeMeal, RecipeMealService>();
builder.Services.AddScoped<IRecipeStatistics, RecipeStatisticsService>();
builder.Services.AddScoped<IMealPlanStatistics, MealPlanStatisticsService>();
builder.Services.AddScoped<IUserStatistics, UserStatisticsService>();
builder.Services.AddScoped<IMealPlanFollower, MealPlanFollowerService>();
builder.Services.AddScoped<IMealEntry, MealEntryService>();
builder.Services.AddScoped<IMealPlanDayEntry, MealPlanDayEntryService>();
builder.Services.AddScoped<IRecommendation, RecommendationService>();
builder.Services.AddScoped<IFileUpload, FileUploadService>();
// Admin Moderation Services
builder.Services.AddScoped<IActivityLog, ActivityLogService>();
builder.Services.AddScoped<IContentFilter, ContentFilterService>();
builder.Services.AddScoped<IFlaggedContent, FlaggedContentService>();
builder.Services.AddScoped<IUserModeration, UserModerationService>();
builder.Services.AddScoped<ActivityLogHelper>();
// Required for activity logging
builder.Services.AddHttpContextAccessor();
//GroceryList API
builder.Services.AddScoped<IGroceryList, GroceryListService>();
builder.Services.AddScoped<MockStoreApiService>();
builder.Services.AddScoped<PriceBarometerApiService>();
builder.Services.AddHttpClient<PriceBarometerApiService>();
builder.Services.AddScoped<HybridStoreApiService>();
// OPTION C: Hybrid (RECOMMENDED - automatic fallback) (tries real API, falls back to mock)
builder.Services.AddScoped<IStoreApi, HybridStoreApiService>();
/*
// OPTION A: Mock Only (for testing without API)
builder.Services.AddScoped<IStoreApi, MockStoreApiService>();

// OPTION B: Real API Only (production, no fallback)
builder.Services.AddHttpClient<IStoreApi, SofiaSupermarketsApiService>();

// OPTION C: Hybrid (RECOMMENDED - automatic fallback) (tries real API, falls back to mock)
builder.Services.AddScoped<IStoreApi, HybridStoreApiService>();
*/

//Admin
builder.Services.AddRazorPages(); // Add this if not present

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

builder.Services.Configure<RazorPagesOptions>(options =>
{
    options.Conventions.AuthorizeAreaFolder("Admin", "/", "AdminOnly");
});

// ─── Pipeline ─────────────────────────────────────────────────────────────────
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


