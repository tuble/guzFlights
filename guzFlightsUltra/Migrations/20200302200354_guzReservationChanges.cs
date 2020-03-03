using Microsoft.EntityFrameworkCore.Migrations;

namespace guzFlightsUltra.Migrations
{
    public partial class guzReservationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03853dad-9728-4a96-93e1-c0895fef4fa9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c925ceb-a32b-4f4c-ba02-b387b5c91e60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43ffda49-64ed-4e1f-bfac-bf3a144bab9e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "422929b6-cf25-441b-8cf6-6b5ccae0993a", "725dde4d-bfe5-4c9b-8850-c19579b4a1bc", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bacadb2b-84af-45ec-8add-a656b44b1bcf", "b80605f1-c4e0-4644-84d8-f46b2688dc1b", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98fe7a4f-ee99-407e-87bc-5ed1c5333a64", "c7b8dc28-e101-45df-8fb6-7a7e4bec4e3d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422929b6-cf25-441b-8cf6-6b5ccae0993a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98fe7a4f-ee99-407e-87bc-5ed1c5333a64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bacadb2b-84af-45ec-8add-a656b44b1bcf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43ffda49-64ed-4e1f-bfac-bf3a144bab9e", "3daa2098-ace3-4ed4-a8fb-18bab3d6bb0a", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03853dad-9728-4a96-93e1-c0895fef4fa9", "84e36f09-c09b-49fb-a46e-3bf68a9846d2", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c925ceb-a32b-4f4c-ba02-b387b5c91e60", "30783c23-996e-4503-a138-7fd014571fc8", "Administrator", "ADMINISTRATOR" });
        }
    }
}
