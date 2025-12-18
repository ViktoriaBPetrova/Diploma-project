using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Seeding.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.MappingSeeders.UserInfoSeedes
{
    public class AllergySeeder
    {
        public static ICollection<Allergy> GenerateAllergies()
        {
            DateTime seedingDate = new DateTime(2025, 12, 18);

            ICollection<Allergy> allergies = new HashSet<Allergy>()
            {
                // User allergies
                new Allergy(IngredientConstants.GarlicId, UserConstants.UserId, seedingDate),
                
            };

            return allergies;
        }
    }
}
