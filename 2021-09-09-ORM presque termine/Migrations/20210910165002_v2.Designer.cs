﻿// <auto-generated />
using System;
using Bourse21.Outils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bourse21.Migrations
{
    [DbContext(typeof(BourseContexte))]
    [Migration("20210910165002_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Bourse21.Modeles.Proprietaire", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Liquidite")
                        .HasColumnType("int");

                    b.Property<DateTime>("Naissance")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nom")
                        .HasColumnType("longtext");

                    b.Property<int>("VersionImage")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("proprietaires");
                });

            modelBuilder.Entity("Bourse21.Modeles.Societe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NbActions")
                        .HasColumnType("int");

                    b.Property<string>("RaisonSociale")
                        .HasColumnType("longtext");

                    b.Property<int>("ValeurUnitaire")
                        .HasColumnType("int");

                    b.Property<int>("VersionImage")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Societes");
                });

            modelBuilder.Entity("Bourse21.Modeles.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AcheteurID")
                        .HasColumnType("int");

                    b.Property<int?>("CIEVendueID")
                        .HasColumnType("int");

                    b.Property<int>("CoutUnitaire")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTrx")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NbActions")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AcheteurID");

                    b.HasIndex("CIEVendueID");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("Bourse21.Modeles.Transaction", b =>
                {
                    b.HasOne("Bourse21.Modeles.Proprietaire", "Acheteur")
                        .WithMany("PorteFeuille")
                        .HasForeignKey("AcheteurID");

                    b.HasOne("Bourse21.Modeles.Societe", "CIEVendue")
                        .WithMany()
                        .HasForeignKey("CIEVendueID");

                    b.Navigation("Acheteur");

                    b.Navigation("CIEVendue");
                });

            modelBuilder.Entity("Bourse21.Modeles.Proprietaire", b =>
                {
                    b.Navigation("PorteFeuille");
                });
#pragma warning restore 612, 618
        }
    }
}
