using Microsoft.EntityFrameworkCore.Migrations;

namespace tehnologiiWeb.DataAccess.Migrations
{
    public partial class addingtherolepropety : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "accounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "accounts");
        }
    }
}
