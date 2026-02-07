using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EMin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                schema: "client",
                table: "People",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "NoToken");

            migrationBuilder.CreateIndex(
                name: "IX_People_RefreshToken",
                schema: "client",
                table: "People",
                column: "RefreshToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_RefreshToken",
                schema: "client",
                table: "People");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                schema: "client",
                table: "People");
        }
    }
}
