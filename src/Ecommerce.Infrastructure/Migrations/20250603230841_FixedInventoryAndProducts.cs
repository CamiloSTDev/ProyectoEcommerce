using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedInventoryAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinStock",
                table: "Inventories");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "MinStock",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
