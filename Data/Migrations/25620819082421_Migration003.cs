using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_bkk_api.Data.Migrations
{
    public partial class Migration003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "position",
                table: "staff",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "staff",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "position",
                table: "staff",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "staff",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
