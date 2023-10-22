using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VasVas.Data.Migrations
{
    public partial class AddNewColumnsToUserTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "EmailIndex",
                schema: "Security",
                table: "users");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                schema: "Security",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "Security",
                table: "users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                schema: "Security",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                schema: "Security",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                schema: "Security",
                table: "users");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                schema: "Security",
                table: "users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                schema: "Security",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "Security",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                schema: "Security",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                schema: "Security",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                schema: "Security",
                table: "users",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                schema: "Security",
                table: "users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                schema: "Security",
                table: "users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Security",
                table: "users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Security",
                table: "users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }
    }
}
