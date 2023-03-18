using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuccaStore.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "OrderLines",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderLines");

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "Products",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
