using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Migrations
{
    public partial class BoolPickup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6accb960-0ded-49b1-af86-4ca3e188a68d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4f32d49-4a05-4fb1-90f0-a01e31eebc5d");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SuspendStart",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SuspendEnd",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OneTimePickup",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "PendingOneTimePickup",
                table: "Customer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4bfeb476-0cea-4df9-95f7-3626b3a1e20a", "a4c9037b-96ce-47f9-8134-7b5f8c49c3fa", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "34823af4-9749-43b4-99d3-8c1690b41bb0", "c3eaa57f-d3a0-434b-bd8e-1f89a722ed36", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34823af4-9749-43b4-99d3-8c1690b41bb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bfeb476-0cea-4df9-95f7-3626b3a1e20a");

            migrationBuilder.DropColumn(
                name: "PendingOneTimePickup",
                table: "Customer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SuspendStart",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SuspendEnd",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OneTimePickup",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4f32d49-4a05-4fb1-90f0-a01e31eebc5d", "22b8c93b-4432-40e6-a0aa-3c03e9ca98c9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6accb960-0ded-49b1-af86-4ca3e188a68d", "1f7bfabf-6b35-4c23-83a3-05da8e430320", "Employee", "EMPLOYEE" });
        }
    }
}
