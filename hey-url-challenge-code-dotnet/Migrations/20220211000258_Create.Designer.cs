﻿// <auto-generated />
using System;
using HeyUrlChallengeCodeDotnet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HeyUrlChallengeCodeDotnet.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220211000258_Create")]
    partial class Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HeyUrlChallengeCodeDotnet.Models.Click", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Browser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Platform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UrlId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UrlId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UrlId");

                    b.HasIndex("UrlId1");

                    b.ToTable("Click");
                });

            modelBuilder.Entity("HeyUrlChallengeCodeDotnet.Models.Url", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("OriginalUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortUrl")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ShortUrl")
                        .IsUnique()
                        .HasFilter("[ShortUrl] IS NOT NULL");

                    b.ToTable("Url");
                });

            modelBuilder.Entity("HeyUrlChallengeCodeDotnet.Models.Click", b =>
                {
                    b.HasOne("HeyUrlChallengeCodeDotnet.Models.Url", "Url")
                        .WithMany()
                        .HasForeignKey("UrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HeyUrlChallengeCodeDotnet.Models.Url", null)
                        .WithMany("Clicks")
                        .HasForeignKey("UrlId1");

                    b.Navigation("Url");
                });

            modelBuilder.Entity("HeyUrlChallengeCodeDotnet.Models.Url", b =>
                {
                    b.Navigation("Clicks");
                });
#pragma warning restore 612, 618
        }
    }
}