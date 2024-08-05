using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class CreateTankSuspension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suspensions_Tanks_TankId",
                table: "Suspensions");

            migrationBuilder.DropIndex(
                name: "IX_Suspensions_TankId",
                table: "Suspensions");

            migrationBuilder.DropColumn(
                name: "TankId",
                table: "Suspensions");

            migrationBuilder.CreateTable(
                name: "TankSuspensions",
                columns: table => new
                {
                    TankId = table.Column<int>(type: "int", nullable: false),
                    SuspensionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankSuspensions", x => new { x.SuspensionId, x.TankId });
                    table.ForeignKey(
                        name: "FK_TankSuspensions_Suspensions_SuspensionId",
                        column: x => x.SuspensionId,
                        principalTable: "Suspensions",
                        principalColumn: "SuspensionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TankSuspensions_Tanks_TankId",
                        column: x => x.TankId,
                        principalTable: "Tanks",
                        principalColumn: "TankId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TankSuspensions_TankId",
                table: "TankSuspensions",
                column: "TankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TankSuspensions");

            migrationBuilder.AddColumn<int>(
                name: "TankId",
                table: "Suspensions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suspensions_TankId",
                table: "Suspensions",
                column: "TankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suspensions_Tanks_TankId",
                table: "Suspensions",
                column: "TankId",
                principalTable: "Tanks",
                principalColumn: "TankId");
        }
    }
}
