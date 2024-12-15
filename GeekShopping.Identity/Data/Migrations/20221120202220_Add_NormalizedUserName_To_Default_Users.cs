using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.Identity.Data.Migrations;

/// <inheritdoc />
public partial class AddNormalizedUserNameToDefaultUsers : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.UpdateData(
            table: "AspNetUsers",
            keyColumn: "Id",
            keyValue: 1,
            columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
            values: new object[] { "17a7112b-4219-4ba2-a624-6d15087c8217", "LEO", "AQAAAAIAAYagAAAAEMKKRPJK21TUOj3EFoH4WnhtCttykbg8iC9+VoznI9Uhu4y8e2Ja3Jxe4HYwZ+Qgzw==" });

        migrationBuilder.UpdateData(
            table: "AspNetUsers",
            keyColumn: "Id",
            keyValue: 2,
            columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
            values: new object[] { "5183e8bf-4195-4b98-849e-8d6260fbd526", "LEO CLIENT", "AQAAAAIAAYagAAAAEBTcFRU7CEfHDllr93Lm0bLqn4nBsDih9bCLV1eGCceBTeCW0OnM4A47h2zaVSuIcw==" });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.UpdateData(
            table: "AspNetUsers",
            keyColumn: "Id",
            keyValue: 1,
            columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
            values: new object[] { "9cb4e399-edb5-4461-9baf-8bde6581e2b9", null, "AQAAAAIAAYagAAAAEBHwYKlWG2Rixf7LJyYt5bKDHtmhGfFreuFi9sIZMg8kkhFCkG5f7ByNQb4zu2TnrQ==" });

        migrationBuilder.UpdateData(
            table: "AspNetUsers",
            keyColumn: "Id",
            keyValue: 2,
            columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
            values: new object[] { "030021e8-6e8f-402c-ac79-98565688cc0b", null, "AQAAAAIAAYagAAAAECMtRlpXmcoWMLkD4+YHhflWL3vg71PwgAPi5TbkOOC8Gh1207ivNH232yp8hsJd2A==" });
    }
}
