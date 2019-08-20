using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_bkk_api.Data.Migrations
{
    public partial class Migration005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    note = table.Column<Guid>(maxLength: 2000, nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    created_by = table.Column<Guid>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_by = table.Column<Guid>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    note = table.Column<Guid>(maxLength: 2000, nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    created_by = table.Column<Guid>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_by = table.Column<Guid>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_has_permission",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    role_id = table.Column<Guid>(nullable: false),
                    permission_id = table.Column<Guid>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    created_by = table.Column<Guid>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_by = table.Column<Guid>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_has_permission", x => x.id);
                    table.ForeignKey(
                        name: "FK_role_has_permission_permission_permission_id",
                        column: x => x.permission_id,
                        principalTable: "permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_role_has_permission_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staff_has_role",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    staff_id = table.Column<Guid>(nullable: false),
                    role_id = table.Column<Guid>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    created_by = table.Column<Guid>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: true),
                    updated_by = table.Column<Guid>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: true),
                    deleted_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff_has_role", x => x.id);
                    table.ForeignKey(
                        name: "FK_staff_has_role_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_staff_has_role_staff_staff_id",
                        column: x => x.staff_id,
                        principalTable: "staff",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_role_has_permission_permission_id",
                table: "role_has_permission",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_has_permission_role_id",
                table: "role_has_permission",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_staff_has_role_role_id",
                table: "staff_has_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_staff_has_role_staff_id",
                table: "staff_has_role",
                column: "staff_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "role_has_permission");

            migrationBuilder.DropTable(
                name: "staff_has_role");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
