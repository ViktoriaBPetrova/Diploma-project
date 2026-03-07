using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Allergies;
using HealthyRecipes.Services.Api;
using HealthyRecipes.Services.Categories;
using HealthyRecipes.Services.CommentRatings;
using HealthyRecipes.Services.Ingredients;
using HealthyRecipes.Services.MealPlanDays;
using HealthyRecipes.Services.MealPlans;
using HealthyRecipes.Services.Meals;
using HealthyRecipes.Services.RecipeCategories;
using HealthyRecipes.Services.RecipeIngredients;
using HealthyRecipes.Services.RecipeMeals;
using HealthyRecipes.Services.Recipes;
using HealthyRecipes.Services.SavedMealPlans;
using HealthyRecipes.Services.SavedRecipes;
using HealthyRecipes.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// ─── Database ────────────────────────────────────────────────────────────────
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<HealthyRecipesDbContext>(options =>
    options.UseSqlServer(connectionString));

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


