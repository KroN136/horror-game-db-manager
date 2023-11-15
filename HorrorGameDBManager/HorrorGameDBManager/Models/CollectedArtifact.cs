﻿using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class CollectedArtifact : ModelWithULongId
    {
        public string PlayerId { get; }
        public byte ArtifactId { get; }
        public ulong GameSessionId { get; }

        public CollectedArtifact(string playerId, byte artifactId, ulong gameSessionId)
        {
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
