using HorrorGameDBManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HorrorGameDBManager
{
    internal static class Database
    {
        public static List<Ability> Abilities { get; private set; } = new List<Ability>();
        public static List<AcquiredAbility> AcquiredAbilities { get; private set; } = new List<AcquiredAbility>();
        public static List<Artifact> Artifacts { get; private set; } = new List<Artifact>();
        public static List<CollectedArtifact> CollectedArtifacts { get; private set; } = new List<CollectedArtifact>();
        public static List<Entity> Entities { get; private set; } = new List<Entity>();
        public static List<GameMode> GameModes { get; private set; } = new List<GameMode>();
        public static List<GameSession> GameSessions { get; private set; } = new List<GameSession>();
        public static List<Player> Players { get; private set; } = new List<Player>();
        public static List<PlayerSession> PlayerSessions { get; private set; } = new List<PlayerSession>();
        public static List<RarityLevel> RarityLevels { get; private set; } = new List<RarityLevel>();
        public static List<Server> Servers { get; private set; } = new List<Server>();

        #region Id Management

        private const string possibleCharacters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789_-";

        private static string GenerateStringId(int length)
        {
            Random random = new Random();

            return new string(Enumerable.Repeat(possibleCharacters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static byte GenerateAbilityId() => (byte) (Abilities.Any() ?
            Abilities.Last().Id + 1 :
            1);

        public static ulong GenerateAcquiredAbilityId() => AcquiredAbilities.Any() ?
            AcquiredAbilities.Last().Id + 1 :
            1;

        public static byte GenerateArtifactId() => (byte) (Artifacts.Any() ?
            Artifacts.Last().Id + 1 :
            1);

        public static byte GenerateRarityLevelId() => (byte) (RarityLevels.Any() ?
            RarityLevels.Last().Id + 1 :
            1);

        public static ulong GenerateCollectedArtifactId() => CollectedArtifacts.Any() ?
            CollectedArtifacts.Last().Id + 1 :
            1;

        public static byte GenerateEntityId() => (byte) (Entities.Any() ?
            Entities.Last().Id + 1 :
            1);

        public static byte GenerateGameModeId() => (byte) (GameModes.Any() ?
            GameModes.Last().Id + 1 :
            1);

        public static ulong GenerateGameSessionId() => GameSessions.Any() ?
            GameSessions.Last().Id + 1 :
            1;

        public static string GeneratePlayerId()
        {
            string id;

            if (Players.Any())
            {
                id = Players.First().Id;
                while (Players.Select(player => player.Id).Contains(id))
                    id = GenerateStringId(8);
            }
            else
            {
                id = GenerateStringId(8);
            }

            return id;
        }

        public static ulong GeneratePlayerSessionId() => PlayerSessions.Any() ?
            PlayerSessions.Last().Id + 1 :
            1;

        public static ushort GenerateServerId() => (ushort) (Servers.Any() ?
            Servers.Last().Id + 1 :
            1);

        #endregion

        #region Existence Checkers

        public static bool AbilityExists(byte id) => Abilities.Select(ability => ability.Id).Contains(id);
        public static bool AcquiredAbilityExists(ulong id) => AcquiredAbilities.Select(acquiredAbility => acquiredAbility.Id).Contains(id);
        public static bool ArtifactExists(byte id) => Artifacts.Select(artifact => artifact.Id).Contains(id);
        public static bool CollectedArtifactExists(ulong id) => CollectedArtifacts.Select(collectedArtifact => collectedArtifact.Id).Contains(id);
        public static bool EntityExists(byte id) => Entities.Select(entity => entity.Id).Contains(id);
        public static bool GameModeExists(byte id) => GameModes.Select(gameMode => gameMode.Id).Contains(id);
        public static bool GameSessionExists(ulong id) => GameSessions.Select(gameSession => gameSession.Id).Contains(id);
        public static bool PlayerExists(string id) => Players.Select(player => player.Id).Contains(id);
        public static bool PlayerSessionExists(ulong id) => PlayerSessions.Select(playerSession => playerSession.Id).Contains(id);
        public static bool RarityLevelExists(byte id) => RarityLevels.Select(rarityLevel => rarityLevel.Id).Contains(id);
        public static bool ServerExists(ushort id) => Servers.Select(server => server.Id).Contains(id);

        #endregion
    }
}
