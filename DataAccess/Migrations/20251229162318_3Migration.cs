using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _3Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "education",
                table: "Lessons",
                columns: new[] { "Id", "FacultyName", "SpecialtyName" },
                values: new object[] { 7, "Tarix", "Rus Tarixi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "education",
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
