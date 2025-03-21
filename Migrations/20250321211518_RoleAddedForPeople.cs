using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepairAndConstructionService.Migrations
{
    /// <inheritdoc />
    public partial class RoleAddedForPeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43f3db6e-962d-4487-be31-83d20fe4ac46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79090a71-062f-4358-8805-8b4a0440927c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b347cb16-2ce5-4983-b275-f5255096fc24", "3aba7c24-55ab-44dd-9203-eae11a421b31" });

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b347cb16-2ce5-4983-b275-f5255096fc24");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3aba7c24-55ab-44dd-9203-eae11a421b31");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Customer", "CUSTOMER" },
                    { "3", null, "Worker", "WORKER" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "alice@mail.com", "Alice Johnson", "1234567890" },
                    { 2, "bob@mail.com", "Bob Williams", "0987654321" }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Name", "Rating", "Specialization" },
                values: new object[,]
                {
                    { 1, "Dimitur Djerov", 4.5, "Electrician" },
                    { 2, "Jane Smith", 4.7999999999999998, "Plumber" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CustomerId", "Rating", "WorkerId" },
                values: new object[,]
                {
                    { 1, "Amazing service and very professional!", 1, 5, 1 },
                    { 2, "Quick and efficient repair. Highly recommended!", 2, 5, 2 },
                    { 3, "The plumber did a great job, no issues since.", 1, 4, 2 },
                    { 4, "Very skilled electrician. Solved all my problems!", 2, 5, 1 },
                    { 5, "Friendly and experienced. Would hire again.", 1, 4, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43f3db6e-962d-4487-be31-83d20fe4ac46", null, "Worker", "WORKER" },
                    { "79090a71-062f-4358-8805-8b4a0440927c", null, "Customer", "CUSTOMER" },
                    { "b347cb16-2ce5-4983-b275-f5255096fc24", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3aba7c24-55ab-44dd-9203-eae11a421b31", 0, "1fc2a88f-997d-44cd-8ea4-28bbfd297f62", "admin@service.com", true, false, null, "ADMIN@SERVICE.COM", "ADMIN@SERVICE.COM", "AQAAAAIAAYagAAAAENIJGLpPu2tKy6ELuiJ7e5abV5dLdBQ3RzyvWl3KDhLK0QRZzVLst0oguhhPLkq4Hw==", null, false, "8bf0b46f-b2ce-4c89-a84f-e68c5a2c380d", false, "admin@service.com" });

            migrationBuilder.InsertData(
                table: "JobOffers",
                columns: new[] { "Id", "Description", "Price", "Title", "WorkerId" },
                values: new object[,]
                {
                    { 3, "Check and evaluate roof condition", 100m, "Roof Inspection", null },
                    { 4, "Heating and cooling system maintenance", 250m, "HVAC Repair", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b347cb16-2ce5-4983-b275-f5255096fc24", "3aba7c24-55ab-44dd-9203-eae11a421b31" });
        }
    }
}
