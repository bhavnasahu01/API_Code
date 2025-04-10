using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeApplication.Migrations
{
    public partial class AddDataToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DOB", "Email", "Password", "StudenName" },
                values: new object[] { 1, "India", new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "venkat@gmail.com", "Venkat@123", "Venkat" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DOB", "Email", "Password", "StudenName" },
                values: new object[] { 2, "India", new DateTime(2022, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "bhavna@gmail.com", "Bhavna@123", "Bhavna" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DOB", "Email", "Password", "StudenName" },
                values: new object[] { 3, "Kolkata", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "debal@gmail.com", "Debal@123", "Debal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
