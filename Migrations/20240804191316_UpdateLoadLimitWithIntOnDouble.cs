using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLoadLimitWithIntOnDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LoadLimit",
                table: "Suspensions",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LoadLimit",
                table: "Suspensions",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
