using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inspector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAndSeedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaintId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responce", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponceId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Solves problems related to the road surface", "Road Organization" },
                    { 2, "Solves problems related to water supply", "Water Organization" },
                    { 3, "Solves problems related to the violation of health care rights", "Health Organization" }
                });

            migrationBuilder.InsertData(
                table: "Responce",
                columns: new[] { "Id", "ComplaintId", "CreatedDate", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 17, 2, 40, 28, 961, DateTimeKind.Local).AddTicks(5198), "Responce N1", "N1" },
                    { 2, 2, new DateTime(2023, 9, 17, 2, 40, 28, 961, DateTimeKind.Local).AddTicks(5201), "Responce N2", "N2" },
                    { 3, 3, new DateTime(2023, 9, 17, 2, 40, 28, 961, DateTimeKind.Local).AddTicks(5203), "Responce N2", "N3" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "OrganizationId" },
                values: new object[,]
                {
                    { 1, "A hole in the road", "A hole in the road", 1 },
                    { 2, "broke the pipe", "Broke the pipe", 2 },
                    { 3, "Smoking", "Smoking", 3 }
                });

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "CreatedDate", "Description", "File", "OrganizationId", "ResponceId", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 17, 2, 40, 28, 961, DateTimeKind.Local).AddTicks(5121), "There are problem with road", null, 1, null, "sent", "Oksana" },
                    { 2, new DateTime(2023, 9, 17, 2, 40, 28, 961, DateTimeKind.Local).AddTicks(5178), "There are problem with water", null, 2, null, "sent", "Anna" },
                    { 3, new DateTime(2023, 9, 17, 2, 40, 28, 961, DateTimeKind.Local).AddTicks(5180), "There are problem with helth", null, 3, null, "sent", "Alex" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_OrganizationId",
                table: "Category",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_OrganizationId",
                table: "Complaints",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Responce");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
