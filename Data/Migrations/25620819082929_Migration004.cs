using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_bkk_api.Data.Migrations
{
    public partial class Migration004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "staff",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "delete_at",
                table: "staff",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "ad_username",
                table: "staff",
                newName: "lastname");

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

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "staff",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstname",
                table: "staff");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "staff",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "staff",
                newName: "ad_username");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "staff",
                newName: "delete_at");

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
    }
}
