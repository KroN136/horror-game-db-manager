using HorrorGameDBManager.Models;

namespace HorrorGameDBManager
{
    internal static class Database
    {
        public static Table<Ability> Abilities { get; set; } = new Table<Ability>();
        public static Table<AcquiredAbility> AcquiredAbilities { get; set; } = new Table<AcquiredAbility>();
        public static Table<Artifact> Artifacts { get; set; } = new Table<Artifact>();
        public static Table<CollectedArtifact> CollectedArtifacts { get; set; } = new Table<CollectedArtifact>();
        public static Table<Entity> Entities { get; set; } = new Table<Entity>();
        public static Table<GameMode> GameModes { get; set; } = new Table<GameMode>();
        public static Table<GameSession> GameSessions { get; set; } = new Table<GameSession>();
        public static Table<Player> Players { get; set; } = new Table<Player>();
        public static Table<PlayerSession> PlayerSessions { get; set; } = new Table<PlayerSession>();
        public static Table<RarityLevel> RarityLevels { get; set; } = new Table<RarityLevel>();
        public static Table<Server> Servers { get; set; } = new Table<Server>();
    }
}
