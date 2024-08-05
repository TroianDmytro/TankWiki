using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class AddTankIdToArmor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_Armors_ArmorId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_ArmorId",
                table: "Tanks");

            migrationBuilder.AddColumn<int>(
                name: "TankId",
                table: "Armors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Armors_TankId",
                table: "Armors",
                column: "TankId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Armors_Tanks_TankId",
                table: "Armors",
                column: "TankId",
                principalTable: "Tanks",
                principalColumn: "TankId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armors_Tanks_TankId",
                table: "Armors");

            migrationBuilder.DropIndex(
                name: "IX_Armors_TankId",
                table: "Armors");

            migrationBuilder.DropColumn(
                name: "TankId",
                table: "Armors");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_ArmorId",
                table: "Tanks",
                column: "ArmorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_Armors_ArmorId",
                table: "Tanks",
                column: "ArmorId",
                principalTable: "Armors",
                principalColumn: "ArmorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
