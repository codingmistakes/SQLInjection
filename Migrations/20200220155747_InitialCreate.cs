using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLInjection.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BestMovies",
                columns: table => new
                {
                    BestMovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    ImdbScore = table.Column<string>(nullable: true),
                    Actor = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestMovies", x => x.BestMovieId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestMovies");
        }
    }
}
