using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeriesDictionary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migdomainrevize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowId",
                table: "Words",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShowId",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Show",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_ShowId",
                table: "Words",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_ShowId",
                table: "Episodes",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Show_ShowId",
                table: "Episodes",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Show_ShowId",
                table: "Words",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Show_ShowId",
                table: "Episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Show_ShowId",
                table: "Words");

            migrationBuilder.DropTable(
                name: "Show");

            migrationBuilder.DropIndex(
                name: "IX_Words_ShowId",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_ShowId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "ShowId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "ShowId",
                table: "Episodes");
        }
    }
}
