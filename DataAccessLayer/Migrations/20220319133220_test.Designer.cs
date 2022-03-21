﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(MusteriBankDbContext))]
    [Migration("20220319133220_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Entities.SPSonuc", b =>
                {
                    b.Property<DateTime>("FATURA_TARIHI")
                        .HasColumnType("datetime2");

                    b.Property<int>("MUSTERI_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("toplamBorc")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("SPSonuclar");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.musteri_fatura_table", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FATURA_TARIHI")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FATURA_TUTARI")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MUSTERI_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ODEME_TARIHI")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("MUSTERI_ID");

                    b.ToTable("musteri_fatura_table");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.musteri_tanim_table", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UNVAN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("musteri_tanim_table");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.musteri_fatura_table", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.musteri_tanim_table", "MUSTERI")
                        .WithMany("FATURA")
                        .HasForeignKey("MUSTERI_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MUSTERI");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.musteri_tanim_table", b =>
                {
                    b.Navigation("FATURA");
                });
#pragma warning restore 612, 618
        }
    }
}
