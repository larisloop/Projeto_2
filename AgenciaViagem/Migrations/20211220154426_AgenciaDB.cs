using Microsoft.EntityFrameworkCore.Migrations;

namespace AgenciaViagem.Migrations
{
    public partial class AgenciaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    IdDestino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataIda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtdPassageiros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.IdDestino);
                });

            migrationBuilder.CreateTable(
                name: "Hoteis",
                columns: table => new
                {
                    IdHotel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtdHospede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteis", x => x.IdHotel);
                });

            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    CodigoCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinoIdDestino = table.Column<int>(type: "int", nullable: false),
                    HotelIdHotel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.CodigoCliente);
                    table.ForeignKey(
                        name: "FK_Passageiros_Destinos_DestinoIdDestino",
                        column: x => x.DestinoIdDestino,
                        principalTable: "Destinos",
                        principalColumn: "IdDestino",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passageiros_Hoteis_HotelIdHotel",
                        column: x => x.HotelIdHotel,
                        principalTable: "Hoteis",
                        principalColumn: "IdHotel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_DestinoIdDestino",
                table: "Passageiros",
                column: "DestinoIdDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_HotelIdHotel",
                table: "Passageiros",
                column: "HotelIdHotel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passageiros");

            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "Hoteis");
        }
    }
}
