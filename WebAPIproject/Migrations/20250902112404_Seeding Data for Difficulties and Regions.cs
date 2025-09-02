using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPIproject.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("71dbe6ef-ceb7-4439-bbf7-91a4fb825d7e"), "Medium" },
                    { new Guid("deb63431-68ef-4bb9-8227-cf622fb85898"), "Easy" },
                    { new Guid("f36123ab-783f-4935-97f0-f56044fd24b6"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("66a9b33f-87a9-4697-b99a-87e7ffe1fd8c"), "Cox", "Cox-bazar Sea beach", null },
                    { new Guid("914f6866-04c1-4f80-9579-5fc9882458ed"), "Khu", "Sundarban", "https://encrypted-tbn3.gstatic.com/licensed-image?q=tbn:ANd9GcTlnqro3eX6Ak-C2QJzU4DGaMnXz-NgY4J1XsEDJHNnpOsYpHG-yHM-YB0TXZsBP_-kYi5L89nwHzRS1DufiOx4NESb8OoTInde00T4hQ" },
                    { new Guid("b1bebf72-7ef5-4e0f-89de-88fc60f979cc"), "Khu", "Sundarban", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("71dbe6ef-ceb7-4439-bbf7-91a4fb825d7e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("deb63431-68ef-4bb9-8227-cf622fb85898"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f36123ab-783f-4935-97f0-f56044fd24b6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("66a9b33f-87a9-4697-b99a-87e7ffe1fd8c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("914f6866-04c1-4f80-9579-5fc9882458ed"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b1bebf72-7ef5-4e0f-89de-88fc60f979cc"));
        }
    }
}
