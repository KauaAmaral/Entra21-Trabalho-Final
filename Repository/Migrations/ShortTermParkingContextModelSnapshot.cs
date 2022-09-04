﻿// <auto-generated />
using System;
using Entra21.CSharp.Area21.RepositoryDataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entra21.CSharp.Area21.Repository.Migrations
{
    [DbContext(typeof(ShortTermParkingContext))]
    partial class ShortTermParkingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entra21.CSharp.Area21.Repository.Entities.Guard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("create_at");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnName("identification_number");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true)
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("update_at");

                    b.Property<int>("UserId")
                        .HasColumnType("INT")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("guards", (string)null);
                });

            modelBuilder.Entity("Entra21.CSharp.Area21.Repository.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("address");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("create_at");

                    b.Property<int>("GuardId")
                        .HasColumnType("INT")
                        .HasColumnName("guard_id");

                    b.Property<bool>("RegisteredVehicle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false)
                        .HasColumnName("register_vehicle");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true)
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdatedAt")
                        .IsRequired()
                        .HasColumnType("DATETIME2")
                        .HasColumnName("update_at");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INT")
                        .HasColumnName("vehicle_id");

                    b.HasKey("Id");

                    b.HasIndex("GuardId");

                    b.HasIndex("VehicleId");

                    b.ToTable("notification", (string)null);
                });

            modelBuilder.Entity("Entra21.CSharp.Area21.Repository.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("create_at");

                    b.Property<bool>("Status")
                        .HasColumnType("BIT");

                    b.Property<DateTime?>("UpdatedAt")
                        .IsRequired()
                        .HasColumnType("DATETIME2")
                        .HasColumnName("update_at");

                    b.Property<int>("UserId")
                        .HasColumnType("INT")
                        .HasColumnName("user_id");

                    b.Property<int?>("VehicleId")
                        .IsRequired()
                        .HasColumnType("INT")
                        .HasColumnName("vehicle_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("payments", (string)null);
                });

            modelBuilder.Entity("Entra21.CSharp.Area21.Repository.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)");

                    b.Property<bool>("Status")
                        .HasColumnType("BIT");

                    b.Property<DateTime?>("UpdatedAt")
                        .IsRequired()
                        .HasColumnType("DATETIME2");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Entra21.CSharp.Area21.Repository.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("created_at");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("VARCHAR(8)")
                        .HasColumnName("license_plate");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<byte>("Type")
                        .HasColumnType("TINYINT")
                        .HasColumnName("vehicle_type");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DATETIME2")
                        .HasColumnName("update_at");

                    b.Property<int>("UserId")
                        .HasColumnType("INT")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("vehicles", (string)null);
                });

            modelBuilder.Entity("Entra21.CSharp.Area21.Repository.Entities.Guard", b =>
                {
                    b.HasOne("Entra21.CSharp.Area21.Repository.Entities.User", "User")
                        .WithMany("Guards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entra21.CSharp.Area21.Repository.Entities.Notification", b =>
                {
                    b.HasOne("Entra21.CSharp.Area21.Repository.Entities.Guard", "Guard")
                        .WithMany("Notifications")
                        .HasForeignKey("GuardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entra21.CSharp.Area21.Repository.Entities.Vehicle", "Vehicle")
                        .WithMany("Notifications")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Guard");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Entra21.CSharp.Area21.Repository.Entities.Payment", b =>
                {
                    b.HasOne("Entra21.CSharp.Area21.Repository.Entities.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entra21.CSharp.Area21.Repository.Entities.Vehicle", "Vehicle")
                        .WithMany("Payments")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Entra21.CSharp.Area21.Repository.Entities.Vehicle", b =>
                {
                    b.HasOne("Entra21.CSharp.Area21.Repository.Entities.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entra21.CSharp.Area21.Repository.Entities.Guard", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("Entra21.CSharp.Area21.Repository.Entities.User", b =>
                {
                    b.Navigation("Guards");

                    b.Navigation("Payments");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Entra21.CSharp.Area21.Repository.Entities.Vehicle", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
