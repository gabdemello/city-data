using CityDataAPI.Models;
using System.Xml.Linq;

namespace CityDataAPI
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore() {

            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Rio de Janeiro",
                    Description = "Marvelous city, famous for its beaches of Copacabana and Ipanema, the Christ the Redeemer statue, and the Sugarloaf Mountain.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Copacabana Beach",
                            Description = "One of the most famous beaches in the world, known for its vibrant atmosphere and scenic beauty."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Christ the Redeemer",
                            Description = "An iconic statue located at the top of Corcovado mountain, offering breathtaking panoramic views of the city."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Sugarloaf Mountain",
                            Description = "A granite peak rising from the Guanabara Bay, providing stunning views of Rio de Janeiro's skyline and coastline."
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "São Paulo",
                    Description = "Vibrant metropolis, known for its cultural diversity, gastronomy, and lively nightlife.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Paulista Avenue",
                            Description = "One of the city's main thoroughfares, lined with skyscrapers, museums, and upscale shops."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Ibirapuera Park",
                            Description = "A large urban park offering green spaces, jogging paths, museums, and cultural events."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Liberdade District",
                            Description = "A vibrant neighborhood with a strong Japanese influence, featuring Asian markets, restaurants, and festivals."
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Salvador",
                    Description = "Historic city with a rich Afro-Brazilian culture, known for its colorful colonial architecture and lively music scene.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Pelourinho",
                            Description = "The historic center of Salvador, featuring beautifully preserved colonial buildings, cobblestone streets, and lively squares."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Elevador Lacerda",
                            Description = "A historic elevator connecting the upper and lower parts of Salvador, providing panoramic views of the city's bay."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Itapuã Beach",
                            Description = "A scenic beach known for its natural beauty, warm waters, and the inspiration for famous songs in Brazilian music."
                        }
                    }
                }

            };
        }
    }
}
