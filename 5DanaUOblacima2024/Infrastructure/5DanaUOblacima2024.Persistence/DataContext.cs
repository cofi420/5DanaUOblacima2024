using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5DanaUOblacima2024.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace _5DanaUOblacima2024.Persistence
{
    public class DataContext: DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Team-Player relationship
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

            // Game-Team relationships
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Team1)
                .WithMany()
                .HasForeignKey(g => g.Team1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Team2)
                .WithMany()
                .HasForeignKey(g => g.Team2Id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Winner)
                .WithMany()
                .HasForeignKey(g => g.WinnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ESportsDatabase");
        }
    }
}
