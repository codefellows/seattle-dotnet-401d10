using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncAPISolution.Migrations
{
    public partial class newdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "City", "Name", "Phone", "State" },
                values: new object[] { 1, "Seattle", "Amanda's Hotel", "123-456-8798", "WA" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "City", "Name", "Phone", "State" },
                values: new object[] { 2, "Seattle", "Josie's Hotel", "123-852-8798", "WA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
