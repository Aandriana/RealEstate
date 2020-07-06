using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.DAL.Migrations
{
    public partial class BirthdayMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AgentProfile");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AgentProfile",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AgentProfile");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AgentProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
