using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_Engines_EngineId",
                table: "Tanks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_Radios_RadioId",
                table: "Tanks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_Suspensions_SuspensionID",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_EngineId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_RadioId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_SuspensionID",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "RadioId",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "SuspensionID",
                table: "Tanks");

            migrationBuilder.AddColumn<int>(
                name: "TankId",
                table: "Suspensions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TankId",
                table: "Radios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TankId",
                table: "Engines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suspensions_TankId",
                table: "Suspensions",
                column: "TankId");

            migrationBuilder.CreateIndex(
                name: "IX_Radios_TankId",
                table: "Radios",
                column: "TankId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Radios_Tanks_TankId",
                table: "Radios",
                column: "TankId",
                principalTable: "Tanks",
                principalColumn: "TankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suspensions_Tanks_TankId",
                table: "Suspensions",
                column: "TankId",
                principalTable: "Tanks",
                principalColumn: "TankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Tanks_TankId",
                table: "Engines");

            migrationBuilder.DropForeignKey(
                name: "FK_Radios_Tanks_TankId",
                table: "Radios");

            migrationBuilder.DropForeignKey(
                name: "FK_Suspensions_Tanks_TankId",
                table: "Suspensions");

            migrationBuilder.DropIndex(
                name: "IX_Suspensions_TankId",
                table: "Suspensions");

            migrationBuilder.DropIndex(
                name: "IX_Radios_TankId",
                table: "Radios");

            migrationBuilder.DropIndex(
                name: "IX_Engines_TankId",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "TankId",
                table: "Suspensions");

            migrationBuilder.DropColumn(
                name: "TankId",
                table: "Radios");

            migrationBuilder.DropColumn(
                name: "TankId",
                table: "Engines");

            migrationBuilder.AddColumn<int>(
                name: "EngineId",
                table: "Tanks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RadioId",
                table: "Tanks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SuspensionID",
                table: "Tanks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_EngineId",
                table: "Tanks",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_RadioId",
                table: "Tanks",
                column: "RadioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_SuspensionID",
                table: "Tanks",
                column: "SuspensionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_Engines_EngineId",
                table: "Tanks",
                column: "EngineId",
                principalTable: "Engines",
                principalColumn: "EngineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_Radios_RadioId",
                table: "Tanks",
                column: "RadioId",
                principalTable: "Radios",
                principalColumn: "RadioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_Suspensions_SuspensionID",
                table: "Tanks",
                column: "SuspensionID",
                principalTable: "Suspensions",
                principalColumn: "SuspensionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
