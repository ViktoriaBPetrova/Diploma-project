using HealthyRecipes.Data.Entities.MappingEntities;

namespace HealthyRecipes.Services.Allergies
{
    public interface IAllergy
    {
        Task AddAllergyAsync(Guid userId, Guid ingredientId);
        Task<IEnumerable<Allergy>> GetAllergiesByUserAsync(Guid userId);
        Task<bool> RemoveAllergyAsync(Guid userId, Guid ingredientId);
        Task<bool> HasAllergyAsync(Guid userId, Guid ingredientId);
    }
}
