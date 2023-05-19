﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Data;

#nullable disable

namespace OnlineShop.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230519103133_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineShop.Models.Artikal", b =>
                {
                    b.Property<int>("IdArtikla")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArtikla"));

                    b.Property<int>("CenaArtikla")
                        .HasColumnType("int");

                    b.Property<int>("IdKorisnika")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("NazivArtikla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Obrisan")
                        .HasColumnType("bit");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("SlikaArtikla")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("IdArtikla");

                    b.HasIndex("IdKorisnika");

                    b.ToTable("Artikli");
                });

            modelBuilder.Entity("OnlineShop.Models.Korisnik", b =>
                {
                    b.Property<int>("IdKorisnika")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKorisnika"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImeIPrezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("SlikaKorisnika")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("TipKorisnika")
                        .HasColumnType("int");

                    b.Property<int>("Verifikovan")
                        .HasColumnType("int");

                    b.HasKey("IdKorisnika");

                    b.HasIndex("KorisnickoIme")
                        .IsUnique();

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("OnlineShop.Models.Porudzbina", b =>
                {
                    b.Property<int>("IdPorudzbine")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPorudzbine"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CenaPorudzbine")
                        .HasColumnType("float");

                    b.Property<int>("IdKorisnika")
                        .HasColumnType("int");

                    b.Property<string>("Komentar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VremeDostave")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VremePorudzbine")
                        .HasColumnType("datetime2");

                    b.HasKey("IdPorudzbine");

                    b.HasIndex("IdKorisnika");

                    b.ToTable("Porudzbine");
                });

            modelBuilder.Entity("OnlineShop.Models.PorudzbinaArtikal", b =>
                {
                    b.Property<int>("IdPorudzbine")
                        .HasColumnType("int");

                    b.Property<int>("IdArtikla")
                        .HasColumnType("int");

                    b.Property<int>("KolicinaArtikla")
                        .HasColumnType("int");

                    b.Property<int>("UkupnaCenaArtikala")
                        .HasColumnType("int");

                    b.HasKey("IdPorudzbine", "IdArtikla");

                    b.HasIndex("IdArtikla");

                    b.ToTable("PorudzbineArtikli");
                });

            modelBuilder.Entity("OnlineShop.Models.Artikal", b =>
                {
                    b.HasOne("OnlineShop.Models.Korisnik", "Korisnik")
                        .WithMany("Artikli")
                        .HasForeignKey("IdKorisnika")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("OnlineShop.Models.Porudzbina", b =>
                {
                    b.HasOne("OnlineShop.Models.Korisnik", "Korisnik")
                        .WithMany("Porudzbine")
                        .HasForeignKey("IdKorisnika")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("OnlineShop.Models.PorudzbinaArtikal", b =>
                {
                    b.HasOne("OnlineShop.Models.Artikal", "Artikal")
                        .WithMany("PorudzbinaArtikli")
                        .HasForeignKey("IdArtikla")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("OnlineShop.Models.Porudzbina", "Porudzbina")
                        .WithMany("PorudzbinaArtikli")
                        .HasForeignKey("IdPorudzbine")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Artikal");

                    b.Navigation("Porudzbina");
                });

            modelBuilder.Entity("OnlineShop.Models.Artikal", b =>
                {
                    b.Navigation("PorudzbinaArtikli");
                });

            modelBuilder.Entity("OnlineShop.Models.Korisnik", b =>
                {
                    b.Navigation("Artikli");

                    b.Navigation("Porudzbine");
                });

            modelBuilder.Entity("OnlineShop.Models.Porudzbina", b =>
                {
                    b.Navigation("PorudzbinaArtikli");
                });
#pragma warning restore 612, 618
        }
    }
}
