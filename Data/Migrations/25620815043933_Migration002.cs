using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_bkk_api.Data.Migrations
{
    public partial class Migration002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "delete_at",
                table: "laws",
                newName: "deleted_at");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "laws",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    firstname = table.Column<string>(maxLength: 255, nullable: true),
                    lastname = table.Column<string>(maxLength: 255, nullable: true),
                    full_company_name = table.Column<string>(maxLength: 255, nullable: true),
                    type = table.Column<string>(maxLength: 255, nullable: true),
                    username = table.Column<string>(maxLength: 255, nullable: true),
                    password = table.Column<string>(maxLength: 255, nullable: true),
                    email = table.Column<string>(maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "laws",
                newName: "delete_at");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "laws",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
