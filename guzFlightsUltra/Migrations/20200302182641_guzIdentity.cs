using Microsoft.EntityFrameworkCore.Migrations;

namespace guzFlightsUltra.Migrations
{
    public partial class guzIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BussinessCapacity",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "StartingPoint",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "BussinessFreeSeats",
                table: "Flights",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FreeSeats",
                table: "Flights",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StartDestination",
                table: "Flights",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BussinessFreeSeats",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "FreeSeats",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "StartDestination",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "BussinessCapacity",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StartingPoint",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
