using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_bkk_api.Data.Migrations
{
    public partial class Migration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "laws",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    note = table.Column<string>(maxLength: 3000, nullable: true),
                    is_active = table.Column<bool>(nullable: true),
                    created_by = table.Column<Guid>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_by = table.Column<Guid>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    delete_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laws", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "staff",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    fullname = table.Column<string>(maxLength: 255, nullable: true),
                    position = table.Column<int>(maxLength: 255, nullable: false),
                    ad_username = table.Column<string>(maxLength: 255, nullable: true),
                    password = table.Column<string>(maxLength: 255, nullable: true),
                    email = table.Column<string>(maxLength: 255, nullable: true),
                    tel = table.Column<string>(maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(nullable: true),
                    created_by = table.Column<Guid>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_by = table.Column<Guid>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    delete_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "laws");

            migrationBuilder.DropTable(
                name: "staff");
        }
    }
}
