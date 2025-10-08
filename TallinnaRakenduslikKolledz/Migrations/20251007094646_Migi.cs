using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallinnaRakenduslikKolledz.Migrations
{
    /// <inheritdoc />
    public partial class Migi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeknoID",
                table: "Instructor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TEKNO",
                columns: table => new
                {
                    TeknoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeknoNimetus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeknoDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeknoArv = table.Column<int>(type: "int", nullable: false),
                    TeknoHind = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEKNO", x => x.TeknoID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_TeknoID",
                table: "Instructor",
                column: "TeknoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_TEKNO_TeknoID",
                table: "Instructor",
                column: "TeknoID",
                principalTable: "TEKNO",
                principalColumn: "TeknoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_TEKNO_TeknoID",
                table: "Instructor");

            migrationBuilder.DropTable(
                name: "TEKNO");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_TeknoID",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "TeknoID",
                table: "Instructor");
        }
    }
}
