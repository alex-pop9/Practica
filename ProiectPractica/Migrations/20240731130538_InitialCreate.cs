using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectPractica.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    MinAcceptablePrice = table.Column<int>(type: "INTEGER", nullable: false),
                    MinPricePerKm = table.Column<float>(type: "REAL", nullable: false),
                    NumberOfCars = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservationCheckInterval = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    MinPriceForShortTrips = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortTripDistanceThreshold = table.Column<int>(type: "INTEGER", nullable: false),
                    StartBusinessHour = table.Column<int>(type: "INTEGER", nullable: false),
                    EndBusinessHour = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Paths",
                columns: table => new
                {
                    FilePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropTable(
                name: "Paths");
        }
    }
}
