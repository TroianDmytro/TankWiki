using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankWiki.Migrations
{
    /// <inheritdoc />
    public partial class RecreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    ArmorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HullFront = table.Column<int>(type: "int", nullable: false),
                    HullSide = table.Column<int>(type: "int", nullable: false),
                    HullRear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.ArmorId);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    EngineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    FireChance = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.EngineId);
                });

            migrationBuilder.CreateTable(
                name: "Guns",
                columns: table => new
                {
                    GunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Penetration = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    RateOfFire = table.Column<double>(type: "float", nullable: false),
                    Accuracy = table.Column<double>(type: "float", nullable: false),
                    AimTime = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Ammunition = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guns", x => x.GunId);
                });

            migrationBuilder.CreateTable(
                name: "Nations",
                columns: table => new
                {
                    NationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nations", x => x.NationId);
                });

            migrationBuilder.CreateTable(
                name: "Radios",
                columns: table => new
                {
                    RadioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignalRange = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radios", x => x.RadioId);
                });

            migrationBuilder.CreateTable(
                name: "Suspensions",
                columns: table => new
                {
                    SuspensionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadLimit = table.Column<int>(type: "int", nullable: false),
                    TraverseSpeed = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suspensions", x => x.SuspensionId);
                });

            migrationBuilder.CreateTable(
                name: "TankTypes",
                columns: table => new
                {
                    TankTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeMachine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankTypes", x => x.TankTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Turrets",
                columns: table => new
                {
                    TurretId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurretName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    TurretFront = table.Column<int>(type: "int", nullable: false),
                    TurretSide = table.Column<int>(type: "int", nullable: false),
                    TurretRear = table.Column<int>(type: "int", nullable: false),
                    Turn = table.Column<double>(type: "float", nullable: false),
                    Overview = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turrets", x => x.TurretId);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                columns: table => new
                {
                    TankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false),
                    SuspensionID = table.Column<int>(type: "int", nullable: false),
                    RadioId = table.Column<int>(type: "int", nullable: false),
                    ArmorId = table.Column<int>(type: "int", nullable: false),
                    Crew = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.TankId);
                    table.ForeignKey(
                        name: "FK_Tanks_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "ArmorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tanks_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "EngineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tanks_Radios_RadioId",
                        column: x => x.RadioId,
                        principalTable: "Radios",
                        principalColumn: "RadioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tanks_Suspensions_SuspensionID",
                        column: x => x.SuspensionID,
                        principalTable: "Suspensions",
                        principalColumn: "SuspensionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tanks_TankTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TankTypes",
                        principalColumn: "TankTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurretGuns",
                columns: table => new
                {
                    TurretId = table.Column<int>(type: "int", nullable: false),
                    GunId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurretGuns", x => new { x.TurretId, x.GunId });
                    table.ForeignKey(
                        name: "FK_TurretGuns_Guns_GunId",
                        column: x => x.GunId,
                        principalTable: "Guns",
                        principalColumn: "GunId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TurretGuns_Turrets_TurretId",
                        column: x => x.TurretId,
                        principalTable: "Turrets",
                        principalColumn: "TurretId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TankTurrets",
                columns: table => new
                {
                    TankId = table.Column<int>(type: "int", nullable: false),
                    TurretId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TankTurrets", x => new { x.TurretId, x.TankId });
                    table.ForeignKey(
                        name: "FK_TankTurrets_Tanks_TankId",
                        column: x => x.TankId,
                        principalTable: "Tanks",
                        principalColumn: "TankId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TankTurrets_Turrets_TurretId",
                        column: x => x.TurretId,
                        principalTable: "Turrets",
                        principalColumn: "TurretId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_ArmorId",
                table: "Tanks",
                column: "ArmorId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_TypeId",
                table: "Tanks",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TankTurrets_TankId",
                table: "TankTurrets",
                column: "TankId");

            migrationBuilder.CreateIndex(
                name: "IX_TurretGuns_GunId",
                table: "TurretGuns",
                column: "GunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nations");

            migrationBuilder.DropTable(
                name: "TankTurrets");

            migrationBuilder.DropTable(
                name: "TurretGuns");

            migrationBuilder.DropTable(
                name: "Tanks");

            migrationBuilder.DropTable(
                name: "Guns");

            migrationBuilder.DropTable(
                name: "Turrets");

            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Radios");

            migrationBuilder.DropTable(
                name: "Suspensions");

            migrationBuilder.DropTable(
                name: "TankTypes");
        }
    }
}
