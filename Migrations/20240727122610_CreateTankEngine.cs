using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class CreateTankEngine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Tanks_TankId",
                table: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_Engines_TankId",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "TankId",
                table: "Engines");

            migrationBuilder.CreateTable(
                name: "TankEngines",
                columns: table => new
                {
                    TankId = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankEngines", x => new { x.EngineId, x.TankId });
                    table.ForeignKey(
                        name: "FK_TankEngines_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "EngineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TankEngines_Tanks_TankId",
                        column: x => x.TankId,
                        principalTable: "Tanks",
                        principalColumn: "TankId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TankEngines_TankId",
                table: "TankEngines",
                column: "TankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TankEngines");

            migrationBuilder.AddColumn<int>(
                name: "TankId",
                table: "Engines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engines_TankId",
                table: "Engines",
                column: "TankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_Tanks_TankId",
                table: "Engines",
                column: "TankId",
                principalTable: "Tanks",
                principalColumn: "TankId");
        }
    }
}
