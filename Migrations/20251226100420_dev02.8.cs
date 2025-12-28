using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jupter_server.Migrations
{
    /// <inheritdoc />
    public partial class dev028 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumImageInfo_AlbumImageListInfo_AlbumImageListInfoId",
                table: "AlbumImageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumImageListInfo_ThemeAlbumInfo_ThemeAlbumInfoId",
                table: "AlbumImageListInfo");

            migrationBuilder.AlterColumn<Guid>(
                name: "ThemeAlbumInfoId",
                table: "AlbumImageListInfo",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AlbumImageListInfoId",
                table: "AlbumImageInfo",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumImageInfo_AlbumImageListInfo_AlbumImageListInfoId",
                table: "AlbumImageInfo",
                column: "AlbumImageListInfoId",
                principalTable: "AlbumImageListInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumImageListInfo_ThemeAlbumInfo_ThemeAlbumInfoId",
                table: "AlbumImageListInfo",
                column: "ThemeAlbumInfoId",
                principalTable: "ThemeAlbumInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumImageInfo_AlbumImageListInfo_AlbumImageListInfoId",
                table: "AlbumImageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumImageListInfo_ThemeAlbumInfo_ThemeAlbumInfoId",
                table: "AlbumImageListInfo");

            migrationBuilder.AlterColumn<Guid>(
                name: "ThemeAlbumInfoId",
                table: "AlbumImageListInfo",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlbumImageListInfoId",
                table: "AlbumImageInfo",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumImageInfo_AlbumImageListInfo_AlbumImageListInfoId",
                table: "AlbumImageInfo",
                column: "AlbumImageListInfoId",
                principalTable: "AlbumImageListInfo",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumImageListInfo_ThemeAlbumInfo_ThemeAlbumInfoId",
                table: "AlbumImageListInfo",
                column: "ThemeAlbumInfoId",
                principalTable: "ThemeAlbumInfo",
                principalColumn: "id");
        }
    }
}
