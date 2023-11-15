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

        public static bool AbilityExists(byte id) => Abilities.Exists(id);
        public static bool AcquiredAbilityExists(ulong id) => AcquiredAbilities.Exists(id);
        public static bool ArtifactExists(byte id) => Artifacts.Exists(id);
        public static bool CollectedArtifactExists(ulong id) => CollectedArtifacts.Exists(id);
        public static bool EntityExists(byte id) => Entities.Exists(id);
        public static bool GameModeExists(byte id) => GameModes.Exists(id);
        public static bool GameSessionExists(ulong id) => GameSessions.Exists(id);
        public static bool PlayerExists(string id) => Players.Exists(id);
        public static bool PlayerSessionExists(ulong id) => PlayerSessions.Exists(id);
        public static bool RarityLevelExists(byte id) => RarityLevels.Exists(id);
        public static bool ServerExists(ushort id) => Servers.Exists(id);
    }
}
