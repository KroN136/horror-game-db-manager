using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class CollectedArtifact : ModelWithULongId
    {
        private static readonly List<object> existingIds = new();

        public string PlayerId { get; }
        public byte ArtifactId { get; }
        public ulong PlayerSessionId { get; }

        public CollectedArtifact(string playerId, byte artifactId, ulong playerSessionId, bool generateId = true)
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

            if (Database.GameSessions.Exists(playerSessionId))
                PlayerSessionId = playerSessionId;
            else
                throw new ArgumentException($"Сессия игрока {playerSessionId} не существует.");

            PlayerId = playerId;
            ArtifactId = artifactId;
            PlayerSessionId = playerSessionId;
        }

        public Player Player => Database.Players.Get(PlayerId);
        public Artifact Artifact => Database.Artifacts.Get(ArtifactId);
        public PlayerSession PlayerSession => Database.PlayerSessions.Get(PlayerSessionId);

        public override CollectedArtifact Clone() => new(PlayerId, ArtifactId, PlayerSessionId, false) { Id = Id };
    }
}
