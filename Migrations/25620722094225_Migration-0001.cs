using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_bkk_api.Migrations
{
    public partial class Migration0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "varchar(200)",
                table: "test",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "varchar(200)",
                table: "test");
        }
    }
}
