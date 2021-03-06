﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ispit_zadaca1.Models;

namespace ispit_zadaca1.Migrations
{
    [DbContext(typeof(MVCFacultyContext))]
    [Migration("20200617073153_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ispit_zadaca1.Models.Labvezba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("vezbi");
                });

            modelBuilder.Entity("ispit_zadaca1.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("indeks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("signature")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("ispit_zadaca1.Models.Studentlab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("finishDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("finished")
                        .HasColumnType("bit");

                    b.Property<int>("labvezbaId")
                        .HasColumnType("int");

                    b.Property<int>("points")
                        .HasColumnType("int");

                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("labvezbaId");

                    b.HasIndex("studentId");

                    b.ToTable("studentlabs");
                });

            modelBuilder.Entity("ispit_zadaca1.Models.Studentlab", b =>
                {
                    b.HasOne("ispit_zadaca1.Models.Labvezba", "vezba")
                        .WithMany("studenti")
                        .HasForeignKey("labvezbaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ispit_zadaca1.Models.Student", "student")
                        .WithMany("vezbi")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
