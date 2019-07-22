using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_bkk_api.Migrations
{
    public partial class Testaddage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "int(3)",
                table: "test",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "int(3)",
                table: "test");
        }
    }
}
