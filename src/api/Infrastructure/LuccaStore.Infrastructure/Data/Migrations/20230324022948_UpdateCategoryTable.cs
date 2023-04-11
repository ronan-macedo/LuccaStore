using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LuccaStore.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1eb31813-4461-45ef-bc22-2f174fd8b477", "f01f0b8e-f9c8-4e99-86b9-e5fe37451282" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e5c63c5b-c276-460f-a7a3-dfd9177ed18f", "f01f0b8e-f9c8-4e99-86b9-e5fe37451282" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1eb31813-4461-45ef-bc22-2f174fd8b477");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5c63c5b-c276-460f-a7a3-dfd9177ed18f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f01f0b8e-f9c8-4e99-86b9-e5fe37451282");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Storages",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "PaymentMethods",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "OrderLines",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Storages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "PaymentMethods",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "OrderLines",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1eb31813-4461-45ef-bc22-2f174fd8b477", "1eb31813-4461-45ef-bc22-2f174fd8b477", "Admin", "ADMIN" },
                    { "e5c63c5b-c276-460f-a7a3-dfd9177ed18f", "e5c63c5b-c276-460f-a7a3-dfd9177ed18f", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f01f0b8e-f9c8-4e99-86b9-e5fe37451282", 0, "2e891d14-d7da-48a2-8186-64adc45ce835", "admin@email.com", true, false, null, "ADMIN@EMAIL.COM", "ADMIN.USER", "AQAAAAEAACcQAAAAEL5xA3bVli+ZLZSw+IOROIVVm+5abDQtkOJuOfdaXdjIvg1uvpp7GGlxTZfgjZcboA==", null, false, "8c43f6ff-be0a-4e72-b2aa-f6e37d38dbf2", false, "admin.user" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1eb31813-4461-45ef-bc22-2f174fd8b477", "f01f0b8e-f9c8-4e99-86b9-e5fe37451282" },
                    { "e5c63c5b-c276-460f-a7a3-dfd9177ed18f", "f01f0b8e-f9c8-4e99-86b9-e5fe37451282" }
                });
        }
    }
}
