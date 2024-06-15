using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class AddSeedDataForTSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TShirtSize",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SM" },
                    { 2, "MD" },
                    { 3, "LG" },
                    { 4, "XL" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TShirtSize",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TShirtSize",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TShirtSize",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TShirtSize",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
