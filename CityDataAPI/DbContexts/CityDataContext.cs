using CityDataAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityDataAPI.DbContexts
{
    public class CityDataContext: DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlite("connectionstring");
            base.OnConfiguring(optionsBuilder);
        }
         */

        public CityDataContext(DbContextOptions<CityDataContext>options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City("Rio de Janeiro")
                {
                    Id = 1,
                    Description = "Marvelous city, famous for its beautiful beaches and landscapes."
                },
                new City("São Paulo")
                {
                    Id = 2,
                    Description = "Largest city in Brazil, known for its cultural diversity and vibrant nightlife."
                },
                new City("Salvador")
                {
                    Id = 3,
                    Description = "Capital of Bahia, the birthplace of Afro-Brazilian culture, and rich in history."
                },
                new City("Natal")
                {
                    Id = 4,
                    Description = "Known as the city of sun, Natal has beautiful beaches and sand dunes."
                },
                new City("Brasilia")
                {
                    Id = 5,
                    Description = "The capital of Brazil, known for its modernist architecture and political relevance."
                },
                new City("Fortaleza")
                {
                    Id = 6,
                    Description = "Important coastal city, famous for its beautiful beaches and vibrant culture."
                },
                new City("Manaus")
                {
                    Id = 7,
                    Description = "Located in the heart of the Amazon rainforest, known for its unique nature and indigenous heritage."
                }
            );

            modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest("Christ the Redeemer")
                {
                    Id = 1,
                    CityId = 1, // Rio de Janeiro
                    Description = "One of the most famous symbols of Brazil, located on top of Corcovado."
                },
                new PointOfInterest("Sugarloaf Mountain")
                {
                    Id = 2,
                    CityId = 1, // Rio de Janeiro
                    Description = "Hill offering a panoramic view of the city of Rio de Janeiro."
                },
                new PointOfInterest("São Paulo Museum of Art (MASP)")
                {
                    Id = 3,
                    CityId = 2, // São Paulo
                    Description = "Important art museum located on Paulista Avenue."
                },
                new PointOfInterest("Ponta Negra Beach")
                {
                    Id = 4,
                    CityId = 4, // Natal
                    Description = "Famous beach in Natal, with a lively nightlife nearby."
                },
                new PointOfInterest("National Congress of Brazil")
                {
                    Id = 5,
                    CityId = 5, // Brasilia
                    Description = "The seat of the Brazilian government and an architectural marvel."
                },
                new PointOfInterest("Model Market")
                {
                    Id = 6,
                    CityId = 3, // Salvador
                    Description = "Famous market in Salvador, full of crafts and typical foods."
                },
                new PointOfInterest("Amazon Theatre")
                {
                    Id = 7,
                    CityId = 7, // Manaus
                    Description = "One of the main theaters in Brazil, located in the heart of the Amazon rainforest."
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}



