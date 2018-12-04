using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace inzynierka.Migrations
{
    public partial class ManyTomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_DietLists_DietListId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_DietListId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "DietListId",
                table: "Meals");

            migrationBuilder.CreateTable(
                name: "MealDietLists",
                columns: table => new
                {
                    MealId = table.Column<Guid>(nullable: false),
                    DietListId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealDietLists", x => new { x.MealId, x.DietListId });
                    table.ForeignKey(
                        name: "FK_MealDietLists_DietLists_DietListId",
                        column: x => x.DietListId,
                        principalTable: "DietLists",
                        principalColumn: "DietListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealDietLists_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealDietLists_DietListId",
                table: "MealDietLists",
                column: "DietListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealDietLists");

            migrationBuilder.AddColumn<Guid>(
                name: "DietListId",
                table: "Meals",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Meals_DietListId",
                table: "Meals",
                column: "DietListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_DietLists_DietListId",
                table: "Meals",
                column: "DietListId",
                principalTable: "DietLists",
                principalColumn: "DietListId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
