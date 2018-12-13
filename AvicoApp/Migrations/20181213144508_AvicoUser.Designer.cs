﻿// <auto-generated />
using System;
using AvicoApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AvicoApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181213144508_AvicoUser")]
    partial class AvicoUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AvicoApp.Models.AvicoUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AvicoApp.Models.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<int?>("HotelRoomID")
                        .IsRequired();

                    b.Property<int>("NumberOfRooms");

                    b.Property<int>("PeopleNumber");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("HotelRoomID");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("AvicoApp.Models.Establishment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Mail")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ManagerId")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("PictureUrl")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Tel")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("establishment_type")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ManagerId");

                    b.ToTable("Establishments");

                    b.HasDiscriminator<string>("establishment_type").HasValue("Establishment");
                });

            modelBuilder.Entity("AvicoApp.Models.HotelRoom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("HotelID")
                        .IsRequired();

                    b.Property<int>("NumberOfRooms");

                    b.Property<int>("PeopleNumber");

                    b.HasKey("ID");

                    b.HasIndex("HotelID");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("AvicoApp.Models.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("EstablishmentID")
                        .IsRequired();

                    b.Property<int>("Grade");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("EstablishmentID");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AvicoApp.Models.Hotel", b =>
                {
                    b.HasBaseType("AvicoApp.Models.Establishment");


                    b.ToTable("Hotel");

                    b.HasDiscriminator().HasValue("establishment_hotel");
                });

            modelBuilder.Entity("AvicoApp.Models.Restaurant", b =>
                {
                    b.HasBaseType("AvicoApp.Models.Establishment");


                    b.ToTable("Restaurant");

                    b.HasDiscriminator().HasValue("establishment_restaurant");
                });

            modelBuilder.Entity("AvicoApp.Models.Booking", b =>
                {
                    b.HasOne("AvicoApp.Models.HotelRoom", "HotelRoom")
                        .WithMany("Bookings")
                        .HasForeignKey("HotelRoomID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AvicoApp.Models.AvicoUser", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AvicoApp.Models.Establishment", b =>
                {
                    b.HasOne("AvicoApp.Models.AvicoUser", "Manager")
                        .WithMany("Establishments")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("AvicoApp.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int?>("EstablishmentID")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("Street")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("varchar(255)");

                            b1.ToTable("Establishments");

                            b1.HasOne("AvicoApp.Models.Establishment")
                                .WithOne("Address")
                                .HasForeignKey("AvicoApp.Models.Address", "EstablishmentID")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("AvicoApp.Models.HotelRoom", b =>
                {
                    b.HasOne("AvicoApp.Models.Hotel", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AvicoApp.Models.Review", b =>
                {
                    b.HasOne("AvicoApp.Models.Establishment", "Establishment")
                        .WithMany("Reviews")
                        .HasForeignKey("EstablishmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AvicoApp.Models.AvicoUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AvicoApp.Models.AvicoUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AvicoApp.Models.AvicoUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AvicoApp.Models.AvicoUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AvicoApp.Models.AvicoUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}