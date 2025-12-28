using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jupter_server.Migrations
{
    /// <inheritdoc />
    public partial class dev025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Gallery",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gallery_name",
                table: "Gallery",
                column: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Gallery_name",
                table: "Gallery");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Gallery",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
