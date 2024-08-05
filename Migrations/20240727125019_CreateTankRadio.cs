using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class CreateTankRadio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Radios_Tanks_TankId",
                table: "Radios");

            migrationBuilder.DropIndex(
                name: "IX_Radios_TankId",
                table: "Radios");

            migrationBuilder.DropColumn(
                name: "TankId",
                table: "Radios");

            migrationBuilder.CreateTable(
                name: "TankRadios",
                columns: table => new
                {
                    TankId = table.Column<int>(type: "int", nullable: false),
                    RadioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankRadios", x => new { x.RadioId, x.TankId });
                    table.ForeignKey(
                        name: "FK_TankRadios_Radios_RadioId",
                        column: x => x.RadioId,
                        principalTable: "Radios",
                        principalColumn: "RadioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TankRadios_Tanks_TankId",
                        column: x => x.TankId,
                        principalTable: "Tanks",
                        principalColumn: "TankId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TankRadios_TankId",
                table: "TankRadios",
                column: "TankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TankRadios");

            migrationBuilder.AddColumn<int>(
                name: "TankId",
                table: "Radios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Radios_TankId",
                table: "Radios",
                column: "TankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Radios_Tanks_TankId",
                table: "Radios",
                column: "TankId",
                principalTable: "Tanks",
                principalColumn: "TankId");
        }
    }
}
