using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BubberDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MenuUpdateReviewIdsAndDinnerIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuDinnerIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuDinnerIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuDinnerIds_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuMenuReviewIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMenuReviewIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuMenuReviewIds_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuDinnerIds_MenuId",
                table: "MenuDinnerIds",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuMenuReviewIds_MenuId",
                table: "MenuMenuReviewIds",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuDinnerIds");

            migrationBuilder.DropTable(
                name: "MenuMenuReviewIds");
        }
    }
}
