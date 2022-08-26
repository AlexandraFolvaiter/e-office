﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eOffice.Leave.DataAccess.Connections;

#nullable disable

namespace eOffice.Leave.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("eOffice.Leave.DataAccess.Entities.LeaveBalance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DaysOff")
                        .HasColumnType("int");

                    b.Property<int>("LearningDays")
                        .HasColumnType("int");

                    b.Property<Guid>("OnboardingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UnpaidDaysOff")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LeaveBalances");
                });
#pragma warning restore 612, 618
        }
    }
}
