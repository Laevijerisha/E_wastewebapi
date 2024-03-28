using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_wasteManagementWebapi.Migrations
{
    /// <inheritdoc />
    public partial class kk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemLocation",
                table: "waste_items",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "personalEmail",
                table: "centers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approvedItems");

            migrationBuilder.DropColumn(
                name: "personalEmail",
                table: "centers");

            migrationBuilder.UpdateData(
                table: "waste_items",
                keyColumn: "ItemLocation",
                keyValue: null,
                column: "ItemLocation",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ItemLocation",
                table: "waste_items",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
