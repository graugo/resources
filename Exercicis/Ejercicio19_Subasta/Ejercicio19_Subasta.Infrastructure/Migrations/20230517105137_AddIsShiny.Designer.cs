﻿// <auto-generated />
using System;
using Ejercicio19_Subasta.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ejercicio19_Subasta.Infrastructure.Migrations
{
    [DbContext(typeof(AuctionDBContext))]
    [Migration("20230517105137_AddIsShiny")]
    partial class AddIsShiny
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ejercicio19_Subasta.Infrastructure.DTO.AuctionDTO", b =>
                {
                    b.Property<int>("AuctionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuctionId"));

                    b.Property<decimal>("ActualPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("AuctionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Created")
                        .HasColumnType("time");

                    b.Property<decimal>("EntryPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsShiny")
                        .HasColumnType("bit");

                    b.Property<int>("NumberBid")
                        .HasColumnType("int");

                    b.Property<int>("PokemonLocationId")
                        .HasColumnType("int");

                    b.HasKey("AuctionId");

                    b.HasIndex("PokemonLocationId");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("Ejercicio19_Subasta.Infrastructure.DTO.HistoricDTO", b =>
                {
                    b.Property<int>("HistoricId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistoricId"));

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<bool>("Sold")
                        .HasColumnType("bit");

                    b.HasKey("HistoricId");

                    b.HasIndex("AuctionId");

                    b.ToTable("Historic");
                });

            modelBuilder.Entity("Ejercicio19_Subasta.Infrastructure.DTO.LocationDTO", b =>
                {
                    b.Property<int>("LocationIdentifier")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationIdentifier");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Ejercicio19_Subasta.Infrastructure.DTO.PokemonLocationDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("MaxChance")
                        .HasColumnType("int");

                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("PokemonId");

                    b.ToTable("PokemonLocation");
                });

            modelBuilder.Entity("Ejercicio19_Subasta.Infrastructure.DTO.PokemonSpecieDTO", b =>
                {
                    b.Property<int>("PokemonIdentifier")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("PokemonIdentifier");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("Ejercicio19_Subasta.Infrastructure.DTO.AuctionDTO", b =>
                {
                    b.HasOne("Ejercicio19_Subasta.Infrastructure.DTO.PokemonLocationDTO", "PokemonLocation")
                        .WithMany()
                        .HasForeignKey("PokemonLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PokemonLocation");
                });

            modelBuilder.Entity("Ejercicio19_Subasta.Infrastructure.DTO.HistoricDTO", b =>
                {
                    b.HasOne("Ejercicio19_Subasta.Infrastructure.DTO.AuctionDTO", "Auction")
                        .WithMany()
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");
                });

            modelBuilder.Entity("Ejercicio19_Subasta.Infrastructure.DTO.PokemonLocationDTO", b =>
                {
                    b.HasOne("Ejercicio19_Subasta.Infrastructure.DTO.LocationDTO", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ejercicio19_Subasta.Infrastructure.DTO.PokemonSpecieDTO", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Pokemon");
                });
#pragma warning restore 612, 618
        }
    }
}
