﻿// <auto-generated />
using E_wasteManagementWebapi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_wasteManagementWebapi.Migrations
{
    [DbContext(typeof(E_WasteDbContext))]
    partial class E_WasteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("E_wasteManagementWebapi.Model.Center", b =>
                {
                    b.Property<int>("CenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CenterId"));

                    b.Property<string>("CenterLocation")
                        .HasColumnType("longtext");

                    b.Property<string>("Center_Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone_number")
                        .HasColumnType("longtext");

                    b.Property<string>("personalEmail")
                        .HasColumnType("longtext");

                    b.HasKey("CenterId");

                    b.ToTable("centers");
                });

            modelBuilder.Entity("E_wasteManagementWebapi.Model.E_WasteItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("ApprovedItemStatus")
                        .HasColumnType("longtext");

                    b.Property<string>("ItemCondition")
                        .HasColumnType("longtext");

                    b.Property<string>("ItemLocation")
                        .HasColumnType("longtext");

                    b.Property<string>("ItemName")
                        .HasColumnType("longtext");

                    b.Property<int>("ItemQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Itemtype")
                        .HasColumnType("longtext");

                    b.Property<string>("RequestStatus")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("waste_items");
                });

            modelBuilder.Entity("E_wasteManagementWebapi.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Cpassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("E_wasteManagementWebapi.Model.E_WasteItem", b =>
                {
                    b.HasOne("E_wasteManagementWebapi.Model.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}