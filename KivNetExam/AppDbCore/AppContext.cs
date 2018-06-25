using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDbCore
{
    public class ContextInit : DropCreateDatabaseIfModelChanges<NetAppContext>
    {
        protected override void Seed(NetAppContext context)
        {
            //deklarace stuff zde
            //    context.Tables.AddRange(new List<Table>()
            //    {
            //        new Table() { Name = "Table 1" },
            //        new Table() { Name = "Table 2" },
            //        new Table() { Name = "Table 3" },
            //        new Table() { Name = "Table 4" }
            //    });
            //    context.SaveChanges();

            //    Ingredient rum = context.Ingredients.Add(new Ingredient() { Name = "Rum" });
            //    context.SaveChanges();
            //    Ingredient coke = context.Ingredients.Add(new Ingredient() { Name = "Coke" });
            //    context.SaveChanges();
            //    Ingredient beer = context.Ingredients.Add(new Ingredient() { Name = "Beer" });
            //    context.SaveChanges();
            //    Ingredient wine = context.Ingredients.Add(new Ingredient() { Name = "Wine" });
            //    context.SaveChanges();
            //    Ingredient soda = context.Ingredients.Add(new Ingredient() { Name = "Soda" });
            //    context.SaveChanges();

            //    context.Drinks.AddRange(new List<Drink>()
            //    {
            //        new Drink() { Name = "Cuba Libre", RecommendedPrice = 20, Ingredients = new List<Ingredient>(new Ingredient[] { rum, coke }) },
            //        new Drink() { Name = "Aperol Spritz", RecommendedPrice = 20, Ingredients = new List<Ingredient>(new Ingredient[] { wine, soda })},
            //        new Drink() { Name = "Beer", RecommendedPrice = 15, Ingredients = new List<Ingredient>(new Ingredient[] { beer }) },
            //        new Drink() { Name = "Wine", RecommendedPrice = 10, Ingredients = new List<Ingredient>(new Ingredient[] { wine }) },
            //        new Drink() { Name = "Soda", RecommendedPrice = 5, Ingredients = new List<Ingredient>(new Ingredient[] { soda }) }
            //    });
            //    context.SaveChanges();
            //}
        }
    } 

    public class NetAppContext : DbContext
    {
        // public DbSet<o> tady;
    }
}
