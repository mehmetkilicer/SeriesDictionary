using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeriesDictionary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migshowedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl1",
                table: "Show",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl2",
                table: "Show",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl3",
                table: "Show",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl1",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "ImageUrl2",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "ImageUrl3",
                table: "Show");
        }
    }
}
