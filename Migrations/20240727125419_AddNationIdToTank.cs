using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class AddNationIdToTank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nation",
                table: "Tanks");

            migrationBuilder.AddColumn<int>(
                name: "NationId",
                table: "Tanks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_NationId",
                table: "Tanks",
                column: "NationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_Nations_NationId",
                table: "Tanks",
                column: "NationId",
                principalTable: "Nations",
                principalColumn: "NationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_Nations_NationId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_NationId",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "NationId",
                table: "Tanks");

            migrationBuilder.AddColumn<string>(
                name: "Nation",
                table: "Tanks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
