using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_bkk_api.Data.Migrations
{
    public partial class Migration006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "role",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(Guid),
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "permission",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(Guid),
                oldMaxLength: 2000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "note",
                table: "role",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "note",
                table: "permission",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2000,
                oldNullable: true);
        }
    }
}
