using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiodigestoresAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ubicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Extensiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UbicacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extensiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Extensiones_Ubicaciones_UbicacionId",
                        column: x => x.UbicacionId,
                        principalTable: "Ubicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Biodigestores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperaturainterna = table.Column<double>(type: "float", nullable: false),
                    Temperaturaexterna = table.Column<double>(type: "float", nullable: false),
                    Humedad = table.Column<double>(type: "float", nullable: false),
                    Caudal = table.Column<double>(type: "float", nullable: false),
                    pH = table.Column<double>(type: "float", nullable: false),
                    ExtensionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biodigestores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biodigestores_Extensiones_ExtensionId",
                        column: x => x.ExtensionId,
                        principalTable: "Extensiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biodigestores_ExtensionId",
                table: "Biodigestores",
                column: "ExtensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Extensiones_UbicacionId",
                table: "Extensiones",
                column: "UbicacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biodigestores");

            migrationBuilder.DropTable(
                name: "Extensiones");

            migrationBuilder.DropTable(
                name: "Ubicaciones");
        }
    }
}
