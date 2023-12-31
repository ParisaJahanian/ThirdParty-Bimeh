﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(FireDbContext))]
    [Migration("20230831092857_InitialDb")]
    partial class InitialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bimeh.Entities.FireInsuranceLog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<double>("AppliancesValue")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<int>("AreaUnitPriceId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("CoverageIds")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("EstateTypeId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("StructureTypeId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<double>("TotalArea")
                        .HasColumnType("BINARY_DOUBLE");

                    b.HasKey("Id");

                    b.ToTable("FireInsuranceLogs");
                });

            modelBuilder.Entity("CarElectronicTolls.Entities.FireReqLog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("JsonReq")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("LogDateTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("PublicAppId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PublicReqId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("FireReqLogs");
                });

            modelBuilder.Entity("CarElectronicTolls.Entities.FireResLog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("CarTollsReqLogId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("HTTPStatusCode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("JsonRes")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PublicReqId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ReqLogId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ResCode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("CarTollsReqLogId");

                    b.ToTable("FireResLogs");
                });

            modelBuilder.Entity("Domain.Entities.AccessTokenEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("TokenDateTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.ToTable("AccessTokens");
                });

            modelBuilder.Entity("CarElectronicTolls.Entities.FireResLog", b =>
                {
                    b.HasOne("CarElectronicTolls.Entities.FireReqLog", "CarTollsReqLog")
                        .WithMany("fireResLogs")
                        .HasForeignKey("CarTollsReqLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarTollsReqLog");
                });

            modelBuilder.Entity("CarElectronicTolls.Entities.FireReqLog", b =>
                {
                    b.Navigation("fireResLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
