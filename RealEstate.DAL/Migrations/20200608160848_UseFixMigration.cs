using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.DAL.Migrations
{
    public partial class UseFixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UsersProfiles_Id",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_AspNetUsers_Id",
                table: "UsersProfiles",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_AspNetUsers_Id",
                table: "UsersProfiles");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UsersProfiles_Id",
                table: "AspNetUsers",
                column: "Id",
                principalTable: "UsersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
