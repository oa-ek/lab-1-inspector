using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inspector.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserTakeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responce", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Organization_OrganizationId1",
                        column: x => x.OrganizationId1,
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrganizationId2 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Complaints_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Complaints_Organization_OrganizationId1",
                        column: x => x.OrganizationId1,
                        principalTable: "Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Complaints_Organization_OrganizationId2",
                        column: x => x.OrganizationId2,
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employments_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGiveId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserTakeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignment_AspNetUsers_UserGiveId",
                        column: x => x.UserGiveId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignment_AspNetUsers_UserTakeId",
                        column: x => x.UserTakeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignment_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintFiles_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "d705a666-f645-4f65-8a1e-c20d942b4f26", "Admin", "ADMIN" },
                    { "2", "ee7c29b6-13fa-45c1-b72b-7a63489fec1e", "Customer", "CUSTOMER" },
                    { "3", "5a638e80-4b53-40cd-9394-aafbe4035b23", "Company", "COMPANY" },
                    { "4", "390fa7c8-0450-4e87-a6ae-abae2331aacb", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OrganizationId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "49b754b0-8831-4b1a-a44f-8e18a0c2578e", 0, "49b39cb1-c9fa-4856-a441-8b9622bdea39", "ApplicationUser", "admin@gmail.com", true, "Jane Smith", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", null, "AQAAAAIAAYagAAAAEIw4iPiCaHVAxxvSZEMGCsDuMeEeLcRjVhVV4Rvdxcq23Fnsfu8puPzNrps32BER0A==", "123-456-7890", false, "660d80db-5ba0-4ac0-afef-b86d6fb6dd9d", false, "admin@gmail.com" },
                    { "6f8d2151-0a57-4bf9-8aaf-6b5ec69c78e2", 0, "7885a38b-731c-4e6b-8627-53986cb88be0", "ApplicationUser", "-", false, "none", false, null, null, null, null, null, "-", false, "6f65c7e7-f71c-4e5d-9efe-27be666ade5f", false, null },
                    { "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", 0, "f5876d36-fdbc-485b-b3ac-88d4c2fed389", "ApplicationUser", "user@gmail.com", true, "John Doe", false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", null, "AQAAAAIAAYagAAAAEF7oyE8pENdQ3VEHX8oygDOVtdYOJ7u1A0IMpGwUfLHr0Kc5hYhBPatpIXT20w7GPw==", "123-456-7890", false, "f45329ee-f170-419e-a105-5529e7ac32ab", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "Id", "CreateDate", "Description", "Name", "UpdateDate" },
                values: new object[] { new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"), new DateTime(2023, 12, 9, 17, 21, 15, 164, DateTimeKind.Utc).AddTicks(2034), "Solves problems related to the road surface", "Road Organization", new DateTime(2023, 12, 9, 17, 21, 15, 164, DateTimeKind.Utc).AddTicks(2034) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "49b754b0-8831-4b1a-a44f-8e18a0c2578e" },
                    { "2", "edb4f3c1-cf69-4b07-aafb-915d6d58f23d" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OrganizationId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45", 0, "6cbd7116-168f-437a-82a6-3ca2bc76a8df", "ApplicationUser", "roadorg@gmail.com", true, "Road Organization", false, null, "ROADORG@GMAIL.COM", "ROADORG@GMAIL.COM", new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"), "AQAAAAIAAYagAAAAEKX02jx0wasj490jbbcRFgrFU/5dCEP7BAXWnzwcNjDXEIS54KRVJAB2HQTX5fbHAA==", "123-456-7890", false, "a347e66c-408d-4fb0-83e1-6ba30126636b", false, "roadorg@gmail.com" },
                    { "c8b05623-d42b-4a9f-947e-dcd54538ee1d", 0, "7ce50451-3886-4924-ba22-749ed06d972e", "ApplicationUser", "employee@gmail.com", true, "Bob Smith", false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"), "AQAAAAIAAYagAAAAEH9f42kbAZTrJn7q1ckOZtrXNIar1tCCjmefpDhdfb0/PSUpooCRP4tszw7/bWu1kw==", "123-456-7890", false, "5748f72f-da07-499b-b814-99ec283a77a8", false, "employee@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "CreateDate", "CreatedDate", "Description", "File", "IsArchive", "OrganizationId", "OrganizationId1", "OrganizationId2", "ResponceId", "Status", "UpdateDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("24caac30-cc66-41b7-9db5-c95c794376e6"), new DateTime(2023, 12, 9, 17, 21, 15, 164, DateTimeKind.Utc).AddTicks(1553), new DateTime(2023, 12, 9, 19, 21, 15, 164, DateTimeKind.Local).AddTicks(1554), "There are problem with helth", null, false, new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"), null, null, null, "created", new DateTime(2023, 12, 9, 17, 21, 15, 164, DateTimeKind.Utc).AddTicks(1553), "49b754b0-8831-4b1a-a44f-8e18a0c2578e" },
                    { new Guid("be4485aa-0976-4bcb-b8f4-6ebe59831829"), new DateTime(2023, 12, 9, 17, 21, 15, 164, DateTimeKind.Utc).AddTicks(1528), new DateTime(2023, 12, 9, 19, 21, 15, 164, DateTimeKind.Local).AddTicks(1529), "There are problem with water", null, false, new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"), null, null, null, "created", new DateTime(2023, 12, 9, 17, 21, 15, 164, DateTimeKind.Utc).AddTicks(1529), "49b754b0-8831-4b1a-a44f-8e18a0c2578e" },
                    { new Guid("db2b4a44-1c0a-404a-be1c-01de2376beed"), new DateTime(2023, 12, 9, 17, 21, 15, 164, DateTimeKind.Utc).AddTicks(1401), new DateTime(2023, 12, 9, 19, 21, 15, 164, DateTimeKind.Local).AddTicks(1407), "There are problem with road", null, false, new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"), null, null, null, "created", new DateTime(2023, 12, 9, 17, 21, 15, 164, DateTimeKind.Utc).AddTicks(1403), "49b754b0-8831-4b1a-a44f-8e18a0c2578e" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3", "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45" },
                    { "4", "c8b05623-d42b-4a9f-947e-dcd54538ee1d" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OrganizationId",
                table: "AspNetUsers",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_ComplaintId",
                table: "Assignment",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_UserGiveId",
                table: "Assignment",
                column: "UserGiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_UserTakeId",
                table: "Assignment",
                column: "UserTakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_OrganizationId1",
                table: "Category",
                column: "OrganizationId1");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintFiles_ComplaintId",
                table: "ComplaintFiles",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_OrganizationId",
                table: "Complaints",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_OrganizationId1",
                table: "Complaints",
                column: "OrganizationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_OrganizationId2",
                table: "Complaints",
                column: "OrganizationId2");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_UserId",
                table: "Complaints",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_OrganizationId",
                table: "Employments",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_UserId",
                table: "Employments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ComplaintFiles");

            migrationBuilder.DropTable(
                name: "Employments");

            migrationBuilder.DropTable(
                name: "Responce");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
