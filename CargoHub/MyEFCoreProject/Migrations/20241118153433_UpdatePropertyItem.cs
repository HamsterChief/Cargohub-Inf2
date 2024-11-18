using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEFCoreProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertyItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Items",
                table: "Orders",
                newName: "items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "items",
                table: "Orders",
                newName: "Items");
        }
    }
}
