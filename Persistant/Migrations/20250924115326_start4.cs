using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistant.Migrations
{
    /// <inheritdoc />
    public partial class start4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Symptoms_Symptoms_SymptomsId",
                table: "Symptoms");

            migrationBuilder.DropIndex(
                name: "IX_Symptoms_SymptomsId",
                table: "Symptoms");

            migrationBuilder.DropColumn(
                name: "SymptomsId",
                table: "Symptoms");

            migrationBuilder.AddColumn<string>(
                name: "FavoritFood",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "State",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Medicins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicins_UserInfo_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicins_UserInfoId",
                table: "Medicins",
                column: "UserInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicins");

            migrationBuilder.DropColumn(
                name: "FavoritFood",
                table: "UserInfo");

            migrationBuilder.AddColumn<int>(
                name: "SymptomsId",
                table: "Symptoms",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "State",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_SymptomsId",
                table: "Symptoms",
                column: "SymptomsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Symptoms_Symptoms_SymptomsId",
                table: "Symptoms",
                column: "SymptomsId",
                principalTable: "Symptoms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
