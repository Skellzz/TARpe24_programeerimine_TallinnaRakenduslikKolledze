using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallinnaRakenduslikKolledz.Migrations
{
    /// <inheritdoc />
    public partial class ISJA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_TEKNO_TeknoID",
                table: "Instructor");

            migrationBuilder.DropTable(
                name: "TEKNO");

            migrationBuilder.RenameColumn(
                name: "TeknoID",
                table: "Instructor",
                newName: "KaebusKuritarvitajadID");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_TeknoID",
                table: "Instructor",
                newName: "IX_Instructor_KaebusKuritarvitajadID");

            migrationBuilder.CreateTable(
                name: "Kaebus",
                columns: table => new
                {
                    KuritarvitajadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpilaneVOpetaja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KuritarvitajaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KuritegevusteArv = table.Column<int>(type: "int", nullable: false),
                    Kaebuse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kaebus", x => x.KuritarvitajadID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Kaebus_KaebusKuritarvitajadID",
                table: "Instructor",
                column: "KaebusKuritarvitajadID",
                principalTable: "Kaebus",
                principalColumn: "KuritarvitajadID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Kaebus_KaebusKuritarvitajadID",
                table: "Instructor");

            migrationBuilder.DropTable(
                name: "Kaebus");

            migrationBuilder.RenameColumn(
                name: "KaebusKuritarvitajadID",
                table: "Instructor",
                newName: "TeknoID");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_KaebusKuritarvitajadID",
                table: "Instructor",
                newName: "IX_Instructor_TeknoID");

            migrationBuilder.CreateTable(
                name: "TEKNO",
                columns: table => new
                {
                    TeknoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeknoArv = table.Column<int>(type: "int", nullable: false),
                    TeknoDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeknoHind = table.Column<int>(type: "int", nullable: false),
                    TeknoNimetus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEKNO", x => x.TeknoID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_TEKNO_TeknoID",
                table: "Instructor",
                column: "TeknoID",
                principalTable: "TEKNO",
                principalColumn: "TeknoID");
        }
    }
}
