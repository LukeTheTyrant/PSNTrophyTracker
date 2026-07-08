using Microsoft.EntityFrameworkCore;
using PSNTrophyTracker.Domain.Entities;
using PSNTrophyTracker.Domain.Enums;

namespace PSNTrophyTracker.Infrastructure.Persistence.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        // Evita inserir dados duplicados toda vez que a aplicação iniciar.
        if (await context.Games.AnyAsync())
        {
            return;
        }

        var now = DateTime.UtcNow;

        // Primeiro criamos os troféus como objetos.
        // Eles ainda não estão no banco. São apenas objetos em memória.
        var trophy1 = new Trophy
        {
            ExternalId = Guid.NewGuid(),
            CreatedAt = now,
            PsnTrophyId = 1,
            GroupId = 0,
            Name = "Complete the Journey",
            Description = "Finish the main story.",
            Type = TrophyType.Gold,
            Rare = TrophyRare.Rare,
            TrophyEarnedRate = 18.50m,
            IsHidden = false,
            IconUrl = null
        };

        var trophy2 = new Trophy
        {
            ExternalId = Guid.NewGuid(),
            CreatedAt = now,
            PsnTrophyId = 2,
            GroupId = 0,
            Name = "Defeat the Secret Boss",
            Description = "Defeat the optional secret boss.",
            Type = TrophyType.Gold,
            Rare = TrophyRare.UltraRare,
            TrophyEarnedRate = 3.20m,
            IsHidden = false,
            IconUrl = null
        };

        var trophy3 = new Trophy
        {
            ExternalId = Guid.NewGuid(),
            CreatedAt = now,
            PsnTrophyId = 3,
            GroupId = 0,
            Name = "Find All Artifacts",
            Description = "Collect all hidden artifacts.",
            Type = TrophyType.Silver,
            Rare = TrophyRare.VeryRare,
            TrophyEarnedRate = 7.80m,
            IsHidden = false,
            IconUrl = null
        };

        // Agora criamos o Game e associamos os troféus a ele.
        // Repare que não precisamos preencher GameId manualmente aqui.
        // Ao adicionar os troféus na coleção Trophies, o EF entende a relação.
        var game = new Game
        {
            ExternalId = Guid.NewGuid(),
            CreatedAt = now,
            NpCommunicationId = "NPWR00001_00",
            NpServiceName = "trophy",
            Title = "Fake Adventure",
            Platform = Platform.PS5,
            IconUrl = null,
            Progress = 33.33m,
            BronzeCount = 0,
            SilverCount = 1,
            GoldCount = 2,
            PlatinumCount = 0,
            LastUpdatedAt = now,
            Trophies = new List<Trophy>
            {
                trophy1,
                trophy2,
                trophy3
            }
        };

        // Agora criamos o status local do usuário para cada troféu.
        // Aqui usamos a navegação Trophy em vez de preencher TrophyId manualmente.
        // O EF vai resolver o TrophyId quando salvar.
        var userTrophy1 = new UserTrophy
        {
            ExternalId = Guid.NewGuid(),
            CreatedAt = now,
            Trophy = trophy1,
            Earned = true,
            EarnedAt = now.AddDays(-10),
            Progress = null,
            ProgressRate = 100m
        };

        var userTrophy2 = new UserTrophy
        {
            ExternalId = Guid.NewGuid(),
            CreatedAt = now,
            Trophy = trophy2,
            Earned = false,
            EarnedAt = null,
            Progress = null,
            ProgressRate = 0m
        };

        var userTrophy3 = new UserTrophy
        {
            ExternalId = Guid.NewGuid(),
            CreatedAt = now,
            Trophy = trophy3,
            Earned = false,
            EarnedAt = null,
            Progress = 5,
            ProgressRate = 50m
        };

        var syncHistory = new SyncHistory
        {
            ExternalId = Guid.NewGuid(),
            CreatedAt = now,
            StartedAt = now.AddMinutes(-2),
            FinishedAt = now,
            Status = SyncStatus.Success,
            GamesProcessed = 1,
            TrophiesProcessed = 3,
            ErrorMessage = null
        };

        context.Games.Add(game);
        context.UserTrophies.AddRange(userTrophy1, userTrophy2, userTrophy3);
        context.SyncHistories.Add(syncHistory);

        await context.SaveChangesAsync();
    }
}