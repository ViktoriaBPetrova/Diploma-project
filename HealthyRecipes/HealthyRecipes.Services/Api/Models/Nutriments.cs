using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Api.Models
{
    public class Nutriments
    {
        [JsonPropertyName("energy-kcal_100g")]
        public float EnergyKcal100g { get; set; }

        [JsonPropertyName("proteins_100g")]
        public float Proteins100g { get; set; }

        [JsonPropertyName("carbohydrates_100g")]
        public float Carbohydrates100g { get; set; }

        [JsonPropertyName("fat_100g")]
        public float Fat100g { get; set; }
    }
}
