using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollection.Data.Migrations
{
    public partial class ModModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fe1024e-481d-4d2a-be8b-f7769ee0e4d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "205647d7-bcdb-4ba5-9c80-03c5aa841405");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60805995-7c11-4de6-a99b-a53e7d89d4c9");

            migrationBuilder.AddColumn<string>(
                name: "ServiceZip",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PickupDay = table.Column<string>(nullable: true),
                    OneTimePickup = table.Column<string>(nullable: true),
                    MonthBalance = table.Column<int>(nullable: false),
                    SuspendStart = table.Column<string>(nullable: true),
                    SuspendEnd = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdentityUserId",
                table: "Customer",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

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

            migrationBuilder.DropColumn(
                name: "ServiceZip",
                table: "Employee");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "205647d7-bcdb-4ba5-9c80-03c5aa841405", "69e667a4-5de2-4ea7-9f04-d865a1991917", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "60805995-7c11-4de6-a99b-a53e7d89d4c9", "1f6d4bf4-0d0d-4c5d-b395-06dba445b684", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0fe1024e-481d-4d2a-be8b-f7769ee0e4d8", "ca308f99-1d75-4169-a452-afc867979b06", "Employee", "EMPLOYEE" });
        }
    }
}
