using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectMovie.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PosterPath",
                table: "Movie",
                newName: "PosterName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PosterName",
                table: "Movie",
                newName: "PosterPath");
        }
    }
}
