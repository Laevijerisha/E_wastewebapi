using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_wasteManagementWebapi.Migrations
{
    /// <inheritdoc />
    public partial class my : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Itemtype",
                table: "waste_items",
                newName: "UniqueFileName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UniqueFileName",
                table: "waste_items",
                newName: "Itemtype");
        }
    }
}
