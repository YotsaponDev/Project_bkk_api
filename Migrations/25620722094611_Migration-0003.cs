using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_bkk_api.Migrations
{
    public partial class Migration0003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "test",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "test");
        }
    }
}
