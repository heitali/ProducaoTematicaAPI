using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProducaoTematicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SITECTB104_SISTEMA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CO_SISTEMA = table.Column<int>(type: "int", nullable: false),
                    SISTEMA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SIGLA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LINK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CORPORATIVO = table.Column<int>(type: "int", nullable: false),
                    MACROPROCESSO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SITECTB104_SISTEMA", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SITECTB104_SISTEMA");
        }
    }
}
