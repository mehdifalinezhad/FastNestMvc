using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistant.Migrations
{
    /// <inheritdoc />
    public partial class AdduserInfoToOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_userId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserInfo_UserInfoId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_userId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "Orders",
                newName: "userInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserInfoId",
                table: "Orders",
                newName: "IX_Orders_userInfoId");

            migrationBuilder.AlterColumn<int>(
                name: "userInfoId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserInfo_userInfoId",
                table: "Orders",
                column: "userInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserInfo_userInfoId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "userInfoId",
                table: "Orders",
                newName: "UserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_userInfoId",
                table: "Orders",
                newName: "IX_Orders_UserInfoId");

            migrationBuilder.AlterColumn<int>(
                name: "UserInfoId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_userId",
                table: "Orders",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserInfo_UserInfoId",
                table: "Orders",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
