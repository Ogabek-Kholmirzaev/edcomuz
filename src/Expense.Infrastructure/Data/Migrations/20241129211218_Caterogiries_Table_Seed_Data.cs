using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Expense.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Caterogiries_Table_Seed_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1m, new DateTime(2024, 11, 29, 21, 12, 18, 433, DateTimeKind.Utc).AddTicks(2404), "Oziq-ovqat", null },
                    { 2m, new DateTime(2024, 11, 29, 21, 12, 18, 433, DateTimeKind.Utc).AddTicks(2407), "Transport", null },
                    { 3m, new DateTime(2024, 11, 29, 21, 12, 18, 433, DateTimeKind.Utc).AddTicks(2408), "Mobil aloqa", null },
                    { 4m, new DateTime(2024, 11, 29, 21, 12, 18, 433, DateTimeKind.Utc).AddTicks(2410), "Internet", null },
                    { 5m, new DateTime(2024, 11, 29, 21, 12, 18, 433, DateTimeKind.Utc).AddTicks(2411), "O'yin-kulgi", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1m);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2m);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3m);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4m);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 5m);
        }
    }
}
