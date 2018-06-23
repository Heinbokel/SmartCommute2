﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SmartCommuteEmmet.Data;
using System;

namespace SmartCommuteEmmet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd();

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
                        .ValueGeneratedOnAdd();

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
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

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

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("BusinessId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime>("DateRegistered");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25);

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

                    b.Property<string>("UserBio");

                    b.Property<string>("UserCity")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("UserPhoto")
                        .IsRequired();

                    b.Property<string>("UserStreet")
                        .HasMaxLength(50);

                    b.Property<string>("UserZIP");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.Breakfast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BreakfastCity")
                        .IsRequired();

                    b.Property<string>("BreakfastDescription");

                    b.Property<string>("BreakfastLink");

                    b.Property<string>("BreakfastName")
                        .IsRequired();

                    b.Property<string>("BreakfastStreet")
                        .IsRequired();

                    b.Property<string>("BreakfastZIP");

                    b.HasKey("Id");

                    b.ToTable("Breakfast");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessCity");

                    b.Property<string>("BusinessDescription");

                    b.Property<string>("BusinessName")
                        .IsRequired();

                    b.Property<string>("BusinessStreet");

                    b.Property<string>("BusinessZIP");

                    b.HasKey("Id");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.Commute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CommuteDate");

                    b.Property<string>("CommuteDescription");

                    b.Property<int>("CommuteDistance");

                    b.Property<string>("CommuteName")
                        .IsRequired();

                    b.Property<bool>("CommuteSaved");

                    b.Property<int>("CommuteTypeId");

                    b.Property<string>("EndPointCustom")
                        .HasMaxLength(25);

                    b.Property<int?>("EndPointId")
                        .IsRequired();

                    b.Property<string>("StartPointCustom")
                        .HasMaxLength(25);

                    b.Property<int?>("StartPointId")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CommuteTypeId");

                    b.HasIndex("EndPointId");

                    b.HasIndex("StartPointId");

                    b.HasIndex("UserId");

                    b.ToTable("Commute");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.CommuteType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommutePointsAwarded");

                    b.Property<string>("CommuteTypeDescription")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CommuteTypeName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("CommuteType");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.ConfigDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("RegisterByDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("ConfigDate");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DocumentDescription")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("DocumentFilePath");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.EndPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EndPointDescription")
                        .HasMaxLength(50);

                    b.Property<float?>("EndPointLatitude");

                    b.Property<float?>("EndPointLongitude");

                    b.Property<string>("EndPointName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("EndPoint");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RequiredCommutes");

                    b.Property<int>("RequiredMiles");

                    b.Property<string>("RewardDescription")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("RewardName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Reward");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SponsorDescription")
                        .HasMaxLength(50);

                    b.Property<string>("SponsorImagePath");

                    b.Property<string>("SponsorLink")
                        .IsRequired();

                    b.Property<string>("SponsorName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Sponsor");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.StartPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StartPointDescription")
                        .HasMaxLength(50);

                    b.Property<float?>("StartPointLatitude");

                    b.Property<float?>("StartPointLongitude");

                    b.Property<string>("StartPointName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("StartPoint");
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
                    b.HasOne("SmartCommuteEmmet.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SmartCommuteEmmet.Models.ApplicationUser")
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

                    b.HasOne("SmartCommuteEmmet.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SmartCommuteEmmet.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.ApplicationUser", b =>
                {
                    b.HasOne("SmartCommuteEmmet.Models.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.Commute", b =>
                {
                    b.HasOne("SmartCommuteEmmet.Models.CommuteType", "CommuteType")
                        .WithMany()
                        .HasForeignKey("CommuteTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartCommuteEmmet.Models.EndPoint", "EndPoint")
                        .WithMany()
                        .HasForeignKey("EndPointId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartCommuteEmmet.Models.StartPoint", "StartPoint")
                        .WithMany()
                        .HasForeignKey("StartPointId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartCommuteEmmet.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
