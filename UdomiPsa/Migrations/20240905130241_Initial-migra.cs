using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdomiPsa.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vrstas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrstaPsa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vrstas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Godine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Udomljen = table.Column<bool>(type: "bit", nullable: false),
                    VrstaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pass_Vrstas_VrstaId",
                        column: x => x.VrstaId,
                        principalTable: "Vrstas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pass_VrstaId",
                table: "Pass",
                column: "VrstaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pass");

            migrationBuilder.DropTable(
                name: "Vrstas");
        }
    }
}
