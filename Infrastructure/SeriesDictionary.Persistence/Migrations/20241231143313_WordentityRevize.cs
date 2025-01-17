using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeriesDictionary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class WordentityRevize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sentence",
                table: "Words",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sentence",
                table: "Words");
        }
    }
}
