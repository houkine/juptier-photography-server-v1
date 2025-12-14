using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jupter_server.Migrations
{
    /// <inheritdoc />
    public partial class dev023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gallery",
                columns: new[] { "id", "backgroundImage", "isValid", "name", "reserve" },
                values: new object[] { new Guid("630e5ef0-cf44-4b82-b4e1-9838cee24e4d"), null, true, "gallery_1", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gallery",
                keyColumn: "id",
                keyValue: new Guid("630e5ef0-cf44-4b82-b4e1-9838cee24e4d"));
        }
    }
}
