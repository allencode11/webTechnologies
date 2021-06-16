using Microsoft.EntityFrameworkCore.Migrations;

namespace tehnologiiWeb.DataAccess.Migrations
{
    public partial class AddingAccountproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "confirmPassword",
                table: "accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "rememberMe",
                table: "accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "confirmPassword",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "rememberMe",
                table: "accounts");
        }
    }
}
