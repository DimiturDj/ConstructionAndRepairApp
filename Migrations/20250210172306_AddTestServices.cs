using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepairAndConstructionService.Migrations
{
    /// <inheritdoc />
    public partial class AddTestServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Price", "Title" },
                values: new object[] { "Fix leaks and damage on your roof.", 500m, "Roof Repair" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Price", "Title" },
                values: new object[] { "Install new plumbing and fix water system issues.", 150m, "Plumbing" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 3, "Interior and exterior painting services.", 300m, "Painting" },
                    { 4, "Electrical installations and repair.", 200m, "Electrician" }
                });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Dimitur Djerov");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Price", "Title" },
                values: new object[] { "General electrical checks and fixes", 100m, "Basic Electrical Service" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Price", "Title" },
                values: new object[] { "Handling complex plumbing issues", 250m, "Advanced Plumbing Service" });

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "John Doe");
        }
    }
}
