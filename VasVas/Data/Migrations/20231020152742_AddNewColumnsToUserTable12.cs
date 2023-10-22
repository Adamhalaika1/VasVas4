using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VasVas.Data.Migrations
{
    public partial class AddNewColumnsToUserTable12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                schema: "Security",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                schema: "Security",
                table: "users");
        }
    }
}
