﻿// <auto-generated />
using System;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Project_bkk_api.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("25620820094624_Migration006")]
    partial class Migration006
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Todo.Models.LawsEntity", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("created_at");

                    b.Property<Guid?>("created_by");

                    b.Property<DateTime?>("deleted_at");

                    b.Property<bool>("is_active");

                    b.Property<string>("name")
                        .HasMaxLength(255);

                    b.Property<string>("note")
                        .HasMaxLength(3000);

                    b.Property<DateTime?>("updated_at");

                    b.Property<Guid?>("updated_by");

                    b.HasKey("id");

                    b.ToTable("laws");
                });

            modelBuilder.Entity("Todo.Models.PermissionEntity", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("created_at");

                    b.Property<Guid?>("created_by");

                    b.Property<DateTime?>("deleted_at");

                    b.Property<bool>("is_active");

                    b.Property<string>("name")
                        .HasMaxLength(255);

                    b.Property<string>("note")
                        .HasMaxLength(2000);

                    b.Property<DateTime?>("updated_at");

                    b.Property<Guid?>("updated_by");

                    b.HasKey("id");

                    b.ToTable("permission");
                });

            modelBuilder.Entity("Todo.Models.RoleEntity", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("created_at");

                    b.Property<Guid?>("created_by");

                    b.Property<DateTime?>("deleted_at");

                    b.Property<bool>("is_active");

                    b.Property<string>("name")
                        .HasMaxLength(255);

                    b.Property<string>("note")
                        .HasMaxLength(2000);

                    b.Property<DateTime?>("updated_at");

                    b.Property<Guid?>("updated_by");

                    b.HasKey("id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("Todo.Models.RoleHasPermissionEntity", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("created_at");

                    b.Property<Guid?>("created_by");

                    b.Property<DateTime?>("deleted_at");

                    b.Property<bool>("is_active");

                    b.Property<Guid>("permission_id");

                    b.Property<Guid>("role_id");

                    b.Property<DateTime?>("updated_at");

                    b.Property<Guid?>("updated_by");

                    b.HasKey("id");

                    b.HasIndex("permission_id");

                    b.HasIndex("role_id");

                    b.ToTable("role_has_permission");
                });

            modelBuilder.Entity("Todo.Models.StaffEntity", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("created_at");

                    b.Property<Guid?>("created_by");

                    b.Property<DateTime?>("deleted_at");

                    b.Property<string>("email")
                        .HasMaxLength(255);

                    b.Property<string>("firstname")
                        .HasMaxLength(255);

                    b.Property<bool>("is_active");

                    b.Property<string>("lastname")
                        .HasMaxLength(255);

                    b.Property<string>("password")
                        .HasMaxLength(255);

                    b.Property<string>("position")
                        .HasMaxLength(255);

                    b.Property<string>("tel")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("updated_at");

                    b.Property<Guid?>("updated_by");

                    b.Property<string>("username")
                        .HasMaxLength(255);

                    b.HasKey("id");

                    b.ToTable("staff");
                });

            modelBuilder.Entity("Todo.Models.StaffHasRoleEntity", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("created_at");

                    b.Property<Guid?>("created_by");

                    b.Property<DateTime?>("deleted_at");

                    b.Property<bool>("is_active");

                    b.Property<Guid>("role_id");

                    b.Property<Guid>("staff_id");

                    b.Property<DateTime?>("updated_at");

                    b.Property<Guid?>("updated_by");

                    b.HasKey("id");

                    b.HasIndex("role_id");

                    b.HasIndex("staff_id");

                    b.ToTable("staff_has_role");
                });

            modelBuilder.Entity("Todo.Models.UserEntity", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("created_at");

                    b.Property<DateTime?>("deleted_at");

                    b.Property<string>("email")
                        .HasMaxLength(255);

                    b.Property<string>("firstname")
                        .HasMaxLength(255);

                    b.Property<string>("full_company_name")
                        .HasMaxLength(255);

                    b.Property<bool>("is_active");

                    b.Property<string>("lastname")
                        .HasMaxLength(255);

                    b.Property<string>("password")
                        .HasMaxLength(255);

                    b.Property<string>("type")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("updated_at");

                    b.Property<string>("username")
                        .HasMaxLength(255);

                    b.HasKey("id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Todo.Models.RoleHasPermissionEntity", b =>
                {
                    b.HasOne("Todo.Models.PermissionEntity", "permission")
                        .WithMany()
                        .HasForeignKey("permission_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Todo.Models.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Todo.Models.StaffHasRoleEntity", b =>
                {
                    b.HasOne("Todo.Models.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Todo.Models.StaffEntity", "Staff")
                        .WithMany()
                        .HasForeignKey("staff_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
