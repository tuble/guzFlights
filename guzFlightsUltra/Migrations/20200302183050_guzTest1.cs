using Microsoft.EntityFrameworkCore.Migrations;

namespace guzFlightsUltra.Migrations
{
    public partial class guzTest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passenger_Reservations_ReservationId",
                table: "Passenger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passenger",
                table: "Passenger");

            migrationBuilder.RenameTable(
                name: "Passenger",
                newName: "Passengers");

            migrationBuilder.RenameIndex(
                name: "IX_Passenger_ReservationId",
                table: "Passengers",
                newName: "IX_Passengers_ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Reservations_ReservationId",
                table: "Passengers",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservatoionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Reservations_ReservationId",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "Passenger");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_ReservationId",
                table: "Passenger",
                newName: "IX_Passenger_ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passenger",
                table: "Passenger",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passenger_Reservations_ReservationId",
                table: "Passenger",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservatoionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
