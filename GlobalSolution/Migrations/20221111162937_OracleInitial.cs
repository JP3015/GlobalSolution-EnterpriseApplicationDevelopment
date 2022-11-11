using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution.Migrations
{
    public partial class OracleInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GS_ESTACIONAMENTO_NET",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Local = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_ESTACIONAMENTO_NET", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_CARRO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Placa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Modelo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EstacionamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_CARRO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GS_CARRO_GS_ESTACIONAMENTO_NET_EstacionamentoId",
                        column: x => x.EstacionamentoId,
                        principalTable: "GS_ESTACIONAMENTO_NET",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GS_CARRO_EstacionamentoId",
                table: "GS_CARRO",
                column: "EstacionamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GS_CARRO");

            migrationBuilder.DropTable(
                name: "GS_ESTACIONAMENTO_NET");
        }
    }
}
