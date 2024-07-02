using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectMovie.Migrations
{
    /// <inheritdoc />
    public partial class Rename_PosterNameColumn_To_PosterFileName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PosterName",
                table: "Movie",
                newName: "PosterFileName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PosterFileName",
                table: "Movie",
                newName: "PosterName");
        }
    }
}
