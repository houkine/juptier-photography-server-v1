using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jupter_server.Migrations
{
    /// <inheritdoc />
    public partial class dev022 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    backgroundImage = table.Column<string>(type: "text", nullable: true),
                    isValid = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    reserve = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GalleryThemeInfo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    coverImage = table.Column<string>(type: "text", nullable: true),
                    sequence = table.Column<int>(type: "integer", nullable: false),
                    GalleryId = table.Column<Guid>(type: "uuid", nullable: true),
                    isValid = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    reserve = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryThemeInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_GalleryThemeInfo_Gallery_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Gallery",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ThemeAlbumInfo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    coverImage = table.Column<string>(type: "text", nullable: true),
                    sequence = table.Column<int>(type: "integer", nullable: false),
                    GalleryThemeInfoId = table.Column<Guid>(type: "uuid", nullable: true),
                    isValid = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    reserve = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeAlbumInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_ThemeAlbumInfo_GalleryThemeInfo_GalleryThemeInfoId",
                        column: x => x.GalleryThemeInfoId,
                        principalTable: "GalleryThemeInfo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AlbumImageListInfo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sequence = table.Column<int>(type: "integer", nullable: false),
                    ThemeAlbumInfoId = table.Column<Guid>(type: "uuid", nullable: true),
                    isValid = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    reserve = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumImageListInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_AlbumImageListInfo_ThemeAlbumInfo_ThemeAlbumInfoId",
                        column: x => x.ThemeAlbumInfoId,
                        principalTable: "ThemeAlbumInfo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AlbumImageInfo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    src = table.Column<string>(type: "text", nullable: true),
                    sequence = table.Column<int>(type: "integer", nullable: false),
                    AlbumImageListInfoId = table.Column<Guid>(type: "uuid", nullable: true),
                    isValid = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    reserve = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumImageInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_AlbumImageInfo_AlbumImageListInfo_AlbumImageListInfoId",
                        column: x => x.AlbumImageListInfoId,
                        principalTable: "AlbumImageListInfo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumImageInfo_AlbumImageListInfoId",
                table: "AlbumImageInfo",
                column: "AlbumImageListInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumImageInfo_sequence",
                table: "AlbumImageInfo",
                column: "sequence");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumImageListInfo_sequence",
                table: "AlbumImageListInfo",
                column: "sequence");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumImageListInfo_ThemeAlbumInfoId",
                table: "AlbumImageListInfo",
                column: "ThemeAlbumInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryThemeInfo_GalleryId",
                table: "GalleryThemeInfo",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryThemeInfo_sequence",
                table: "GalleryThemeInfo",
                column: "sequence");

            migrationBuilder.CreateIndex(
                name: "IX_ThemeAlbumInfo_GalleryThemeInfoId",
                table: "ThemeAlbumInfo",
                column: "GalleryThemeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ThemeAlbumInfo_sequence",
                table: "ThemeAlbumInfo",
                column: "sequence");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumImageInfo");

            migrationBuilder.DropTable(
                name: "AlbumImageListInfo");

            migrationBuilder.DropTable(
                name: "ThemeAlbumInfo");

            migrationBuilder.DropTable(
                name: "GalleryThemeInfo");

            migrationBuilder.DropTable(
                name: "Gallery");
        }
    }
}
