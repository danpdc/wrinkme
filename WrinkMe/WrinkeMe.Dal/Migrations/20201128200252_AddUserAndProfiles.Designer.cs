﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WrinkeMe.Dal;

namespace WrinkeMe.Dal.Migrations
{
    [DbContext(typeof(WrinkMeDataContext))]
    [Migration("20201128200252_AddUserAndProfiles")]
    partial class AddUserAndProfiles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WrinkMe.Domain.Models.ShortUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("OriginalUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserProfileId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("ShortUrls");
                });

            modelBuilder.Entity("WrinkMe.Domain.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WrinkMe.Domain.Models.UserAgent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShortUrlId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShortUrlId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("WrinkMe.Domain.Models.UserProfile", b =>
                {
                    b.Property<int>("UserProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserProfileId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("WrinkMe.Domain.Models.ShortUrl", b =>
                {
                    b.HasOne("WrinkMe.Domain.Models.UserProfile", null)
                        .WithMany("Wrinks")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("WrinkMe.Domain.Models.UserAgent", b =>
                {
                    b.HasOne("WrinkMe.Domain.Models.ShortUrl", "ShortUrl")
                        .WithMany("Requests")
                        .HasForeignKey("ShortUrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("WrinkMe.Domain.Models.Browser", "Browser", b1 =>
                        {
                            b1.Property<int>("UserAgentId")
                                .HasColumnType("int");

                            b1.Property<string>("Family")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Major")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Minor")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserAgentId");

                            b1.ToTable("Browsers");

                            b1.WithOwner()
                                .HasForeignKey("UserAgentId");
                        });

                    b.OwnsOne("WrinkMe.Domain.Models.Device", "Device", b1 =>
                        {
                            b1.Property<int>("UserAgentId")
                                .HasColumnType("int");

                            b1.Property<string>("Brand")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Family")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<bool>("IsBot")
                                .HasColumnType("bit");

                            b1.Property<string>("Model")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserAgentId");

                            b1.ToTable("Devices");

                            b1.WithOwner()
                                .HasForeignKey("UserAgentId");
                        });

                    b.OwnsOne("WrinkMe.Domain.Models.OS", "OS", b1 =>
                        {
                            b1.Property<int>("UserAgentId")
                                .HasColumnType("int");

                            b1.Property<string>("Family")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Major")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Minor")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserAgentId");

                            b1.ToTable("OS");

                            b1.WithOwner()
                                .HasForeignKey("UserAgentId");
                        });
                });

            modelBuilder.Entity("WrinkMe.Domain.Models.UserProfile", b =>
                {
                    b.HasOne("WrinkMe.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
