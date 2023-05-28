using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.WebRequestMethods;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InsertGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Image", "Name", "Slug", "Rating" ,"GenreId"},
                values: new object[,]
                {
                    { 43, "https://media.rawg.io/media/games/456/456dea5e1c7e3cd07060c14e96612001.jpg", "Grand Theft Auto V", "grand-theft-auto-v",88,196 },
                    { 135, "https://media.rawg.io/media/games/618/618c2031a07bbff6b4f611f10b6bcdbc.jpg", "The Witcher 3: Wild Hunt", "the-witcher-3-wild-hunt",70,440 },
                    { 148, "https://media.rawg.io/media/games/328/3283617cb7d75d67257fc58339188742.jpg", "Portal 2", "portal-2",98,272 },
                    { 155, "https://media.rawg.io/media/games/021/021c4e21a1824d2526f925eff6324653.jpg", "Tomb Raider (2013)", "tomb-raider",58,440 },
                    { 170, "https://media.rawg.io/media/games/736/73619bd336c894d6941d926bfd563946.jpg", "Counter-Strike: Global Offensive", "counter-strike-global-offensive" , 78,196},
                    { 192, "https://media.rawg.io/media/games/7fa/7fa0b586293c5861ee32490e953a4996.jpg", "Portal", "portal",78 ,418},
                    { 202, "https://media.rawg.io/media/games/d58/d588947d4286e7b5e0e12e1bea7d9844.jpg", "Left 4 Dead 2", "left-4-dead-2",78,272 },
                    { 261, "https://media.rawg.io/media/games/7cf/7cfc9220b401b7a300e409e539c9afd5.jpg", "The Elder Scrolls V: Skyrim", "the-elder-scrolls-v-skyrim",78,242 },
                    { 292, "https://media.rawg.io/media/games/fc1/fc1307a2774506b5bd65d7e8424664a7.jpg", "BioShock Infinite", "bioshock-infinite",78,196 },
                    { 312, "https://media.rawg.io/media/games/511/5118aff5091cb3efec399c808f8c598f.jpg", "Red Dead Redemption 2", "red-dead-redemption-2",78 ,440},
                    { 353, "https://media.rawg.io/media/games/562/562553814dd54e001a541e4ee83a591c.jpg", "Life is Strange", "life-is-strange-episode-1-2",78,440 },
                    { 384, "https://media.rawg.io/media/games/49c/49c3dfa4ce2f6f140cc4825868e858cb.jpg", "Borderlands 2", "borderlands-2" ,78, 196},
                    { 471, "https://media.rawg.io/media/games/b8c/b8c243eaa0fbac8115e0cdccac3f91dc.jpg", "Half-Life 2", "half-life-2" ,78,272},
                    { 488, "https://media.rawg.io/media/games/bc0/bc06a29ceac58652b684deefe7d56099.jpg", "BioShock", "bioshock" ,78, 196},
                    { 492, "https://media.rawg.io/media/games/942/9424d6bb763dc38d9378b488603c87fa.jpg", "Limbo", "limbo" ,78,466},
                    { 47, "https://media.rawg.io/media/games/4be/4be6a6ad0364751a96229c56bf69be59.jpg", "God of War (2018)", "god-of-war-2",78 , 242},
                    { 8, "https://media.rawg.io/media/games/34b/34b1f1850a1c06fd971bc6ab3ac0ce0e.jpg", "Destiny 2", "destiny-2",78 , 453},
                    { 88, "https://media.rawg.io/media/games/d82/d82990b9c67ba0d2d09d4e6fa88885a7.jpg", "Fallout 4", "fallout-4" ,78, 196},
                    { 48, "https://media.rawg.io/media/games/c4b/c4b0cab189e73432de3a250d8cf1c84e.jpg", "DOOM (2016)", "doom" ,78, 272},
                    { 23, "https://media.rawg.io/media/games/46d/46d98e6910fbc0706e2948a7cc9b10c5.jpg", "Team Fortress 2", "team-fortress-2" , 78, 272},
        
                });


            migrationBuilder.InsertData(
               table: "GamePlatformes",
               columns: new[] { "GameId", "PlatformId"},
               values: new object[,]
               {
                    { 43,  297},
                    { 43,  66},
                    { 43,  303},
                    { 135, 132},
                    { 135, 66},
                    { 135, 388},
                    { 148, 403},
                    { 148, 51},
                    { 155, 297},
                    { 155, 66},
                    { 155, 303},
                    { 170, 357},
                    { 170, 55},
                    { 192, 357},
                    { 202, 22},
                    { 202, 55},
                    { 261, 403},
                    { 261, 51},
                    { 292, 51},
                    { 292, 66},
                    { 312, 66},
                    { 312, 132},
                    { 353, 303},
                    { 353, 297},
                    { 384, 297},
                    { 384, 303},
                    { 471, 22},
                    { 488, 66},
                    { 488, 297},
                    { 492, 403},
                    { 492, 66},
                    { 8, 55},
                    { 88, 22},
                    { 48,22},
                    { 23, 303}

               });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlatformes");

            migrationBuilder.DropTable(
                name: "Games");

        
        }
    }
}
