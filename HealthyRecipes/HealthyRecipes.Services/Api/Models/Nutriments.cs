using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Api.Models
{
    public class Nutriments
    {
        public decimal Energy100g { get; set; }
        public decimal Fat100g { get; set; }
        public decimal Carbohydrates100g { get; set; }
        public decimal Proteins100g { get; set; }
        public decimal Salt100g { get; set; }
    }
}
