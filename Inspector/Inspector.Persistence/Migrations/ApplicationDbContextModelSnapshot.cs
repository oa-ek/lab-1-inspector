﻿// <auto-generated />
using System;
using Inspector.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inspector.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inspector.Domain.Entities.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComplaintId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserGiveId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserTakeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ComplaintId");

                    b.HasIndex("UserGiveId");

                    b.HasIndex("UserTakeId");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("Inspector.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<Guid?>("OrganizationId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId1");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Inspector.Domain.Entities.Complaint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("bit");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrganizationId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrganizationId2")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResponceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("OrganizationId1");

                    b.HasIndex("OrganizationId2");

                    b.HasIndex("UserId");

                    b.ToTable("Complaints");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9f44fa37-b771-4df1-97f5-f4f35da222fb"),
                            CreateDate = new DateTime(2023, 12, 18, 5, 4, 30, 26, DateTimeKind.Utc).AddTicks(6492),
                            CreatedDate = new DateTime(2023, 12, 18, 7, 4, 30, 26, DateTimeKind.Local).AddTicks(6504),
                            Description = "There are problem with road",
                            IsArchive = false,
                            OrganizationId = new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"),
                            Status = "created",
                            UpdateDate = new DateTime(2023, 12, 18, 5, 4, 30, 26, DateTimeKind.Utc).AddTicks(6494),
                            UserId = "49b754b0-8831-4b1a-a44f-8e18a0c2578e"
                        },
                        new
                        {
                            Id = new Guid("5d201a67-8c0a-4f7b-91e6-ccd81e1b18be"),
                            CreateDate = new DateTime(2023, 12, 18, 5, 4, 30, 26, DateTimeKind.Utc).AddTicks(6676),
                            CreatedDate = new DateTime(2023, 12, 18, 7, 4, 30, 26, DateTimeKind.Local).AddTicks(6677),
                            Description = "There are problem with water",
                            IsArchive = false,
                            OrganizationId = new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"),
                            Status = "created",
                            UpdateDate = new DateTime(2023, 12, 18, 5, 4, 30, 26, DateTimeKind.Utc).AddTicks(6676),
                            UserId = "49b754b0-8831-4b1a-a44f-8e18a0c2578e"
                        },
                        new
                        {
                            Id = new Guid("ad4f92a0-4650-4344-b8fa-82629f946992"),
                            CreateDate = new DateTime(2023, 12, 18, 5, 4, 30, 26, DateTimeKind.Utc).AddTicks(6681),
                            CreatedDate = new DateTime(2023, 12, 18, 7, 4, 30, 26, DateTimeKind.Local).AddTicks(6682),
                            Description = "There are problem with helth",
                            IsArchive = false,
                            OrganizationId = new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"),
                            Status = "created",
                            UpdateDate = new DateTime(2023, 12, 18, 5, 4, 30, 26, DateTimeKind.Utc).AddTicks(6681),
                            UserId = "49b754b0-8831-4b1a-a44f-8e18a0c2578e"
                        });
                });

            modelBuilder.Entity("Inspector.Domain.Entities.ComplaintFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComplaintId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ComplaintId");

                    b.ToTable("ComplaintFiles");
                });

            modelBuilder.Entity("Inspector.Domain.Entities.Employment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("Employments");
                });

            modelBuilder.Entity("Inspector.Domain.Entities.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Organization");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"),
                            CreateDate = new DateTime(2023, 12, 18, 5, 4, 30, 26, DateTimeKind.Utc).AddTicks(7332),
                            Description = "Solves problems related to the road surface",
                            Name = "Road Organization",
                            UpdateDate = new DateTime(2023, 12, 18, 5, 4, 30, 26, DateTimeKind.Utc).AddTicks(7332)
                        });
                });

            modelBuilder.Entity("Inspector.Domain.Entities.Response", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComplaintId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserTakeId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Responce");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "c0a6ca35-7241-4a9d-a836-136c48c49b2f",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "3d2fb1f4-7a83-46fa-83ea-56d171cbe092",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        },
                        new
                        {
                            Id = "3",
                            ConcurrencyStamp = "d0d6326c-d26d-45c8-b26d-30e15e9d3945",
                            Name = "Company",
                            NormalizedName = "COMPANY"
                        },
                        new
                        {
                            Id = "4",
                            ConcurrencyStamp = "aa46da5e-c31a-43ed-9833-166a221fbfd9",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "49b754b0-8831-4b1a-a44f-8e18a0c2578e",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45",
                            RoleId = "3"
                        },
                        new
                        {
                            UserId = "c8b05623-d42b-4a9f-947e-dcd54538ee1d",
                            RoleId = "4"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Inspector.Domain.Entities.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("OrganizationId");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "49b754b0-8831-4b1a-a44f-8e18a0c2578e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "459a14b0-4b14-4819-ad3f-ba627f77d539",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGVdgmBXLTjfa1bp70cgntU0KB79/Pm72zDX/37+py3ZP3yK1vxgSoQJOix/l18pEA==",
                            PhoneNumber = "123-456-7890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e9317a51-15df-4f69-80c3-d3e129aaaac6",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com",
                            FullName = "Jane Smith"
                        },
                        new
                        {
                            Id = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "00ab5c6a-057e-46d2-9ac0-09418079d92b",
                            Email = "user@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@GMAIL.COM",
                            NormalizedUserName = "USER@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOB5ok4R2SEUorg19xW4CfpbtnWFHizZMT0AhozJ7lCm5B6Yqm3RuI2msSypYBBRYg==",
                            PhoneNumber = "123-456-7890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "40edadae-b220-4c9c-9736-41dd3fa91fb1",
                            TwoFactorEnabled = false,
                            UserName = "user@gmail.com",
                            FullName = "John Doe"
                        },
                        new
                        {
                            Id = "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4b3d5cfe-e147-4f1c-9aa6-fd3d76a4fecf",
                            Email = "roadorg@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ROADORG@GMAIL.COM",
                            NormalizedUserName = "ROADORG@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGrnNENrZOFQm0CDVx7G0SWxZrXjL/YFv70tWxz/z33XnetIBldmDyG+8I16BeLxWQ==",
                            PhoneNumber = "123-456-7890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "943c719f-41d3-4e73-8299-842ff0d037a7",
                            TwoFactorEnabled = false,
                            UserName = "roadorg@gmail.com",
                            FullName = "Road Organization",
                            OrganizationId = new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff")
                        },
                        new
                        {
                            Id = "c8b05623-d42b-4a9f-947e-dcd54538ee1d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "da4a81c6-c5dd-4a6c-90ff-9aa1c212a77b",
                            Email = "employee@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "EMPLOYEE@GMAIL.COM",
                            NormalizedUserName = "EMPLOYEE@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPBkJDGnCuOPZ2i6u4WxTz290wJ3wIdlgUKoirXIkHh22EnQAk2qkYe/T5hHbRGNmw==",
                            PhoneNumber = "123-456-7890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2cbd8504-c84f-4f5b-a32e-657010e729bc",
                            TwoFactorEnabled = false,
                            UserName = "employee@gmail.com",
                            FullName = "Bob Smith",
                            OrganizationId = new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff")
                        },
                        new
                        {
                            Id = "6f8d2151-0a57-4bf9-8aaf-6b5ec69c78e2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f2c60d7d-ddfa-4046-8c7a-7e99f3b831bf",
                            Email = "-",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumber = "-",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e4b0b5d2-539e-4811-a6d6-192e9328ce80",
                            TwoFactorEnabled = false,
                            FullName = "none"
                        });
                });

            modelBuilder.Entity("Inspector.Domain.Entities.Assignment", b =>
                {
                    b.HasOne("Inspector.Domain.Entities.Complaint", "Complaint")
                        .WithMany()
                        .HasForeignKey("ComplaintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inspector.Domain.Entities.ApplicationUser", "UserGive")
                        .WithMany("AssignmentsGiven")
                        .HasForeignKey("UserGiveId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Inspector.Domain.Entities.ApplicationUser", "UserTake")
                        .WithMany("AssignmentsTaken")
                        .HasForeignKey("UserTakeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Complaint");

                    b.Navigation("UserGive");

                    b.Navigation("UserTake");
                });

            modelBuilder.Entity("Inspector.Domain.Entities.Category", b =>
                {
                    b.HasOne("Inspector.Domain.Entities.Organization", null)
                        .WithMany("Categories")
                        .HasForeignKey("OrganizationId1");
                });

            modelBuilder.Entity("Inspector.Domain.Entities.Complaint", b =>
                {
                    b.HasOne("Inspector.Domain.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inspector.Domain.Entities.Organization", null)
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("OrganizationId1");

                    b.HasOne("Inspector.Domain.Entities.Organization", null)
                        .WithMany("Complaints")
                        .HasForeignKey("OrganizationId2");

                    b.HasOne("Inspector.Domain.Entities.ApplicationUser", "User")
                        .WithMany("Complaints")
                        .HasForeignKey("UserId");

                    b.Navigation("Organization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Inspector.Domain.Entities.ComplaintFile", b =>
                {
                    b.HasOne("Inspector.Domain.Entities.Complaint", "Complaint")
                        .WithMany("ComplaintFiles")
                        .HasForeignKey("ComplaintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Complaint");
                });

            modelBuilder.Entity("Inspector.Domain.Entities.Employment", b =>
                {
                    b.HasOne("Inspector.Domain.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.HasOne("Inspector.Domain.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Inspector.Domain.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Inspector.Domain.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Inspector.Domain.Entities.Complaint", b =>
                {
                    b.Navigation("ComplaintFiles");
                });

            modelBuilder.Entity("Inspector.Domain.Entities.Organization", b =>
                {
                    b.Navigation("ApplicationUsers");

                    b.Navigation("Categories");

                    b.Navigation("Complaints");
                });

            modelBuilder.Entity("Inspector.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("AssignmentsGiven");

                    b.Navigation("AssignmentsTaken");

                    b.Navigation("Complaints");
                });
#pragma warning restore 612, 618
        }
    }
}
