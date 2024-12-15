using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.Identity.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesNormalizedName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "NormalizedName",
                value: "ADMIN");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "NormalizedName",
                value: "CLIENT");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c8998159-a6a3-4e41-89e8-2bf6c9006470", "AQAAAAIAAYagAAAAEJdt3QpMMVBeOP6qQBS37lzHXbau0wAidk2RZ5qXFbXKr1ydlGFTOK0d93k9GNNK6g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "72c92fbe-2765-4998-8000-1126c65b2e42", "AQAAAAIAAYagAAAAEL0W6PedPJON1WB4MVAFlgnoIu+6wHIb5xckJGP3IujbRPVTWGwFuTxjsegU8bJz+A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "NormalizedName",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17a7112b-4219-4ba2-a624-6d15087c8217", "AQAAAAIAAYagAAAAEMKKRPJK21TUOj3EFoH4WnhtCttykbg8iC9+VoznI9Uhu4y8e2Ja3Jxe4HYwZ+Qgzw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5183e8bf-4195-4b98-849e-8d6260fbd526", "AQAAAAIAAYagAAAAEBTcFRU7CEfHDllr93Lm0bLqn4nBsDih9bCLV1eGCceBTeCW0OnM4A47h2zaVSuIcw==" });
        }
    }
}
