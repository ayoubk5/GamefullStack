using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Extension
{
    public  static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            List<Platforme> listPlatforme = new List<Platforme>
            {
                new Platforme
                {
                    Name = "Pc",
                   Slug="pc"

                },new Platforme
                {
                    Name = "PlayStation",
                   Slug= "playstation"

                },new Platforme
                {
                    Name = "Xbox",
                   Slug= "xbox"

                },new Platforme
                {
                    Name = "IOS",
                   Slug= "iOS"

                },new Platforme
                {
                    Name = "Android",
                   Slug= "android"

                },new Platforme
                {
                    Name = "Apple Macintosh",
                   Slug= "mac"

                },new Platforme
                {
                   Name = "Linux",
                   Slug= "linux"

                },new Platforme
                {
                    Name = "Nintendo",
                   Slug= "nintendo"

                },new Platforme
                {
                    Name = "Atari",
                   Slug= "atari"

                },new Platforme
                {
                    Name = "SEGA",
                   Slug= "sega"
                }
            };

            foreach(var x in listPlatforme)
            {
                    int number = 0;
                    do
                    {
                        number = new Random().Next(1, 500);
                    } while (listPlatforme.Count(w => w.Id == number) > 0);
                    x.Id = number;
            }

            List<Genre> genres = new List<Genre>
            {
                new Genre
               {
                   Name = "Action",
                   Slug = "action",
                   Image = "https://media.rawg.io/media/games/8d6/8d69eb6c32ed6acfd75f82d532144993.jpg"
               },new Genre
               {
                   Name = "Indie",
                   Slug = "indie",
                   Image = "https://media.rawg.io/media/games/b6b/b6b20bfc4b34e312dbc8aac53c95a348.jpg"
               },new Genre
               {
                   Name = "Adventure",
                   Slug = "adventure",
                   Image = "https://media.rawg.io/media/games/d69/d69810315bd7e226ea2d21f9156af629.jpg"
               },new Genre
               {
                   Name = "RPG",
                   Slug = "role-playing-games-rpg",
                   Image = "https://media.rawg.io/media/games/5a4/5a44112251d70a25291cc33757220fce.jpg"
               },new Genre
               {
                   Name = "Simulation",
                   Slug = "simulation",
                   Image = "https://media.rawg.io/media/games/78d/78dfae12fb8c5b16cd78648553071e0a.jpg"
               },new Genre
               {
                   Name = "Shooter",
                   Slug = "shooter",
                   Image = "https://media.rawg.io/media/games/fc1/fc1307a2774506b5bd65d7e8424664a7.jpg"
               },new Genre
               {
                   Name = "Platformer",
                   Slug = "platformer",
                   Image = "https://media.rawg.io/media/games/388/388935d851846f8ec747fffc7c765800.jpg"
               },new Genre
               {
                   Name = "Arcade",
                   Slug = "arcade",
                   Image = "https://media.rawg.io/media/games/27b/27b02ffaab6b250cc31bf43baca1fc34.jpg"
               },new Genre
               {
                   Name = "Puzzle",
                   Slug = "puzzle",
                   Image = "https://media.rawg.io/media/games/c2e/c2e6ad5c838d551aeff376f1f3d9d65e.jpg"
               },new Genre
               {
                   Name = "Casual",
                   Slug = "casual",
                   Image = "https://media.rawg.io/media/screenshots/b20/b20a20205954f9765e82298dbd41e48a.jpg"
               },new Genre
               {
                   Name = "Massively Multiplayer",
                   Slug = "massively-multiplayer",
                   Image = "https://media.rawg.io/media/games/d07/d0790809a13027251b6d0f4dc7538c58.jpg"
               },new Genre
               {
                   Name = "Racing",
                   Slug = "racing",
                   Image = "https://media.rawg.io/media/games/788/788b80cbc8c39167f7ed6dd89fd398dc.jpg"
               },new Genre
               {
                  
                   Name = "Sports",
                   Slug = "sports",
                   Image = "https://media.rawg.io/media/games/082/082365507ff04d456c700157072d35db.jpg"
               },new Genre
               {
                  
                   Name = "Fighting",
                   Slug = "fighting",
                   Image = "https://media.rawg.io/media/games/91b/91be1a00c767f9e3d79353e505d7f85a.jpg"
               },new Genre
               {
                
                   Name = "Board Games",
                   Slug = "board-games",
                   Image = "https://media.rawg.io/media/screenshots/d62/d628164463ac6fc7ab28b5a988191582.jpg"
               },new Genre
               {
                   
                   Name = "Educational",
                   Slug = "educational",
                   Image = "https://media.rawg.io/media/games/7ca/7ca90d463ea0c0252e7d01afe897ffa8.jpg"
               }
            };

            foreach(var x in genres)
            {
                int number = 0;
                do
                {
                    number = new Random().Next(1, 500);
                } while (genres.Count(w => w.Id == number) > 0);
                x.Id = number;
            }

            modelBuilder.Entity<Platforme>().HasData(listPlatforme);

            modelBuilder.Entity<Genre>().HasData(genres);
        }
    }
}
