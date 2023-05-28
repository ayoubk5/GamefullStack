using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platformes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platformes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlatformes",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatformes", x => new { x.GameId, x.PlatformId });
                    table.ForeignKey(
                        name: "FK_GamePlatformes_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatformes_Platformes_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platformes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Image", "Name", "Slug" },
                values: new object[,]
                {
                    { 99, "https://media.rawg.io/media/games/27b/27b02ffaab6b250cc31bf43baca1fc34.jpg", "Arcade", "arcade" },
                    { 196, "https://media.rawg.io/media/games/8d6/8d69eb6c32ed6acfd75f82d532144993.jpg", "Action", "action" },
                    { 201, "https://media.rawg.io/media/games/78d/78dfae12fb8c5b16cd78648553071e0a.jpg", "Simulation", "simulation" },
                    { 206, "https://media.rawg.io/media/screenshots/b20/b20a20205954f9765e82298dbd41e48a.jpg", "Casual", "casual" },
                    { 242, "https://media.rawg.io/media/games/5a4/5a44112251d70a25291cc33757220fce.jpg", "RPG", "role-playing-games-rpg" },
                    { 272, "https://media.rawg.io/media/games/fc1/fc1307a2774506b5bd65d7e8424664a7.jpg", "Shooter", "shooter" },
                    { 288, "https://media.rawg.io/media/games/388/388935d851846f8ec747fffc7c765800.jpg", "Platformer", "platformer" },
                    { 318, "https://media.rawg.io/media/games/7ca/7ca90d463ea0c0252e7d01afe897ffa8.jpg", "Educational", "educational" },
                    { 319, "https://media.rawg.io/media/games/788/788b80cbc8c39167f7ed6dd89fd398dc.jpg", "Racing", "racing" },
                    { 394, "https://media.rawg.io/media/screenshots/d62/d628164463ac6fc7ab28b5a988191582.jpg", "Board Games", "board-games" },
                    { 418, "https://media.rawg.io/media/games/c2e/c2e6ad5c838d551aeff376f1f3d9d65e.jpg", "Puzzle", "puzzle" },
                    { 420, "https://media.rawg.io/media/games/91b/91be1a00c767f9e3d79353e505d7f85a.jpg", "Fighting", "fighting" },
                    { 440, "https://media.rawg.io/media/games/d69/d69810315bd7e226ea2d21f9156af629.jpg", "Adventure", "adventure" },
                    { 451, "https://media.rawg.io/media/games/082/082365507ff04d456c700157072d35db.jpg", "Sports", "sports" },
                    { 453, "https://media.rawg.io/media/games/d07/d0790809a13027251b6d0f4dc7538c58.jpg", "Massively Multiplayer", "massively-multiplayer" },
                    { 466, "https://media.rawg.io/media/games/b6b/b6b20bfc4b34e312dbc8aac53c95a348.jpg", "Indie", "indie" }
                });

            migrationBuilder.InsertData(
                table: "Platformes",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { 22, "Nintendo", "nintendo" },
                    { 51, "IOS", "iOS" },
                    { 55, "Atari", "atari" },
                    { 66, "Pc", "pc" },
                    { 132, "Linux", "linux" },
                    { 297, "PlayStation", "playstation" },
                    { 303, "Xbox", "xbox" },
                    { 357, "SEGA", "sega" },
                    { 388, "Apple Macintosh", "mac" },
                    { 403, "Android", "android" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatformes_PlatformId",
                table: "GamePlatformes",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platformes_Name",
                table: "Platformes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlatformes");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Platformes");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
