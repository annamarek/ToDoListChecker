﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoChecker_Pro.Data;

#nullable disable

namespace ToDoChecker_Pro.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250404130248_SeedToDoTaskTable")]
    partial class SeedToDoTaskTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDoChecker_Pro.Models.ToDoTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ToDoTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDone = false,
                            Name = "Go to the gym"
                        },
                        new
                        {
                            Id = 2,
                            IsDone = false,
                            Name = "Visit cosmetologist"
                        },
                        new
                        {
                            Id = 3,
                            IsDone = false,
                            Name = "Cook dinner"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
