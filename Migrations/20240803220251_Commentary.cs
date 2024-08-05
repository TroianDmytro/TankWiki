using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class Commentary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_Turrets_TurretId",
                table: "Tanks");

            migrationBuilder.DropTable(
                name: "GunTurret");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_TurretId",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "TurretId",
                table: "Tanks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurretId",
                table: "Tanks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GunTurret",
                columns: table => new
                {
                    GunsGunId = table.Column<int>(type: "int", nullable: false),
                    TurretsTurretId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GunTurret", x => new { x.GunsGunId, x.TurretsTurretId });
                    table.ForeignKey(
                        name: "FK_GunTurret_Guns_GunsGunId",
                        column: x => x.GunsGunId,
                        principalTable: "Guns",
                        principalColumn: "GunId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GunTurret_Turrets_TurretsTurretId",
                        column: x => x.TurretsTurretId,
                        principalTable: "Turrets",
                        principalColumn: "TurretId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_TurretId",
                table: "Tanks",
                column: "TurretId");

            migrationBuilder.CreateIndex(
                name: "IX_GunTurret_TurretsTurretId",
                table: "GunTurret",
                column: "TurretsTurretId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_Turrets_TurretId",
                table: "Tanks",
                column: "TurretId",
                principalTable: "Turrets",
                principalColumn: "TurretId");
        }
    }
}
