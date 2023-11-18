using HorrorGameDBManager.Models.Base;
using System.Text.Json.Serialization;

namespace HorrorGameDBManager.Models
{
    internal class CollectedArtifact : ModelWithULongId
    {
        private static readonly List<object> existingIds = new();

        public string PlayerId { get; }
        public byte ArtifactId { get; }
        public ulong? PlayerSessionId { get; set; }

        public CollectedArtifact(string playerId, byte artifactId, ulong? playerSessionId, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            if (Database.Players.Exists(playerId))
                PlayerId = playerId;
            else
                throw new ArgumentException($"Игрок {playerId} не существует.");

            if (Database.Artifacts.Exists(artifactId))
                ArtifactId = artifactId;
            else
                throw new ArgumentException($"Артефакт {artifactId} не существует.");

            if (playerSessionId.HasValue == false || Database.GameSessions.Exists(playerSessionId))
                PlayerSessionId = playerSessionId;
            else
                throw new ArgumentException($"Сессия игрока {playerSessionId} не существует.");

            PlayerId = playerId;
            ArtifactId = artifactId;
            PlayerSessionId = playerSessionId;
        }

        [JsonConstructor]
        public CollectedArtifact(object id, string playerId, byte artifactId, ulong? playerSessionId)
        {
            id = ulong.Parse(id.ToString()!);
            Id = id;
            existingIds.Add(Id);

            PlayerId = playerId;
            ArtifactId = artifactId;
            PlayerSessionId = playerSessionId;
        }

        [JsonIgnore]
        public Player Player => Database.Players.Get(PlayerId);
        [JsonIgnore]
        public Artifact Artifact => Database.Artifacts.Get(ArtifactId);
        [JsonIgnore]
        public PlayerSession? PlayerSession => PlayerSessionId.HasValue ? Database.PlayerSessions.Get(PlayerSessionId) : null;

        public override CollectedArtifact Clone() => new(PlayerId, ArtifactId, PlayerSessionId, false) { Id = Id };
    }
}
