﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagement.Persistances.Contexts;

#nullable disable

namespace TaskManagement.Persistances.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241224111515_v")]
    partial class v
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TaskManagement.Domain.Entities.AddClients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("CityCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("VARCHAR(3)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR(120)");

                    b.Property<string>("ClientStatusCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("VARCHAR(5)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("VARCHAR(3)");

                    b.Property<string>("GSTNumber")
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR(15)");

                    b.Property<string>("StateCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("VARCHAR(3)");

                    b.HasKey("Id");

                    b.HasIndex("CityCode");

                    b.HasIndex("ClientStatusCode");

                    b.HasIndex("CountryCode");

                    b.HasIndex("StateCode");

                    b.ToTable("AddClients", (string)null);
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.City", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(3)
                        .HasColumnType("VARCHAR(3)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR(120)");

                    b.HasKey("Code");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.ClientStatus", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(5)
                        .HasColumnType("VARCHAR(5)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR(120)");

                    b.HasKey("Code");

                    b.ToTable("ClientStatuses", (string)null);
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.ContactDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR(15)");

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR(120)");

                    b.Property<string>("MailID")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.ToTable("ContactDetails", (string)null);
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Country", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(3)
                        .HasColumnType("VARCHAR(3)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR(120)");

                    b.HasKey("Code");

                    b.ToTable("Countries", (string)null);
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.State", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(3)
                        .HasColumnType("VARCHAR(3)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR(120)");

                    b.HasKey("Code");

                    b.ToTable("States", (string)null);
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.AddClients", b =>
                {
                    b.HasOne("TaskManagement.Domain.Entities.City", "City")
                        .WithMany("AddClients")
                        .HasForeignKey("CityCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskManagement.Domain.Entities.ClientStatus", "ClientStatus")
                        .WithMany("AddClients")
                        .HasForeignKey("ClientStatusCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskManagement.Domain.Entities.Country", "Country")
                        .WithMany("AddClients")
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskManagement.Domain.Entities.State", "State")
                        .WithMany("AddClients")
                        .HasForeignKey("StateCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("ClientStatus");

                    b.Navigation("Country");

                    b.Navigation("State");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.City", b =>
                {
                    b.Navigation("AddClients");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.ClientStatus", b =>
                {
                    b.Navigation("AddClients");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Country", b =>
                {
                    b.Navigation("AddClients");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.State", b =>
                {
                    b.Navigation("AddClients");
                });
#pragma warning restore 612, 618
        }
    }
}