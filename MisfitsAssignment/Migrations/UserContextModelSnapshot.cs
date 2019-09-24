﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MisfitsAssignment.Models;

namespace MisfitsAssignment.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MisfitsAssignment.Models.Calculation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EntryDate");

                    b.Property<string>("Result");

                    b.Property<int?>("UserID");

                    b.Property<string>("Value_1");

                    b.Property<string>("Value_2");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Calculation");
                });

            modelBuilder.Entity("MisfitsAssignment.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EntryDate");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MisfitsAssignment.Models.Calculation", b =>
                {
                    b.HasOne("MisfitsAssignment.Models.User", "User")
                        .WithMany("Calculation")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
