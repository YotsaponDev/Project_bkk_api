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
    [Migration("25620819082929_Migration004")]
    partial class Migration004
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
#pragma warning restore 612, 618
        }
    }
}