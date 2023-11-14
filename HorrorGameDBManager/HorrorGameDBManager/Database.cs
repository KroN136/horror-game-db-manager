using HorrorGameDBManager.Models;

namespace HorrorGameDBManager
{
    internal static class Database
    {
        public static TableWithByteId<Ability> Abilities { get; set; } = new TableWithByteId<Ability>();
        public static TableWithULongId<AcquiredAbility> AcquiredAbilities { get; set; } = new TableWithULongId<AcquiredAbility>();
        public static TableWithByteId<Artifact> Artifacts { get; set; } = new TableWithByteId<Artifact>();
        public static TableWithULongId<CollectedArtifact> CollectedArtifacts { get; set; } = new TableWithULongId<CollectedArtifact>();
        public static TableWithByteId<Entity> Entities { get; set; } = new TableWithByteId<Entity>();
        public static TableWithByteId<GameMode> GameModes { get; set; } = new TableWithByteId<GameMode>();
        public static TableWithULongId<GameSession> GameSessions { get; set; } = new TableWithULongId<GameSession>();
        public static TableWithStringId<Player> Players { get; set; } = new TableWithStringId<Player>(8);
        public static TableWithULongId<PlayerSession> PlayerSessions { get; set; } = new TableWithULongId<PlayerSession>();
        public static TableWithByteId<RarityLevel> RarityLevels { get; set; } = new TableWithByteId<RarityLevel>();
        public static TableWithUShortId<Server> Servers { get; set; } = new TableWithUShortId<Server>();

        public static bool AbilityExists(byte id) => Abilities.EntryExists(id);
        public static bool AcquiredAbilityExists(ulong id) => AcquiredAbilities.EntryExists(id);
        public static bool ArtifactExists(byte id) => Artifacts.EntryExists(id);
        public static bool CollectedArtifactExists(ulong id) => CollectedArtifacts.EntryExists(id);
        public static bool EntityExists(byte id) => Entities.EntryExists(id);
        public static bool GameModeExists(byte id) => GameModes.EntryExists(id);
        public static bool GameSessionExists(ulong id) => GameSessions.EntryExists(id);
        public static bool PlayerExists(string id) => Players.EntryExists(id);
        public static bool PlayerSessionExists(ulong id) => PlayerSessions.EntryExists(id);
        public static bool RarityLevelExists(byte id) => RarityLevels.EntryExists(id);
        public static bool ServerExists(ushort id) => Servers.EntryExists(id);
    }
}
