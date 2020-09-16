﻿// <auto-generated />
using System;
using AutoRepo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoRepo.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200904042018_FixEntities")]
    partial class FixEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("AutoRepo.Data.Entities.Destiny", b =>
                {
                    b.Property<Guid>("IdDestiny")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdReport")
                        .HasColumnType("TEXT");

                    b.HasKey("IdDestiny");

                    b.HasIndex("IdReport");

                    b.ToTable("Destinies");
                });

            modelBuilder.Entity("AutoRepo.Data.Entities.MailAccount", b =>
                {
                    b.Property<Guid>("IdMailAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("Port")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Server")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<bool>("UseSSL")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("IdMailAccount");

                    b.ToTable("MailAccounts");
                });

            modelBuilder.Entity("AutoRepo.Data.Entities.Report", b =>
                {
                    b.Property<Guid>("IdReport")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Boby")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdMailAccount")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsHtml")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Subject")
                        .HasColumnType("TEXT");

                    b.HasKey("IdReport");

                    b.HasIndex("IdMailAccount");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("AutoRepo.Data.Entities.Destiny", b =>
                {
                    b.HasOne("AutoRepo.Data.Entities.Report", "Report")
                        .WithMany()
                        .HasForeignKey("IdReport")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoRepo.Data.Entities.Report", b =>
                {
                    b.HasOne("AutoRepo.Data.Entities.MailAccount", "MailAccount")
                        .WithMany()
                        .HasForeignKey("IdMailAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
