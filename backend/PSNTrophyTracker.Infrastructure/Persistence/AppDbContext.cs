using Microsoft.EntityFrameworkCore;
using PSNTrophyTracker.Domain.Entities;

namespace PSNTrophyTracker.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<SyncHistory> SyncHistories { get; set; }
    public DbSet<Trophy> Trophies { get; set; }
    public DbSet<UserTrophy> UserTrophies { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Game>()
            .HasMany(g => g.Trophies)
            .WithOne(t => t.Game)
            .HasForeignKey(t => t.GameId);

        modelBuilder.Entity<Game>()
            .HasIndex(g => g.NpCommunicationId)
            .IsUnique();

        modelBuilder.Entity<UserTrophy>()
            .HasOne(u => u.Trophy)
            .WithOne()
            .HasForeignKey<UserTrophy>(u => u.TrophyId);

        modelBuilder.Entity<UserTrophy>()
            .HasIndex(u => u.TrophyId)
            .IsUnique();

        modelBuilder.Entity<Trophy>()
            .HasIndex(t => new { t.GameId, t.PsnTrophyId })
            .IsUnique();


    }
}