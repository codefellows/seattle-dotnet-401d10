using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentEnrollmentDemoD10.Migrations
{
    public partial class newSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "CourseCode", "Price", "Technology" },
                values: new object[,]
                {
                    { 1, "dotnet-d10", 100m, 0 },
                    { 2, "Intro to Underwater Basketweaving", 50m, 1 },
                    { 3, "How to Talk to Ducks", 550m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 3, 26, 14, 50, 41, 213, DateTimeKind.Local).AddTicks(2807), "Josie", "Cat" },
                    { 2, new DateTime(2019, 12, 2, 14, 50, 41, 221, DateTimeKind.Local).AddTicks(6094), "Belle", "Kitty" },
                    { 3, new DateTime(2020, 4, 20, 14, 50, 41, 221, DateTimeKind.Local).AddTicks(6265), "Munchkin", "KitCat" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "CourseCode",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
