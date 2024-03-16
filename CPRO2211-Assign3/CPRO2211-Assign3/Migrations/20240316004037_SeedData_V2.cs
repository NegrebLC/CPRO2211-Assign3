using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CPRO2211_Assign3.Migrations
{
    /// <inheritdoc />
    public partial class SeedData_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accommodations",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Activities",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Trips",
                newName: "TripId");

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Trips",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Accommodation",
                table: "Trips",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccommodationEmail",
                table: "Trips",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccommodationPhone",
                table: "Trips",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThingToDo1",
                table: "Trips",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThingToDo2",
                table: "Trips",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThingToDo3",
                table: "Trips",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Destination", "EndDate", "StartDate", "ThingToDo1", "ThingToDo2", "ThingToDo3" },
                values: new object[,]
                {
                    { 1, "Hotel Paris", "paris@hotel.com", "(403) 403-4034", "Paris", new DateTime(2023, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visit the Eiffel Tower", "Explore the Louvre", "Walk along the Seine" },
                    { 2, null, null, null, "New York", new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "See the Statue of Liberty", "Visit Central Park", "Explore Times Square" },
                    { 3, "Tokyo Inn", "contact@tokyoinn.jp", "(405) 405-4056", "Tokyo", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visit Tokyo Tower", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Accommodation",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "AccommodationEmail",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "AccommodationPhone",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ThingToDo1",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ThingToDo2",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ThingToDo3",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "TripId",
                table: "Trips",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Trips",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647);

            migrationBuilder.AddColumn<string>(
                name: "Accommodations",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Activities",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
