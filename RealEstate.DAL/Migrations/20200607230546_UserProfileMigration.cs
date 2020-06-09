using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.DAL.Migrations
{
    public partial class UserProfileMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersProfiles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 32, nullable: true),
                    LastName = table.Column<string>(maxLength: 32, nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    City = table.Column<string>(maxLength: 32, nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProfiles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UsersProfiles_Id",
                table: "AspNetUsers",
                column: "Id",
                principalTable: "UsersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UsersProfiles_Id",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UsersProfiles");
        }
    }
}
