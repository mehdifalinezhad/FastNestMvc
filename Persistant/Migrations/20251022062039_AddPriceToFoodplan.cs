using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistant.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToFoodplan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Foodplan",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserInfoId",
                table: "Orders",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserInfo_UserInfoId",
                table: "Orders",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserInfo_UserInfoId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserInfoId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Foodplan");
        }
    }
}
