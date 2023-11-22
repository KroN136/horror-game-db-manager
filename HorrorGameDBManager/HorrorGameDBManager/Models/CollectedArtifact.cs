using HorrorGameDBManager.Models.Base;
using System.Text.Json.Serialization;

namespace HorrorGameDBManager.Models
{
    internal class CollectedArtifact : ModelWithULongId
    {
        private static readonly List<object> existingIds = new();

        public ulong PlayerSessionId { get; set; }
        public byte ArtifactId { get; }

        public CollectedArtifact(ulong playerSessionId, byte artifactId, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            if (Database.PlayerSessions.Exists(playerSessionId))
                PlayerSessionId = playerSessionId;
            else
                throw new ArgumentException($"Сессия игрока {playerSessionId} не существует.");

            if (Database.Artifacts.Exists(artifactId))
                ArtifactId = artifactId;
            else
                throw new ArgumentException($"Артефакт {artifactId} не существует.");

            PlayerSessionId = playerSessionId;
            ArtifactId = artifactId;
        }

        [JsonConstructor]
        public CollectedArtifact(object id, ulong playerSessionId, byte artifactId)
        {
            id = ulong.Parse(id.ToString()!);
            Id = id;
            existingIds.Add(Id);

            PlayerSessionId = playerSessionId;
            ArtifactId = artifactId;
        }

        [JsonIgnore]
        public PlayerSession PlayerSession => Database.PlayerSessions.Get(PlayerSessionId);
        [JsonIgnore]
        public Artifact Artifact => Database.Artifacts.Get(ArtifactId);

        public override CollectedArtifact Clone() => new(PlayerSessionId, ArtifactId, false) { Id = Id };
    }
}
