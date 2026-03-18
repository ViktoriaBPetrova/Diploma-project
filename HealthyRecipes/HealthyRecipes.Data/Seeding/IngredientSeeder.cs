using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Seeding.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding
{
    public class IngredientSeeder
    {
        public static ICollection<Ingredient> GenerateIngredients()
        {
            DateTime seedingDate = new DateTime(2025, 12, 18);

            ICollection<Ingredient> ingredients = new List<Ingredient>()
            {
            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.ChickenBreastId),
                IngredientConstants.ChickenBreastCaloriesPer100g,
                IngredientConstants.ChickenBreastFatPer100g,
                IngredientConstants.ChickenBreastCarbsPer100g,
                IngredientConstants.ChickenBreastProteinPer100g)
            {
                Name = IngredientConstants.ChickenBreastName,
                Brand = IngredientConstants.ChickenBreastBrand,
                Source = IngredientConstants.ChickenBreastSource
            },

            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.WhiteRiceId),
                IngredientConstants.WhiteRiceCaloriesPer100g,
                IngredientConstants.WhiteRiceFatPer100g,
                IngredientConstants.WhiteRiceCarbsPer100g,
                IngredientConstants.WhiteRiceProteinPer100g)
            {
                Name = IngredientConstants.WhiteRiceName,
                Brand = IngredientConstants.WhiteRiceBrand,
                Source = IngredientConstants.WhiteRiceSource
            },

            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.OliveOilId),
                IngredientConstants.OliveOilCaloriesPer100g,
                IngredientConstants.OliveOilFatPer100g,
                IngredientConstants.OliveOilCarbsPer100g,
                IngredientConstants.OliveOilProteinPer100g)
            {
                Name = IngredientConstants.OliveOilName,
                Brand = IngredientConstants.OliveOilBrand,
                Source = IngredientConstants.OliveOilSource
            },

            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.OnionId),
                IngredientConstants.OnionCaloriesPer100g,
                IngredientConstants.OnionFatPer100g,
                IngredientConstants.OnionCarbsPer100g,
                IngredientConstants.OnionProteinPer100g)
            {
                Name = IngredientConstants.OnionName,
                Brand = IngredientConstants.OnionBrand,
                Source = IngredientConstants.OnionSource
            },

            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.GarlicId),
                IngredientConstants.GarlicCaloriesPer100g,
                IngredientConstants.GarlicFatPer100g,
                IngredientConstants.GarlicCarbsPer100g,
                IngredientConstants.GarlicProteinPer100g)
            {
                Name = IngredientConstants.GarlicName,
                Brand = IngredientConstants.GarlicBrand,
                Source = IngredientConstants.GarlicSource
            },

            // New ingredients
            //proteins
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.SalmonId),
                    IngredientConstants.SalmonCaloriesPer100g,
                    IngredientConstants.SalmonFatPer100g,
                    IngredientConstants.SalmonCarbsPer100g,
                    IngredientConstants.SalmonProteinPer100g)
                {
                    Name = IngredientConstants.SalmonName,
                    Brand = IngredientConstants.SalmonBrand,
                    Source = IngredientConstants.SalmonSource
                },
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.EggsId),
                    IngredientConstants.EggsCaloriesPer100g,
                    IngredientConstants.EggsFatPer100g,
                    IngredientConstants.EggsCarbsPer100g,
                    IngredientConstants.EggsProteinPer100g)
                {
                    Name = IngredientConstants.EggsName,
                    Brand = IngredientConstants.EggsBrand,
                    Source = IngredientConstants.EggsSource
                },
                //grains
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.QuinoaId),
                    IngredientConstants.QuinoaCaloriesPer100g,
                    IngredientConstants.QuinoaFatPer100g,
                    IngredientConstants.QuinoaCarbsPer100g,
                    IngredientConstants.QuinoaProteinPer100g)
                {
                    Name = IngredientConstants.QuinoaName,
                    Brand = IngredientConstants.QuinoaBrand,
                    Source = IngredientConstants.QuinoaSource
                },
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.BrownRiceId),
                    IngredientConstants.BrownRiceCaloriesPer100g,
                    IngredientConstants.BrownRiceFatPer100g,
                    IngredientConstants.BrownRiceCarbsPer100g,
                    IngredientConstants.BrownRiceProteinPer100g)
                {
                    Name = IngredientConstants.BrownRiceName,
                    Brand = IngredientConstants.BrownRiceBrand,
                    Source = IngredientConstants.BrownRiceSource
                },
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.OatsId),
                    IngredientConstants.OatsCaloriesPer100g,
                    IngredientConstants.OatsFatPer100g,
                    IngredientConstants.OatsCarbsPer100g,
                    IngredientConstants.OatsProteinPer100g)
                {
                    Name = IngredientConstants.OatsName,
                    Brand = IngredientConstants.OatsBrand,
                    Source = IngredientConstants.OatsSource
                },
                //veggies
                 new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.CucumberId),
                    IngredientConstants.CucumberCaloriesPer100g,
                    IngredientConstants.CucumberFatPer100g,
                    IngredientConstants.CucumberCarbsPer100g,
                    IngredientConstants.CucumberProteinPer100g)
                {
                    Name = IngredientConstants.CucumberName,
                    Brand = IngredientConstants.CucumberBrand,
                    Source = IngredientConstants.CucumberSource
                },

                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.ParsleyId),
                    IngredientConstants.ParsleyCaloriesPer100g,
                    IngredientConstants.ParsleyFatPer100g,
                    IngredientConstants.ParsleyCarbsPer100g,
                    IngredientConstants.ParsleyProteinPer100g)
                {
                    Name = IngredientConstants.ParsleyName,
                    Brand = IngredientConstants.ParsleyBrand,
                    Source = IngredientConstants.ParsleySource
                },
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.SweetPotatoId),
                    IngredientConstants.SweetPotatoCaloriesPer100g,
                    IngredientConstants.SweetPotatoFatPer100g,
                    IngredientConstants.SweetPotatoCarbsPer100g,
                    IngredientConstants.SweetPotatoProteinPer100g)
                {
                    Name = IngredientConstants.SweetPotatoName,
                    Brand = IngredientConstants.SweetPotatoBrand,
                    Source = IngredientConstants.SweetPotatoSource
                },
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.SpinachId),
                    IngredientConstants.SpinachCaloriesPer100g,
                    IngredientConstants.SpinachFatPer100g,
                    IngredientConstants.SpinachCarbsPer100g,
                    IngredientConstants.SpinachProteinPer100g)
                {
                    Name = IngredientConstants.SpinachName,
                    Brand = IngredientConstants.SpinachBrand,
                    Source = IngredientConstants.SpinachSource
                },
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.BroccoliId),
                    IngredientConstants.BroccoliCaloriesPer100g,
                    IngredientConstants.BroccoliFatPer100g,
                    IngredientConstants.BroccoliCarbsPer100g,
                    IngredientConstants.BroccoliProteinPer100g)
                {
                    Name = IngredientConstants.BroccoliName,
                    Brand = IngredientConstants.BroccoliBrand,
                    Source = IngredientConstants.BroccoliSource
                },
                 new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.TomatoId),
                    IngredientConstants.TomatoCaloriesPer100g,
                    IngredientConstants.TomatoFatPer100g,
                    IngredientConstants.TomatoCarbsPer100g,
                    IngredientConstants.TomatoProteinPer100g)
                {
                    Name = IngredientConstants.TomatoName,
                    Brand = IngredientConstants.TomatoBrand,
                    Source = IngredientConstants.TomatoSource
                },

                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.BellPepperId),
                    IngredientConstants.BellPepperCaloriesPer100g,
                    IngredientConstants.BellPepperFatPer100g,
                    IngredientConstants.BellPepperCarbsPer100g,
                    IngredientConstants.BellPepperProteinPer100g)
                {
                    Name = IngredientConstants.BellPepperName,
                    Brand = IngredientConstants.BellPepperBrand,
                    Source = IngredientConstants.BellPepperSource
                },
                //fruits
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.LemonId),
                    IngredientConstants.LemonCaloriesPer100g,
                    IngredientConstants.LemonFatPer100g,
                    IngredientConstants.LemonCarbsPer100g,
                    IngredientConstants.LemonProteinPer100g)
                {
                    Name = IngredientConstants.LemonName,
                    Brand = IngredientConstants.LemonBrand,
                    Source = IngredientConstants.LemonSource
                },
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.BananaId),
                    IngredientConstants.BananaCaloriesPer100g,
                    IngredientConstants.BananaFatPer100g,
                    IngredientConstants.BananaCarbsPer100g,
                    IngredientConstants.BananaProteinPer100g)
                {
                    Name = IngredientConstants.BananaName,
                    Brand = IngredientConstants.BananaBrand,
                    Source = IngredientConstants.BananaSource
                },
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.BlueberriesId),
                    IngredientConstants.BlueberriesCaloriesPer100g,
                    IngredientConstants.BlueberriesFatPer100g,
                    IngredientConstants.BlueberriesCarbsPer100g,
                    IngredientConstants.BlueberriesProteinPer100g)
                {
                    Name = IngredientConstants.BlueberriesName,
                    Brand = IngredientConstants.BlueberriesBrand,
                    Source = IngredientConstants.BlueberriesSource
                },
                //healthy fats
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.AvocadoId),
                    IngredientConstants.AvocadoCaloriesPer100g,
                    IngredientConstants.AvocadoFatPer100g,
                    IngredientConstants.AvocadoCarbsPer100g,
                    IngredientConstants.AvocadoProteinPer100g)
                {
                    Name = IngredientConstants.AvocadoName,
                    Brand = IngredientConstants.AvocadoBrand,
                    Source = IngredientConstants.AvocadoSource
                },   
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.AlmondsId),
                    IngredientConstants.AlmondsCaloriesPer100g,
                    IngredientConstants.AlmondsFatPer100g,
                    IngredientConstants.AlmondsCarbsPer100g,
                    IngredientConstants.AlmondsProteinPer100g)
                {
                    Name = IngredientConstants.AlmondsName,
                    Brand = IngredientConstants.AlmondsBrand,
                    Source = IngredientConstants.AlmondsSource
                },
               new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.CoconutOilId),
                    IngredientConstants.CoconutOilCaloriesPer100g,
                    IngredientConstants.CoconutOilFatPer100g,
                    IngredientConstants.CoconutOilCarbsPer100g,
                    IngredientConstants.CoconutOilProteinPer100g)
                {
                    Name = IngredientConstants.CoconutOilName,
                    Brand = IngredientConstants.CoconutOilBrand,
                    Source = IngredientConstants.CoconutOilSource
                },
               new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.PeanutButterId),
                    IngredientConstants.PeanutButterCaloriesPer100g,
                    IngredientConstants.PeanutButterFatPer100g,
                    IngredientConstants.PeanutButterCarbsPer100g,
                    IngredientConstants.PeanutButterProteinPer100g)
                {
                    Name = IngredientConstants.PeanutButterName,
                    Brand = IngredientConstants.PeanutButterBrand,
                    Source = IngredientConstants.PeanutButterSource
                },
               //other
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.HoneyId),
                    IngredientConstants.HoneyCaloriesPer100g,
                    IngredientConstants.HoneyFatPer100g,
                    IngredientConstants.HoneyCarbsPer100g,
                    IngredientConstants.HoneyProteinPer100g)
                {
                    Name = IngredientConstants.HoneyName,
                    Brand = IngredientConstants.HoneyBrand,
                    Source = IngredientConstants.HoneySource
                },
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.GreekYogurtId),
                    IngredientConstants.GreekYogurtCaloriesPer100g,
                    IngredientConstants.GreekYogurtFatPer100g,
                    IngredientConstants.GreekYogurtCarbsPer100g,
                    IngredientConstants.GreekYogurtProteinPer100g)
                {
                    Name = IngredientConstants.GreekYogurtName,
                    Brand = IngredientConstants.GreekYogurtBrand,
                    Source = IngredientConstants.GreekYogurtSource
                },
                new Ingredient(
                    seedingDate,
                    Guid.Parse(IngredientConstants.GingerId),
                    IngredientConstants.GingerCaloriesPer100g,
                    IngredientConstants.GingerFatPer100g,
                    IngredientConstants.GingerCarbsPer100g,
                    IngredientConstants.GingerProteinPer100g)
                {
                    Name = IngredientConstants.GingerName,
                    Brand = IngredientConstants.GingerBrand,
                    Source = IngredientConstants.GingerSource
                },
               // Chickpeas
            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.ChickpeasId),
                IngredientConstants.ChickpeasCaloriesPer100g,
                IngredientConstants.ChickpeasFatPer100g,
                IngredientConstants.ChickpeasCarbsPer100g,
                IngredientConstants.ChickpeasProteinPer100g)
            {
                Name = IngredientConstants.ChickpeasName,
                Brand = IngredientConstants.ChickpeasBrand,
                Source = IngredientConstants.ChickpeasSource
            },
 
            // Chia Seeds
            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.ChiaSeedsId),
                IngredientConstants.ChiaSeedsCaloriesPer100g,
                IngredientConstants.ChiaSeedsFatPer100g,
                IngredientConstants.ChiaSeedsCarbsPer100g,
                IngredientConstants.ChiaSeedsProteinPer100g)
            {
                Name = IngredientConstants.ChiaSeedsName,
                Brand = IngredientConstants.ChiaSeedsBrand,
                Source = IngredientConstants.ChiaSeedsSource
            },
 
            // Soy Sauce
            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.SoySauceId),
                IngredientConstants.SoySauceCaloriesPer100g,
                IngredientConstants.SoySauceFatPer100g,
                IngredientConstants.SoySauceCarbsPer100g,
                IngredientConstants.SoySauceProteinPer100g)
            {
                Name = IngredientConstants.SoySauceName,
                Brand = IngredientConstants.SoySauceBrand,
                Source = IngredientConstants.SoySauceSource
            },
 
            // Feta Cheese
            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.FetaCheeseId),
                IngredientConstants.FetaCheeseCaloriesPer100g,
                IngredientConstants.FetaCheeseFatPer100g,
                IngredientConstants.FetaCheeseCarbsPer100g,
                IngredientConstants.FetaCheeseProteinPer100g)
            {
                Name = IngredientConstants.FetaCheeseName,
                Brand = IngredientConstants.FetaCheeseBrand,
                Source = IngredientConstants.FetaCheeseSource
            },
 
            // Almond Milk
            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.AlmondMilkId),
                IngredientConstants.AlmondMilkCaloriesPer100g,
                IngredientConstants.AlmondMilkFatPer100g,
                IngredientConstants.AlmondMilkCarbsPer100g,
                IngredientConstants.AlmondMilkProteinPer100g)
            {
                Name = IngredientConstants.AlmondMilkName,
                Brand = IngredientConstants.AlmondMilkBrand,
                Source = IngredientConstants.AlmondMilkSource
            },
 
            // Mixed Berries
            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.BerriesId),
                IngredientConstants.BerriesCaloriesPer100g,
                IngredientConstants.BerriesFatPer100g,
                IngredientConstants.BerriesCarbsPer100g,
                IngredientConstants.BerriesProteinPer100g)
            {
                Name = IngredientConstants.BerriesName,
                Brand = IngredientConstants.BerriesBrand,
                Source = IngredientConstants.BerriesSource
            }
            };

            return ingredients;
        }
    }
}
