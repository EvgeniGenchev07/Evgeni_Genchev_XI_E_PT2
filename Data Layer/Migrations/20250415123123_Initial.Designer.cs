﻿// <auto-generated />
using System;
using Data_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data_Layer.Migrations
{
    [DbContext(typeof(GameCompanyDbContext))]
    [Migration("20250415123123_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.15");

            modelBuilder.Entity("Business_Layer.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Business_Layer.GameType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GameTypes");
                });

            modelBuilder.Entity("Business_Layer.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int?>("GameTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GameTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Business_Layer.Game", b =>
                {
                    b.HasOne("Business_Layer.User", null)
                        .WithMany("Games")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Business_Layer.GameType", b =>
                {
                    b.HasOne("Business_Layer.Game", null)
                        .WithMany("GameTypes")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("Business_Layer.User", b =>
                {
                    b.HasOne("Business_Layer.GameType", null)
                        .WithMany("Users")
                        .HasForeignKey("GameTypeId");

                    b.HasOne("Business_Layer.User", null)
                        .WithMany("Friends")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Business_Layer.Game", b =>
                {
                    b.Navigation("GameTypes");
                });

            modelBuilder.Entity("Business_Layer.GameType", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Business_Layer.User", b =>
                {
                    b.Navigation("Friends");

                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
