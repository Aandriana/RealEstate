using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.DAL.Migrations
{
    public partial class FeedbacksAndPropertiesMigratin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(maxLength: 200, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    SenderId = table.Column<string>(nullable: true),
                    ReceiverId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_UsersProfiles_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "UsersProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_UsersProfiles_SenderId",
                        column: x => x.SenderId,
                        principalTable: "UsersProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(nullable: false),
                    Сategory = table.Column<int>(nullable: false),
                    FloorsNumber = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    AgentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgentsProperties",
                columns: table => new
                {
                    AgentId = table.Column<string>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentsProperties", x => new { x.AgentId, x.PropertyId });
                    table.ForeignKey(
                        name: "FK_AgentsProperties_AspNetUsers_AgentId",
                        column: x => x.AgentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgentsProperties_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentsProperties_PropertyId",
                table: "AgentsProperties",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ReceiverId",
                table: "Feedbacks",
                column: "ReceiverId",
                unique: true,
                filter: "[ReceiverId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_SenderId",
                table: "Feedbacks",
                column: "SenderId",
                unique: true,
                filter: "[SenderId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentsProperties");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
