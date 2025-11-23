using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartaoDeVacinaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicationDate",
                table: "VaccinationRecords",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationDate",
                table: "VaccinationRecords");
        }
    }
}
