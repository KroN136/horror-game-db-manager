using System;

namespace HorrorGameDBManager.Models
{
    internal class CollectedArtifact
    {
        public ulong Id { get; }
        public string PlayerId { get; }
        public byte ArtifactId { get; }
        public ulong GameSessionId { get; }

        public CollectedArtifact(string playerId, byte artifactId, ulong gameSessionId)
        {
            Id = Database.GenerateCollectedArtifactId();

            if (Database.PlayerExists(playerId))
                PlayerId = playerId;
            else
                throw new ArgumentException($"Игрок {playerId} не существует.");

            if (Database.ArtifactExists(artifactId))
                ArtifactId = artifactId;
            else
                throw new ArgumentException($"Артефакт {artifactId} не существует.");

            if (Database.GameSessionExists(gameSessionId))
                GameSessionId = gameSessionId;
            else
                throw new ArgumentException($"Игровая сессия {gameSessionId} не существует.");

            PlayerId = playerId;
            ArtifactId = artifactId;
            GameSessionId = gameSessionId;
        }
    }
}
