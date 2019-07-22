﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_bkk_api.Models;

namespace Project_bkk_api.Migrations
{
    [DbContext(typeof(TestContext))]
    [Migration("25620722100138_Migration-0006")]
    partial class Migration0006
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Project_bkk_api.Models.Test.TestEntity", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<int>("age");

                    b.Property<DateTime?>("date");

                    b.Property<string>("email")
                        .HasMaxLength(200);

                    b.Property<string>("fullname")
                        .HasMaxLength(255);

                    b.Property<string>("remark")
                        .HasMaxLength(2000);

                    b.HasKey("id");

                    b.ToTable("test");
                });
#pragma warning restore 612, 618
        }
    }
}
