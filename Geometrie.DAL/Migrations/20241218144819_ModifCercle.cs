using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geometrie.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModifCercle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "X",
                table: "Cercles");

            migrationBuilder.RenameColumn(
                name: "Y",
                table: "Cercles",
                newName: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Cercles_CentreId",
                table: "Cercles",
                column: "CentreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cercles_Points_CentreId",
                table: "Cercles",
                column: "CentreId",
                principalTable: "Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cercles_Points_CentreId",
                table: "Cercles");

            migrationBuilder.DropIndex(
                name: "IX_Cercles_CentreId",
                table: "Cercles");

            migrationBuilder.RenameColumn(
                name: "CentreId",
                table: "Cercles",
                newName: "Y");

            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "Cercles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
