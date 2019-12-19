﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TwitterBackEnd.Data;

namespace TwitterBackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190522062030_Initialize3")]
    partial class Initialize3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
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

            modelBuilder.Entity("TwitterBackEnd.Models.Domein.Gebruiker", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

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

                    b.Property<string>("VolledigeNaam")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Gebruiker");
                });

            modelBuilder.Entity("TwitterBackEnd.Models.Domein.GevolgdenEnVolgersTussentabel", b =>
                {
                    b.Property<string>("VolgerId");

                    b.Property<string>("GevolgdeId");

                    b.HasKey("VolgerId", "GevolgdeId");

                    b.HasIndex("GevolgdeId");

                    b.ToTable("GevolgdenEnVolgersTussentabel");
                });

            modelBuilder.Entity("TwitterBackEnd.Models.Domein.Retweet", b =>
                {
                    b.Property<int>("RetweetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Boodschap");

                    b.Property<string>("GebruikerId");

                    b.Property<int?>("RetweetId1");

                    b.Property<DateTime>("TweetDatum");

                    b.Property<int?>("TweetId");

                    b.HasKey("RetweetId");

                    b.HasIndex("GebruikerId");

                    b.HasIndex("RetweetId1");

                    b.HasIndex("TweetId");

                    b.ToTable("Retweets");
                });

            modelBuilder.Entity("TwitterBackEnd.Models.Domein.Tweet", b =>
                {
                    b.Property<int>("TweetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Boodschap");

                    b.Property<string>("GebruikerId");

                    b.Property<DateTime>("TweetDatum");

                    b.HasKey("TweetId");

                    b.HasIndex("GebruikerId");

                    b.ToTable("Tweets");
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
                    b.HasOne("TwitterBackEnd.Models.Domein.Gebruiker")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TwitterBackEnd.Models.Domein.Gebruiker")
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

                    b.HasOne("TwitterBackEnd.Models.Domein.Gebruiker")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TwitterBackEnd.Models.Domein.Gebruiker")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TwitterBackEnd.Models.Domein.GevolgdenEnVolgersTussentabel", b =>
                {
                    b.HasOne("TwitterBackEnd.Models.Domein.Gebruiker", "Gevolgde")
                        .WithMany("TussentabelKantVanGevolden")
                        .HasForeignKey("GevolgdeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TwitterBackEnd.Models.Domein.Gebruiker", "Volger")
                        .WithMany("TussentabelKantVanVolgers")
                        .HasForeignKey("VolgerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TwitterBackEnd.Models.Domein.Retweet", b =>
                {
                    b.HasOne("TwitterBackEnd.Models.Domein.Gebruiker", "Gebruiker")
                        .WithMany("Retweets")
                        .HasForeignKey("GebruikerId");

                    b.HasOne("TwitterBackEnd.Models.Domein.Retweet")
                        .WithMany("Reretweets")
                        .HasForeignKey("RetweetId1");

                    b.HasOne("TwitterBackEnd.Models.Domein.Tweet", "Tweet")
                        .WithMany()
                        .HasForeignKey("TweetId");
                });

            modelBuilder.Entity("TwitterBackEnd.Models.Domein.Tweet", b =>
                {
                    b.HasOne("TwitterBackEnd.Models.Domein.Gebruiker")
                        .WithMany("Tweets")
                        .HasForeignKey("GebruikerId");
                });
#pragma warning restore 612, 618
        }
    }
}