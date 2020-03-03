using Microsoft.EntityFrameworkCore.Migrations;

namespace guzFlightsUltra.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "7cb80aeb-dba2-497a-bda4-2b155c75698c", "ee97185d-6bff-4283-a73f-2567113030d6", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4969ba8-8cd7-4ad0-8124-d4b21f6f99ae", "d4d2f7aa-8fb0-4ddb-9102-32e87290c09d", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87daa770-9f07-43b0-97de-d270812b57f8", "35c81446-3429-4ea2-a8ec-7b07b806b7e9", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cb80aeb-dba2-497a-bda4-2b155c75698c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87daa770-9f07-43b0-97de-d270812b57f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4969ba8-8cd7-4ad0-8124-d4b21f6f99ae");

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
    }
}
