using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistant.Migrations
{
    /// <inheritdoc />
    public partial class AddfoodPlansToUseInfoAnduserInfoToFoodPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foodplan_AspNetUsers_UserId",
                table: "Foodplan");

            migrationBuilder.DropIndex(
                name: "IX_Foodplan_UserId",
                table: "Foodplan");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Foodplan");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Foodplan",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Foodplan",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryFoodPlanId",
                table: "Foodplan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "userInfoId",
                table: "Foodplan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Foodplan_userInfoId",
                table: "Foodplan",
                column: "userInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foodplan_UserInfo_userInfoId",
                table: "Foodplan",
                column: "userInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foodplan_UserInfo_userInfoId",
                table: "Foodplan");

            migrationBuilder.DropIndex(
                name: "IX_Foodplan_userInfoId",
                table: "Foodplan");

            migrationBuilder.DropColumn(
                name: "userInfoId",
                table: "Foodplan");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Foodplan",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Foodplan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryFoodPlanId",
                table: "Foodplan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Foodplan",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foodplan_UserId",
                table: "Foodplan",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foodplan_AspNetUsers_UserId",
                table: "Foodplan",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
