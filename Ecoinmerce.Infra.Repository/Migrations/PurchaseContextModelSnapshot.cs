﻿// <auto-generated />
using System;
using Ecoinmerce.Infra.Repository.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations
{
    [DbContext(typeof(PurchaseContext))]
    partial class PurchaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ecoinmerce.Domain.Entities.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BlockHash")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("CostumerWalletAddress")
                        .IsRequired()
                        .HasMaxLength(42)
                        .HasColumnType("nvarchar(42)");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EcommerceWalletAddress")
                        .IsRequired()
                        .HasMaxLength(42)
                        .HasColumnType("nvarchar(42)");

                    b.Property<bool>("Failed")
                        .HasColumnType("bit");

                    b.Property<string>("Observation")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("PurchaseCheckId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseEventFailId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseEventId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionHash")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime?>("UpdatedAt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseCheckId")
                        .IsUnique();

                    b.HasIndex("PurchaseEventFailId")
                        .IsUnique();

                    b.HasIndex("PurchaseEventId")
                        .IsUnique();

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Ecoinmerce.Domain.Entities.PurchaseCheck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CheckOverCounter")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PurchaseChecks");
                });

            modelBuilder.Entity("Ecoinmerce.Domain.Entities.PurchaseEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("AmountPaidInEther")
                        .HasPrecision(28, 18)
                        .HasColumnType("decimal(28,18)");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaidAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PurchaseIdentifier")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<DateTime?>("UpdatedAt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PurchaseEvents");
                });

            modelBuilder.Entity("Ecoinmerce.Domain.Entities.PurchaseEventFail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BlockHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<string>("LogAddress")
                        .IsRequired()
                        .HasMaxLength(42)
                        .HasColumnType("nvarchar(42)");

                    b.Property<string>("Observation")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime?>("UpdatedAt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PurchaseEventFails");
                });

            modelBuilder.Entity("Ecoinmerce.Domain.Entities.Purchase", b =>
                {
                    b.HasOne("Ecoinmerce.Domain.Entities.PurchaseCheck", "PurchaseCheck")
                        .WithOne("Purchase")
                        .HasForeignKey("Ecoinmerce.Domain.Entities.Purchase", "PurchaseCheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecoinmerce.Domain.Entities.PurchaseEventFail", "PurchaseEventFail")
                        .WithOne("Purchase")
                        .HasForeignKey("Ecoinmerce.Domain.Entities.Purchase", "PurchaseEventFailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecoinmerce.Domain.Entities.PurchaseEvent", "PurchaseEvent")
                        .WithOne("Purchase")
                        .HasForeignKey("Ecoinmerce.Domain.Entities.Purchase", "PurchaseEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchaseCheck");

                    b.Navigation("PurchaseEvent");

                    b.Navigation("PurchaseEventFail");
                });

            modelBuilder.Entity("Ecoinmerce.Domain.Entities.PurchaseCheck", b =>
                {
                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("Ecoinmerce.Domain.Entities.PurchaseEvent", b =>
                {
                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("Ecoinmerce.Domain.Entities.PurchaseEventFail", b =>
                {
                    b.Navigation("Purchase");
                });
#pragma warning restore 612, 618
        }
    }
}