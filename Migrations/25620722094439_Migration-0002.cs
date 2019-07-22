using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_bkk_api.Migrations
{
    public partial class Migration0002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "varchar(100)",
                table: "test",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "int(3)",
                table: "test",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "varchar(200)",
                table: "test",
                newName: "address");

            migrationBuilder.AlterColumn<string>(
                name: "fullname",
                table: "test",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "test",
                type: "int(3)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "test",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "test",
                newName: "varchar(100)");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "test",
                newName: "int(3)");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "test",
                newName: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(100)",
                table: "test",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "int(3)",
                table: "test",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(3)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(200)",
                table: "test",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);
        }
    }
}
