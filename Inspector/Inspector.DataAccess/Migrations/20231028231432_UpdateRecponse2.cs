using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRecponse2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responce_Organization_OrganizationId",
                table: "Responce");

            migrationBuilder.DropIndex(
                name: "IX_Responce_OrganizationId",
                table: "Responce");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Responce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d17e5e39-0fa3-4313-adec-c36c26b75c23");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a5d847fd-40f3-4f44-9fed-9badd3e7abde");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a247125d-9c9a-4f4c-8acd-4e7bebef5787");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "a55dcd75-bc43-4cfc-9941-f2f71e95819b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bac80bb7-4686-4566-a309-b9f5195b1082", "AQAAAAIAAYagAAAAEC0RCwJY6p4UvBOHYZiBf/0vGdPNHEloZXGagSjDqXJlZCJ1rB0CooVuS8QDIOsxVg==", "c6f2b76e-f0d2-46d6-8725-7cf309bd9b9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0f617d3-35bb-442e-82d7-7e990825af27", "AQAAAAIAAYagAAAAED6e+hSBssyl3B+UC7QDLj4U9FntxX9CkBdq/ESQPpgiG6r+spnibbEmtkrzKjg4Aw==", "7d123b66-d282-48e2-9d32-835c67f1cd29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd33628d-d0cb-463b-bd7a-7b5bd7aaf390", "AQAAAAIAAYagAAAAEPBv+tRrMxrPW/Uk94N28sQ26VxxryGYBWVd2UdoTTGJiFOSBw3ooOk53K2KvNjeLg==", "64292201-e406-4c61-af54-d33993821eb6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "078552cf-6330-494d-9ec7-630215294575", "AQAAAAIAAYagAAAAEM/Xrr+t5lt5qkI+YnhlF3qwlNcexu+r4Cj6qeNBQXI0bluWnZ1unLQknkEULyKqBQ==", "01d8c575-9f5c-47f1-a329-b2a4acaca59f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "935cd685-9190-4d44-8c77-839a3a95394b", "69e04ce0-ba92-43ba-a7c8-7be4f24255e2" });

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 2, 14, 32, 230, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 2, 14, 32, 230, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 2, 14, 32, 230, DateTimeKind.Local).AddTicks(623));

            migrationBuilder.UpdateData(
                table: "Responce",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 2, 14, 32, 230, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "Responce",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 2, 14, 32, 230, DateTimeKind.Local).AddTicks(687));

            migrationBuilder.UpdateData(
                table: "Responce",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 2, 14, 32, 230, DateTimeKind.Local).AddTicks(696));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Responce",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "465d166c-52bd-4c2a-8abe-04b53fa629e8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5ea9111e-3e06-4975-86e1-e646690fde5b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "07797e0f-158a-4d27-be4b-540e9209e5f8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "fa077992-43fe-4df8-b17f-b6f1f512e3b1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a899523-c5cc-430f-aed5-cd5812dff350", "AQAAAAIAAYagAAAAECkdAlrwHGtM4iquINDPtqpaZRVSA2Q7DjMhfR0lKLmTMCaT5MVnZU5OexMEGMilxA==", "0ffdba3b-b5c6-44d2-98c1-3b59fdc99117" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "effa6e92-6318-4aad-81ce-ef30b353604e", "AQAAAAIAAYagAAAAEAzHaJyLJl8Ui2/KY7Fk1QUL/3A3wzpp8O8tT+QoK1Y0bR4r31TUaYL+xitfpstRhA==", "747ec9b9-3751-4349-93ae-41a485943437" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6f27ca2-5fa4-4adc-9ce0-42c27d6d10bf", "AQAAAAIAAYagAAAAEEMPkRQWbv6RSeQXen/Gfsd5p0Dygf3CGXe9E9MK+VLLgj+SN7aDquiMXYcMUm1uHQ==", "6b2c2266-e9d6-4446-ac16-abd764b5d300" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ee0fa99-57a6-4097-9ca4-4c0d107c8f77", "AQAAAAIAAYagAAAAENuu/BnDJogRqZXEE/AcFrvGmyPyKoEmdmDUtEN+zKAmsznsYtAa9M8KEd22YecZRQ==", "9cccf668-1c77-415f-8bc1-8145adc2ba68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ad9d0bcb-30b9-44ac-8057-d38d8998204f", "514bdc7d-4c73-4680-896a-3d9254028fc6" });

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 1, 27, 8, 541, DateTimeKind.Local).AddTicks(2560));

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 1, 27, 8, 541, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "Complaints",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 29, 1, 27, 8, 541, DateTimeKind.Local).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "Responce",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "OrganizationId" },
                values: new object[] { new DateTime(2023, 10, 29, 1, 27, 8, 541, DateTimeKind.Local).AddTicks(2711), null });

            migrationBuilder.UpdateData(
                table: "Responce",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "OrganizationId" },
                values: new object[] { new DateTime(2023, 10, 29, 1, 27, 8, 541, DateTimeKind.Local).AddTicks(2714), null });

            migrationBuilder.UpdateData(
                table: "Responce",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "OrganizationId" },
                values: new object[] { new DateTime(2023, 10, 29, 1, 27, 8, 541, DateTimeKind.Local).AddTicks(2727), null });

            migrationBuilder.CreateIndex(
                name: "IX_Responce_OrganizationId",
                table: "Responce",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responce_Organization_OrganizationId",
                table: "Responce",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id");
        }
    }
}
