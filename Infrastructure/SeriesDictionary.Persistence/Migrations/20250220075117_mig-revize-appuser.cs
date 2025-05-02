using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeriesDictionary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migrevizeappuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "AppUsers");
        }
    }
}
