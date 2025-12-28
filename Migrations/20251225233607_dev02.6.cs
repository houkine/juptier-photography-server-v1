using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace jupter_server.Migrations
{
    /// <inheritdoc />
    public partial class dev026 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ThemeAlbumInfo",
                columns: new[] { "id", "GalleryThemeInfoId", "coverImage", "description", "isValid", "reserve", "sequence", "title" },
                values: new object[,]
                {
                    { new Guid("061e7679-87da-4e4d-b516-dbb2443671a2"), new Guid("ba11a7ef-ddcb-4545-a40a-fc3262801f96"), null, null, true, null, 1, "Album_1" },
                    { new Guid("41aec750-9233-4cb8-ace2-88f92a11a28c"), new Guid("9f45fc55-2d8f-4008-a4ec-f6526ef280e1"), null, null, true, null, 6, "Album_6" },
                    { new Guid("5af125aa-0eeb-4c01-95e9-e89d9268771e"), new Guid("56bbe3de-8d3f-4630-b0c1-21a49c64c97b"), null, null, true, null, 3, "Album_3" },
                    { new Guid("77a70ce5-e14f-4039-9df1-27c5ff0b605f"), new Guid("1b56daf8-2992-479f-acec-c34838c91898"), null, null, true, null, 4, "Album_4" },
                    { new Guid("a0331524-0418-439f-baf2-e783c26dcb04"), new Guid("ba11a7ef-ddcb-4545-a40a-fc3262801f96"), null, null, true, null, 2, "Album_2" },
                    { new Guid("adfa6ea8-2b61-487c-bf4c-a98eaa0b7f13"), new Guid("9f45fc55-2d8f-4008-a4ec-f6526ef280e1"), null, null, true, null, 5, "Album_5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ThemeAlbumInfo",
                keyColumn: "id",
                keyValue: new Guid("061e7679-87da-4e4d-b516-dbb2443671a2"));

            migrationBuilder.DeleteData(
                table: "ThemeAlbumInfo",
                keyColumn: "id",
                keyValue: new Guid("41aec750-9233-4cb8-ace2-88f92a11a28c"));

            migrationBuilder.DeleteData(
                table: "ThemeAlbumInfo",
                keyColumn: "id",
                keyValue: new Guid("5af125aa-0eeb-4c01-95e9-e89d9268771e"));

            migrationBuilder.DeleteData(
                table: "ThemeAlbumInfo",
                keyColumn: "id",
                keyValue: new Guid("77a70ce5-e14f-4039-9df1-27c5ff0b605f"));

            migrationBuilder.DeleteData(
                table: "ThemeAlbumInfo",
                keyColumn: "id",
                keyValue: new Guid("a0331524-0418-439f-baf2-e783c26dcb04"));

            migrationBuilder.DeleteData(
                table: "ThemeAlbumInfo",
                keyColumn: "id",
                keyValue: new Guid("adfa6ea8-2b61-487c-bf4c-a98eaa0b7f13"));
        }
    }
}
