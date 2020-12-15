using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_aereopuerto.Migrations
{
    public partial class primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aviones",
                columns: table => new
                {
                    AvionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Capacidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviones", x => x.AvionId);
                });

            migrationBuilder.CreateTable(
                name: "Bases",
                columns: table => new
                {
                    BaseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bases", x => x.BaseId);
                });

            migrationBuilder.CreateTable(
                name: "Miembros",
                columns: table => new
                {
                    MiembroId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cedula = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miembros", x => x.MiembroId);
                });

            migrationBuilder.CreateTable(
                name: "Pilotos",
                columns: table => new
                {
                    PilotoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    HorasVuelo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilotos", x => x.PilotoId);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    MantenimientoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<string>(nullable: true),
                    Detalle = table.Column<string>(nullable: true),
                    BaseId = table.Column<int>(nullable: false),
                    AvionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.MantenimientoId);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Aviones_AvionId",
                        column: x => x.AvionId,
                        principalTable: "Aviones",
                        principalColumn: "AvionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Bases_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Bases",
                        principalColumn: "BaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    VueloId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    fechaSalida = table.Column<string>(nullable: true),
                    fechaLlegada = table.Column<string>(nullable: true),
                    ciudadOrigen = table.Column<string>(nullable: true),
                    ciudadDestino = table.Column<string>(nullable: true),
                    PilotoId = table.Column<int>(nullable: false),
                    AvionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.VueloId);
                    table.ForeignKey(
                        name: "FK_Vuelos_Aviones_AvionId",
                        column: x => x.AvionId,
                        principalTable: "Aviones",
                        principalColumn: "AvionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vuelos_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "PilotoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tripulaciones",
                columns: table => new
                {
                    TripulacionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MiembroId = table.Column<int>(nullable: false),
                    VueloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tripulaciones", x => x.TripulacionId);
                    table.ForeignKey(
                        name: "FK_Tripulaciones_Miembros_MiembroId",
                        column: x => x.MiembroId,
                        principalTable: "Miembros",
                        principalColumn: "MiembroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tripulaciones_Vuelos_VueloId",
                        column: x => x.VueloId,
                        principalTable: "Vuelos",
                        principalColumn: "VueloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_AvionId",
                table: "Mantenimientos",
                column: "AvionId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_BaseId",
                table: "Mantenimientos",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tripulaciones_MiembroId",
                table: "Tripulaciones",
                column: "MiembroId");

            migrationBuilder.CreateIndex(
                name: "IX_Tripulaciones_VueloId",
                table: "Tripulaciones",
                column: "VueloId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_AvionId",
                table: "Vuelos",
                column: "AvionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_PilotoId",
                table: "Vuelos",
                column: "PilotoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Tripulaciones");

            migrationBuilder.DropTable(
                name: "Bases");

            migrationBuilder.DropTable(
                name: "Miembros");

            migrationBuilder.DropTable(
                name: "Vuelos");

            migrationBuilder.DropTable(
                name: "Aviones");

            migrationBuilder.DropTable(
                name: "Pilotos");
        }
    }
}
