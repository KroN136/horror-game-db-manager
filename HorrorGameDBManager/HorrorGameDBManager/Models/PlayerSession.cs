using System;
using System.Linq;

namespace HorrorGameDBManager.Models
{
    internal class PlayerSession
    {
        public ulong Id { get; }
        public ulong GameSessionId { get; }
        public string PlayerId { get; }
        public bool? IsFinished { get; set; }
        public bool? IsWon { get; set; }
        public float? TimeAlive { get; set; }
        public bool? PlayedAsEntity { get; set; }
        public byte? EntityId { get; set; }

        public PlayerSession(ulong gameSessionId, string playerId)
        {
            Id = Database.GeneratePlayerSessionId();

            if (Database.GameSessionExists(gameSessionId))
                GameSessionId = gameSessionId;
            else
                throw new ArgumentException($"Игровая сессия {gameSessionId} не существует.");

            if (Database.PlayerExists(playerId))
                PlayerId = playerId;
            else
                throw new ArgumentException($"Игрок {playerId} не существует.");

            if (Database.Players.Where(player => player.Id.Equals(playerId)).First().EnableAnalytics)
            {
                IsFinished = false;
                IsWon = false;
                TimeAlive = 0;
                PlayedAsEntity = false;
            } 
            else
            {
                IsFinished = null;
                IsWon = null;
                TimeAlive = null;
                PlayedAsEntity = null;
            }

            EntityId = null;
        }
    }
}
