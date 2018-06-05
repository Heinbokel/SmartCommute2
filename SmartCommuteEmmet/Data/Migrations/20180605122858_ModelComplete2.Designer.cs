﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SmartCommuteEmmet.Data;
using System;

namespace SmartCommuteEmmet.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180605122858_ModelComplete2")]
    partial class ModelComplete2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("UserCity")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("UserStreet")
                        .HasMaxLength(50);

                    b.Property<string>("UserZIP");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessCity");

                    b.Property<string>("BusinessDescription");

                    b.Property<string>("BusinessName");

                    b.Property<string>("BusinessStreet");

                    b.Property<string>("BusinessZIP");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.Commute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CommuteDate");

                    b.Property<string>("CommuteDescription");

                    b.Property<int>("CommuteDistance");

                    b.Property<string>("CommuteName");

                    b.Property<bool>("CommuteSaved");

                    b.Property<int>("CommuteTypeId");

                    b.Property<int>("EndPointId");

                    b.Property<int>("StartPointId");

                    b.Property<string>("UserId");

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

                    b.Property<string>("CommuteTypeDescription");

                    b.Property<string>("CommuteTypeName");

                    b.HasKey("Id");

                    b.ToTable("CommuteType");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.EndPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EndPointDescription");

                    b.Property<float>("EndPointLatitude");

                    b.Property<float>("EndPointLongitude");

                    b.Property<string>("EndPointName");

                    b.HasKey("Id");

                    b.ToTable("EndPoint");
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.StartPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StartPointDescription");

                    b.Property<float>("StartPointLatitude");

                    b.Property<float>("StartPointLongitude");

                    b.Property<string>("StartPointName");

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
                        .WithOne()
                        .HasForeignKey("SmartCommuteEmmet.Models.ApplicationUser", "BusinessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartCommuteEmmet.Models.Business", b =>
                {
                    b.HasOne("SmartCommuteEmmet.Models.ApplicationUser", "BusinessTeamCaptain")
                        .WithMany()
                        .HasForeignKey("UserId");
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
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
