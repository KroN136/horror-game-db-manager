using HorrorGameDBManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HorrorGameDBManager
{
    internal class Database
    {
        public static List<Ability> Abilities { get; private set; } = new List<Ability>();
        public static List<AcquiredAbility> AcquiredAbilities { get; private set; } = new List<AcquiredAbility>();
        public static List<Artifact> Artifacts { get; private set; } = new List<Artifact>();
        public static List<ArtifactRarity> ArtifactRarities { get; private set; } = new List<ArtifactRarity>();
        public static List<CollectedArtifact> CollectedArtifacts { get; private set; } = new List<CollectedArtifact>();
        public static List<Entity> Entities { get; private set; } = new List<Entity>();
        public static List<GameSession> GameSessions { get; private set; } = new List<GameSession>();
        public static List<GameType> GameTypes { get; private set; } = new List<GameType>();
        public static List<Player> Players { get; private set; } = new List<Player>();
        public static List<PlayerSession> PlayerSessions { get; private set; } = new List<PlayerSession>();
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

        public static byte GenerateArtifactRarityId() => (byte) (ArtifactRarities.Any() ?
            ArtifactRarities.Last().Id + 1 :
            1);

        public static ulong GenerateCollectedArtifactId() => CollectedArtifacts.Any() ?
            CollectedArtifacts.Last().Id + 1 :
            1;

        public static byte GenerateEntityId() => (byte) (Entities.Any() ?
            Entities.Last().Id + 1 :
            1);

        public static ulong GenerateGameSessionId() => GameSessions.Any() ?
            GameSessions.Last().Id + 1 :
            1;

        public static byte GenerateGameTypeId() => (byte) (GameTypes.Any() ?
            GameTypes.Last().Id + 1 :
            1);

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
    }
}
