using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guns_Turrets_TurretId",
                table: "Guns");

            migrationBuilder.DropIndex(
                name: "IX_Guns_TurretId",
                table: "Guns");

            migrationBuilder.DropColumn(
                name: "TurretId",
                table: "Guns");

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
                name: "IX_GunTurret_TurretsTurretId",
                table: "GunTurret",
                column: "TurretsTurretId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GunTurret");

            migrationBuilder.AddColumn<int>(
                name: "TurretId",
                table: "Guns",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guns_TurretId",
                table: "Guns",
                column: "TurretId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guns_Turrets_TurretId",
                table: "Guns",
                column: "TurretId",
                principalTable: "Turrets",
                principalColumn: "TurretId");
        }
    }
}
