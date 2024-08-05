using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class Updaate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GunsId",
                table: "Turrets");

            migrationBuilder.DropColumn(
                name: "TanksId",
                table: "Turrets");

            migrationBuilder.AddColumn<int>(
                name: "TurretId",
                table: "Tanks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TurretId",
                table: "Guns",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_TurretId",
                table: "Tanks",
                column: "TurretId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_Turrets_TurretId",
                table: "Tanks",
                column: "TurretId",
                principalTable: "Turrets",
                principalColumn: "TurretId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guns_Turrets_TurretId",
                table: "Guns");

            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_Turrets_TurretId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_TurretId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Guns_TurretId",
                table: "Guns");

            migrationBuilder.DropColumn(
                name: "TurretId",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "TurretId",
                table: "Guns");

            migrationBuilder.AddColumn<string>(
                name: "GunsId",
                table: "Turrets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TanksId",
                table: "Turrets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
