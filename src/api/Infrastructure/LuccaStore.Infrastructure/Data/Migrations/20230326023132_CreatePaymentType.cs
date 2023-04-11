using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LuccaStore.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatePaymentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a21441fd-011c-482f-8467-98c41dd8b094", "95a0989c-f937-4a5f-a0ca-c1097026b270" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c92e060b-d6bf-47c9-bec6-23669a79cb2d", "95a0989c-f937-4a5f-a0ca-c1097026b270" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a21441fd-011c-482f-8467-98c41dd8b094");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c92e060b-d6bf-47c9-bec6-23669a79cb2d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95a0989c-f937-4a5f-a0ca-c1097026b270");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "PaymentMethods");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentTypeId",
                table: "PaymentMethods",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentTypeName = table.Column<string>(type: "text", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bf2daf9f-7be2-4de8-9c4e-013f3010a0ec", "bf2daf9f-7be2-4de8-9c4e-013f3010a0ec", "User", "USER" },
                    { "c3c58c39-9c6f-40da-a6bb-56ee67d3ad71", "c3c58c39-9c6f-40da-a6bb-56ee67d3ad71", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1e32bc22-4493-4be9-8e08-858f7ccd2629", 0, "2af39870-729e-420d-97ca-fe88d07395cd", "admin@email.com", true, false, null, "ADMIN@EMAIL.COM", "ADMIN.USER", "AQAAAAEAACcQAAAAECZgCCpeAw5/qoORNPiJu8dUZkq5IN/7f6WuLv2RTbDPOYebxjvJ/LyCCIqh/DJ+Uw==", null, false, "4514517b-d162-4e3a-a5c9-82ae0af7b174", false, "admin.user" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "bf2daf9f-7be2-4de8-9c4e-013f3010a0ec", "1e32bc22-4493-4be9-8e08-858f7ccd2629" },
                    { "c3c58c39-9c6f-40da-a6bb-56ee67d3ad71", "1e32bc22-4493-4be9-8e08-858f7ccd2629" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_PaymentTypeId",
                table: "PaymentMethods",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_PaymentTypes_PaymentTypeId",
                table: "PaymentMethods",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_PaymentTypes_PaymentTypeId",
                table: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_PaymentTypeId",
                table: "PaymentMethods");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bf2daf9f-7be2-4de8-9c4e-013f3010a0ec", "1e32bc22-4493-4be9-8e08-858f7ccd2629" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c3c58c39-9c6f-40da-a6bb-56ee67d3ad71", "1e32bc22-4493-4be9-8e08-858f7ccd2629" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf2daf9f-7be2-4de8-9c4e-013f3010a0ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3c58c39-9c6f-40da-a6bb-56ee67d3ad71");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e32bc22-4493-4be9-8e08-858f7ccd2629");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "PaymentMethods");

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "PaymentMethods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a21441fd-011c-482f-8467-98c41dd8b094", "a21441fd-011c-482f-8467-98c41dd8b094", "User", "USER" },
                    { "c92e060b-d6bf-47c9-bec6-23669a79cb2d", "c92e060b-d6bf-47c9-bec6-23669a79cb2d", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "95a0989c-f937-4a5f-a0ca-c1097026b270", 0, "ce113943-b8cf-4569-b039-5466842aa4c6", "admin@email.com", true, false, null, "ADMIN@EMAIL.COM", "ADMIN.USER", "AQAAAAEAACcQAAAAEL9aqQUL8BHZIj5TBghxoUxdgupf3FmByccv3SOaOqT+uaHFN+A0p+YxOHkOLuZEcA==", null, false, "00e7855c-c28f-4b30-b0f7-eaf7261f3d69", false, "admin.user" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a21441fd-011c-482f-8467-98c41dd8b094", "95a0989c-f937-4a5f-a0ca-c1097026b270" },
                    { "c92e060b-d6bf-47c9-bec6-23669a79cb2d", "95a0989c-f937-4a5f-a0ca-c1097026b270" }
                });
        }
    }
}
