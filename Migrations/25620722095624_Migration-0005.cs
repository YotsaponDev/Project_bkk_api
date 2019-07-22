using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_bkk_api.Migrations
{
    public partial class Migration0005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "fullname",
                table: "test",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "test",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(3)");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "test",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "test",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "remark",
                table: "test",
                maxLength: 2000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "test");

            migrationBuilder.DropColumn(
                name: "date",
                table: "test");

            migrationBuilder.DropColumn(
                name: "remark",
                table: "test");

            migrationBuilder.AlterColumn<string>(
                name: "fullname",
                table: "test",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "test",
                type: "int(3)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
