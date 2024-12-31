﻿// <auto-generated />
using System;
using InsurancePolicyApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InsurancePolicyApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241230145849_AddAuditFieldsAndSoftDelete")]
    partial class AddAuditFieldsAndSoftDelete
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("InsurancePolicyApi.Models.InsurancePolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CoverageType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PolicyHolderName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PolicyNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PremiumAmount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("InsurancePolicies");
                });
#pragma warning restore 612, 618
        }
    }
}
