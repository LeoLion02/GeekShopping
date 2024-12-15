using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.ProductAPI.Data.Migrations;

public partial class Add_Products : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Product",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Product", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Product");
    }
}
