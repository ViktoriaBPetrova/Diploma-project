// ─── Add these using statements to Program.cs ───────────────────────────────
// using HealthyRecipes.Services.Allergies;
// using HealthyRecipes.Services.CommentRatings;
// using HealthyRecipes.Services.Meals;
// using HealthyRecipes.Services.MealPlanDays;
// using HealthyRecipes.Services.RecipeCategories;
// using HealthyRecipes.Services.RecipeIngredients;
// using HealthyRecipes.Services.RecipeMeals;
// using HealthyRecipes.Services.SavedMealPlans;
// using HealthyRecipes.Services.SavedRecipes;

// ─── Add these lines in Program.cs after your existing service registrations ─

builder.Services.AddScoped<IIngredient, IngredientService>();
builder.Services.AddScoped<IMeal, MealService>();
builder.Services.AddScoped<IMealPlanDay, MealPlanDayService>();
builder.Services.AddScoped<IAllergy, AllergyService>();
builder.Services.AddScoped<ICommentRating, CommentRatingService>();
builder.Services.AddScoped<ISavedRecipe, SavedRecipeService>();
builder.Services.AddScoped<ISavedMealPlan, SavedMealPlanService>();
builder.Services.AddScoped<IRecipeIngredient, RecipeIngredientService>();
builder.Services.AddScoped<IRecipeCategory, RecipeCategoryService>();
builder.Services.AddScoped<IRecipeMeal, RecipeMealService>();
