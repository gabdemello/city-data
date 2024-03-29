﻿// <auto-generated />
using CityDataAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityDataAPI.Migrations
{
    [DbContext(typeof(CityDataContext))]
    [Migration("20230729224759_DataSeed")]
    partial class DataSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("CityDataAPI.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Marvelous city, famous for its beautiful beaches and landscapes.",
                            Name = "Rio de Janeiro"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Largest city in Brazil, known for its cultural diversity and vibrant nightlife.",
                            Name = "São Paulo"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Capital of Bahia, the birthplace of Afro-Brazilian culture, and rich in history.",
                            Name = "Salvador"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Known as the city of sun, Natal has beautiful beaches and sand dunes.",
                            Name = "Natal"
                        },
                        new
                        {
                            Id = 5,
                            Description = "The capital of Brazil, known for its modernist architecture and political relevance.",
                            Name = "Brasilia"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Important coastal city, famous for its beautiful beaches and vibrant culture.",
                            Name = "Fortaleza"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Located in the heart of the Amazon rainforest, known for its unique nature and indigenous heritage.",
                            Name = "Manaus"
                        });
                });

            modelBuilder.Entity("CityDataAPI.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointsOfInterest");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Description = "One of the most famous symbols of Brazil, located on top of Corcovado.",
                            Name = "Christ the Redeemer"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Description = "Hill offering a panoramic view of the city of Rio de Janeiro.",
                            Name = "Sugarloaf Mountain"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 2,
                            Description = "Important art museum located on Paulista Avenue.",
                            Name = "São Paulo Museum of Art (MASP)"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 4,
                            Description = "Famous beach in Natal, with a lively nightlife nearby.",
                            Name = "Ponta Negra Beach"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 5,
                            Description = "The seat of the Brazilian government and an architectural marvel.",
                            Name = "National Congress of Brazil"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 3,
                            Description = "Famous market in Salvador, full of crafts and typical foods.",
                            Name = "Model Market"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 7,
                            Description = "One of the main theaters in Brazil, located in the heart of the Amazon rainforest.",
                            Name = "Amazon Theatre"
                        });
                });

            modelBuilder.Entity("CityDataAPI.Entities.PointOfInterest", b =>
                {
                    b.HasOne("CityDataAPI.Entities.City", "City")
                        .WithMany("PointOfInterests")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CityDataAPI.Entities.City", b =>
                {
                    b.Navigation("PointOfInterests");
                });
#pragma warning restore 612, 618
        }
    }
}
