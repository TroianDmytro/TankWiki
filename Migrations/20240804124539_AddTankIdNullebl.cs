using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class AddTankIdNullebl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armors_Tanks_TankId",
                table: "Armors");

            migrationBuilder.DropIndex(
                name: "IX_Armors_TankId",
                table: "Armors");

            migrationBuilder.AlterColumn<int>(
                name: "TankId",
                table: "Armors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Armors_TankId",
                table: "Armors",
                column: "TankId",
                unique: true,
                filter: "[TankId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Armors_Tanks_TankId",
                table: "Armors",
                column: "TankId",
                principalTable: "Tanks",
                principalColumn: "TankId");
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

            migrationBuilder.AlterColumn<int>(
                name: "TankId",
                table: "Armors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
