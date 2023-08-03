using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityDataAPI.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Marvelous city, famous for its beautiful beaches and landscapes.", "Rio de Janeiro" },
                    { 2, "Largest city in Brazil, known for its cultural diversity and vibrant nightlife.", "São Paulo" },
                    { 3, "Capital of Bahia, the birthplace of Afro-Brazilian culture, and rich in history.", "Salvador" },
                    { 4, "Known as the city of sun, Natal has beautiful beaches and sand dunes.", "Natal" },
                    { 5, "The capital of Brazil, known for its modernist architecture and political relevance.", "Brasilia" },
                    { 6, "Important coastal city, famous for its beautiful beaches and vibrant culture.", "Fortaleza" },
                    { 7, "Located in the heart of the Amazon rainforest, known for its unique nature and indigenous heritage.", "Manaus" }
                });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "One of the most famous symbols of Brazil, located on top of Corcovado.", "Christ the Redeemer" },
                    { 2, 1, "Hill offering a panoramic view of the city of Rio de Janeiro.", "Sugarloaf Mountain" },
                    { 3, 2, "Important art museum located on Paulista Avenue.", "São Paulo Museum of Art (MASP)" },
                    { 4, 4, "Famous beach in Natal, with a lively nightlife nearby.", "Ponta Negra Beach" },
                    { 5, 5, "The seat of the Brazilian government and an architectural marvel.", "National Congress of Brazil" },
                    { 6, 3, "Famous market in Salvador, full of crafts and typical foods.", "Model Market" },
                    { 7, 7, "One of the main theaters in Brazil, located in the heart of the Amazon rainforest.", "Amazon Theatre" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
