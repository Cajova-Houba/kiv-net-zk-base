using AppDbCore.Model;
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
            int idCntr = 1;
            context.Meteostations.AddRange(new List<Meteostation>()
            {
                new Meteostation() {Id = idCntr++, Latitude = "12.32", Longitude = "34.65", Name = "Meteostation 1"},
                new Meteostation() {Id = idCntr++, Latitude = "12.32", Longitude = "34.65", Name = "Meteostation 2"},
            });
            context.SaveChanges();

            idCntr = 1;
            Random r = new Random();
            context.Reports.AddRange(new List<Report>()
            {
                new Report() {Id = idCntr++, Summary = "Ok report.", MeteostationId = 1, ReportDate = DateTime.Now.AddDays(-5 + r.Next(10)) },
                new Report() {Id = idCntr++, Summary = "Ok report.", MeteostationId = 1, ReportDate = DateTime.Now.AddDays(-5 + r.Next(10)) },
                new Report() {Id = idCntr++, Summary = "Ok report.", MeteostationId = 2, ReportDate = DateTime.Now.AddDays(-5 + r.Next(10)) },

            });
            context.SaveChanges();

            idCntr = 1;
            context.ReportDataLines.AddRange(new List<ReportDataLine>()
            {
                new ReportDataLine() {Id = idCntr++, DataType = DataLineType.RAIN, Value = 100*r.NextDouble(), ReportId = 1},
                new ReportDataLine() {Id = idCntr++, DataType = DataLineType.TEMPERATURE, Value = 100*r.NextDouble(), ReportId = 2},
                new ReportDataLine() {Id = idCntr++, DataType = DataLineType.SNOW, Value = 100*r.NextDouble(), ReportId = 3},
                new ReportDataLine() {Id = idCntr++, DataType = DataLineType.SNOW, Value = 100*r.NextDouble(), ReportId = 1},
                new ReportDataLine() {Id = idCntr++, DataType = DataLineType.WIND, Value = 100*r.NextDouble(), ReportId = 2},
                new ReportDataLine() {Id = idCntr++, DataType = DataLineType.WIND, Value = 100*r.NextDouble(), ReportId = 3},
            });
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
        public DbSet<Meteostation> Meteostations { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<ReportDataLine> ReportDataLines { get; set; }
        // public DbSet<o> tady;
    }
}
