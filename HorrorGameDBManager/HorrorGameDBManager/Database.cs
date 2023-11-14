using HorrorGameDBManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HorrorGameDBManager
{
    internal static class Database
    {
        #region Tables

        private static List<Ability> abilities = new List<Ability>();
        public static IEnumerable<Ability> Abilities
        {
            get => new List<Ability>(abilities);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                abilities = value.ToList();
            }
        }

        private static List<AcquiredAbility> acquiredAbilities = new List<AcquiredAbility>();
        public static IEnumerable<AcquiredAbility> AcquiredAbilities
        {
            get => new List<AcquiredAbility>(acquiredAbilities);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                acquiredAbilities = value.ToList();
            }
        }

        private static List<Artifact> artifacts = new List<Artifact>();
        public static IEnumerable<Artifact> Artifacts
        {
            get => new List<Artifact>(artifacts);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                
                artifacts = value.ToList();
            }
        }

        private static List<CollectedArtifact> collectedArtifacts = new List<CollectedArtifact>();
        public static IEnumerable<CollectedArtifact> CollectedArtifacts
        {
            get => new List<CollectedArtifact>(collectedArtifacts);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                collectedArtifacts = value.ToList();
            }
        }

        private static List<Entity> entities = new List<Entity>();
        public static IEnumerable<Entity> Entities
        {
            get => new List<Entity>(entities);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                entities = value.ToList();
            }
        }

        private static List<GameMode> gameModes = new List<GameMode>();
        public static IEnumerable<GameMode> GameModes
        {
            get => new List<GameMode>(gameModes);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                gameModes = value.ToList();
            }
        }

        private static List<GameSession> gameSessions = new List<GameSession>();
        public static IEnumerable<GameSession> GameSessions
        {
            get => new List<GameSession>(gameSessions);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                gameSessions = value.ToList();
            }
        }

        private static List<Player> players = new List<Player>();
        public static IEnumerable<Player> Players
        {
            get => new List<Player>(players);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                players = value.ToList();
            }
        }

        private static List<PlayerSession> playerSessions = new List<PlayerSession>();
        public static IEnumerable<PlayerSession> PlayerSessions
        {
            get => new List<PlayerSession>(playerSessions);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                playerSessions = value.ToList();
            }
        }

        private static List<RarityLevel> rarityLevels = new List<RarityLevel>();
        public static IEnumerable<RarityLevel> RarityLevels
        {
            get => new List<RarityLevel>(rarityLevels);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                rarityLevels = value.ToList();
            }
        }

        private static List<Server> servers = new List<Server>();
        public static IEnumerable<Server> Servers
        {
            get => new List<Server>(servers);
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                servers = value.ToList();
            }
        }

        #endregion

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
