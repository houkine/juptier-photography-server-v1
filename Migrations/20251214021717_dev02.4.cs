using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace jupter_server.Migrations
{
    /// <inheritdoc />
    public partial class dev024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GalleryThemeInfo",
                columns: new[] { "id", "GalleryId", "coverImage", "description", "isValid", "reserve", "sequence", "title" },
                values: new object[,]
                {
                    { new Guid("1b56daf8-2992-479f-acec-c34838c91898"), new Guid("630e5ef0-cf44-4b82-b4e1-9838cee24e4d"), "", "this is event theme", true, null, 3, "EVENT" },
                    { new Guid("56bbe3de-8d3f-4630-b0c1-21a49c64c97b"), new Guid("630e5ef0-cf44-4b82-b4e1-9838cee24e4d"), "", "this is character theme", true, null, 2, "CHARACTER" },
                    { new Guid("9f45fc55-2d8f-4008-a4ec-f6526ef280e1"), new Guid("630e5ef0-cf44-4b82-b4e1-9838cee24e4d"), "", "this is business theme", true, null, 4, "BUSINESS" },
                    { new Guid("ba11a7ef-ddcb-4545-a40a-fc3262801f96"), new Guid("630e5ef0-cf44-4b82-b4e1-9838cee24e4d"), "", "this is nature theme", true, null, 1, "NATURE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GalleryThemeInfo",
                keyColumn: "id",
                keyValue: new Guid("1b56daf8-2992-479f-acec-c34838c91898"));

            migrationBuilder.DeleteData(
                table: "GalleryThemeInfo",
                keyColumn: "id",
                keyValue: new Guid("56bbe3de-8d3f-4630-b0c1-21a49c64c97b"));

            migrationBuilder.DeleteData(
                table: "GalleryThemeInfo",
                keyColumn: "id",
                keyValue: new Guid("9f45fc55-2d8f-4008-a4ec-f6526ef280e1"));

            migrationBuilder.DeleteData(
                table: "GalleryThemeInfo",
                keyColumn: "id",
                keyValue: new Guid("ba11a7ef-ddcb-4545-a40a-fc3262801f96"));
        }
    }
}
