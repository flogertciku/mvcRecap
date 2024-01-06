﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvcRecap.Models;

#nullable disable

namespace mvcRecap.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240106104100_FirstMigration2")]
    partial class FirstMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("mvcRecap.Models.Pjesemarrja", b =>
                {
                    b.Property<int>("PjesemarrjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WeddingId")
                        .HasColumnType("int");

                    b.HasKey("PjesemarrjaId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeddingId");

                    b.ToTable("Pjesemarrjet");
                });

            modelBuilder.Entity("mvcRecap.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("mvcRecap.Models.Wedding", b =>
                {
                    b.Property<int>("WeddingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("WedderOne")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WedderTwo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("WeddingId");

                    b.HasIndex("UserId");

                    b.ToTable("Weddings");
                });

            modelBuilder.Entity("mvcRecap.Models.Pjesemarrja", b =>
                {
                    b.HasOne("mvcRecap.Models.User", "Dasmori")
                        .WithMany("dasmatKuMerrPjese")
                        .HasForeignKey("UserId");

                    b.HasOne("mvcRecap.Models.Wedding", "Dasma")
                        .WithMany("teFtuarit")
                        .HasForeignKey("WeddingId");

                    b.Navigation("Dasma");

                    b.Navigation("Dasmori");
                });

            modelBuilder.Entity("mvcRecap.Models.Wedding", b =>
                {
                    b.HasOne("mvcRecap.Models.User", "Creator")
                        .WithMany("dasmatEKrijuara")
                        .HasForeignKey("UserId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("mvcRecap.Models.User", b =>
                {
                    b.Navigation("dasmatEKrijuara");

                    b.Navigation("dasmatKuMerrPjese");
                });

            modelBuilder.Entity("mvcRecap.Models.Wedding", b =>
                {
                    b.Navigation("teFtuarit");
                });
#pragma warning restore 612, 618
        }
    }
}
