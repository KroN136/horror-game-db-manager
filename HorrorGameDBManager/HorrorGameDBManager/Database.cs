using HorrorGameDBManager.Models;

namespace HorrorGameDBManager
{
    internal static class Database
    {
        public static Table<Ability> Abilities { get; } = new Table<Ability>("abilities");
        public static Table<AcquiredAbility> AcquiredAbilities { get; } = new Table<AcquiredAbility>("acquired_abilities");
        public static Table<Artifact> Artifacts { get; } = new Table<Artifact>("artifacts");
        public static Table<CollectedArtifact> CollectedArtifacts { get; } = new Table<CollectedArtifact>("collected_artifacts");
        public static Table<Entity> Entities { get; } = new Table<Entity>("entities");
        public static Table<GameMode> GameModes { get; } = new Table<GameMode>("game_modes");
        public static Table<GameSession> GameSessions { get; } = new Table<GameSession>("game_sessions");
        public static Table<Player> Players { get; } = new Table<Player>("players");
        public static Table<PlayerSession> PlayerSessions { get; } = new Table<PlayerSession>("player_sessions");
        public static Table<RarityLevel> RarityLevels { get; } = new Table<RarityLevel>("rarity_levels");
        public static Table<Server> Servers { get; } = new Table<Server>("servers");
    }
}
