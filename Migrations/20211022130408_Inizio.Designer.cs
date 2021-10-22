﻿// <auto-generated />
using System;
using Lavoro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lavoro.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211022130408_Inizio")]
    partial class Inizio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Lavoro.Models.Dipendente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cognome")
                        .HasColumnType("text");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("RepartoId")
                        .HasColumnType("int");

                    b.Property<double>("Stipendio")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("RepartoId");

                    b.ToTable("Dipendenti");
                });

            modelBuilder.Entity("Lavoro.Models.Dirigente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cognome")
                        .HasColumnType("text");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("RepartoId")
                        .HasColumnType("int");

                    b.Property<double>("Stipendio")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("RepartoId");

                    b.ToTable("Dirigenti");
                });

            modelBuilder.Entity("Lavoro.Models.Reparto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Reparti");
                });

            modelBuilder.Entity("Lavoro.Models.Dipendente", b =>
                {
                    b.HasOne("Lavoro.Models.Reparto", null)
                        .WithMany("Dipendenti")
                        .HasForeignKey("RepartoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lavoro.Models.Dirigente", b =>
                {
                    b.HasOne("Lavoro.Models.Reparto", null)
                        .WithMany("Dirigenti")
                        .HasForeignKey("RepartoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lavoro.Models.Reparto", b =>
                {
                    b.Navigation("Dipendenti");

                    b.Navigation("Dirigenti");
                });
#pragma warning restore 612, 618
        }
    }
}