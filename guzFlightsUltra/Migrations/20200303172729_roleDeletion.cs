using Microsoft.EntityFrameworkCore.Migrations;

namespace guzFlightsUltra.Migrations
{
    public partial class roleDeletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "3ed71cb3-e135-42fc-8515-5cf96aa0d00f", "087f9b43-63a7-48ee-a065-00312042139c", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b2caceb-59e5-4523-9a7a-c55969aa25ce", "0fad4593-3be3-4357-b9ef-8ddfe0bb4f2c", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ed71cb3-e135-42fc-8515-5cf96aa0d00f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b2caceb-59e5-4523-9a7a-c55969aa25ce");

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
    }
}
