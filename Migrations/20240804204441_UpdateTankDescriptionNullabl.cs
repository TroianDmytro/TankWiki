using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTankDescriptionNullabl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_TankTypes_TypeId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_TypeId",
                table: "Tanks");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tanks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "TankTypeId",
                table: "Tanks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_TankTypeId",
                table: "Tanks",
                column: "TankTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_TankTypes_TankTypeId",
                table: "Tanks",
                column: "TankTypeId",
                principalTable: "TankTypes",
                principalColumn: "TankTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tanks_TankTypes_TankTypeId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_Tanks_TankTypeId",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "TankTypeId",
                table: "Tanks");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tanks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_TypeId",
                table: "Tanks",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tanks_TankTypes_TypeId",
                table: "Tanks",
                column: "TypeId",
                principalTable: "TankTypes",
                principalColumn: "TankTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
