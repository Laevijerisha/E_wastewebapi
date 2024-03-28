using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_wasteManagementWebapi.Migrations
{
    /// <inheritdoc />
    public partial class raj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approvedItems");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedItemStatus",
                table: "waste_items",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedItemStatus",
                table: "waste_items");

            migrationBuilder.CreateTable(
                name: "approvedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ApprovedItemStatus = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approvedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_approvedItems_waste_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "waste_items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_approvedItems_ItemId",
                table: "approvedItems",
                column: "ItemId");
        }
    }
}
