using DataAccessLayer.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Platforme> Platformes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GamePlatformes> GamePlatformes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamePlatformes>()
                .HasKey(bc => new { bc.GameId, bc.PlatformId });
            modelBuilder.Entity<GamePlatformes>()
                .HasOne(bc => bc.Game)
                .WithMany(b => b.GamePlatformes)
                .HasForeignKey(bc => bc.GameId);
            modelBuilder.Entity<GamePlatformes>()
                .HasOne(bc => bc.Platforme)
                .WithMany(c => c.GamePlatformes)
                .HasForeignKey(bc => bc.PlatformId);

            modelBuilder.Seed();
        }
    }
}
