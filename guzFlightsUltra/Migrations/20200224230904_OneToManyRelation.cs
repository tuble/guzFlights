using Microsoft.EntityFrameworkCore.Migrations;

namespace guzFlightsUltra.Migrations
{
    public partial class OneToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Flights",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservatoionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservatoionId);
                });

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    PassengerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SSN = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    TicketType = table.Column<int>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.PassengerId);
                    table.ForeignKey(
                        name: "FK_Passenger_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservatoionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ReservationId",
                table: "Flights",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_ReservationId",
                table: "Passenger",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Reservations_ReservationId",
                table: "Flights",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservatoionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Reservations_ReservationId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "Passenger");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Flights_ReservationId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Flights");
        }
    }
}
