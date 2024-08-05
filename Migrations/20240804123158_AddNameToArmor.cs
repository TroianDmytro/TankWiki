using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToArmor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Armors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Armors");
        }
    }
}
