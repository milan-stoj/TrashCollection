using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Data.Migrations
{
    public partial class RemovedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f954f6b-f7a1-4a43-aee8-75c39f6459f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19a9dbaf-7166-4c7a-a654-cc733936dd1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92ebe9db-de5f-45b5-a5a3-75e8d52b722a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f5c48f1-2949-4e2d-87bb-79bfd32fe568", "e9336898-fe1d-4b11-9f72-17075ae33165", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1f97a78-288e-41b4-b078-b527e41c603d", "87d054d7-761b-4fbe-bd65-89e5591cb875", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f5c48f1-2949-4e2d-87bb-79bfd32fe568");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1f97a78-288e-41b4-b078-b527e41c603d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92ebe9db-de5f-45b5-a5a3-75e8d52b722a", "995eae62-3a09-4358-996c-792048f0c69f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19a9dbaf-7166-4c7a-a654-cc733936dd1c", "a9235654-49ea-442a-8ef5-0a9fb36184ab", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f954f6b-f7a1-4a43-aee8-75c39f6459f5", "eed04254-e1f3-4f1b-8b49-82819497a361", "Employee", "EMPLOYEE" });
        }
    }
}
