using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class PlayerSession : ModelWithULongId
    {
        private static readonly List<object> existingIds = new();

        public ulong GameSessionId { get; }
        public string PlayerId { get; }
        public bool? IsFinished { get; set; }
        public bool? IsWon { get; set; }
        public float? TimeAlive { get; set; }
        public bool? PlayedAsEntity { get; set; }
        public byte? EntityId { get; set; }

        public PlayerSession(ulong gameSessionId, string playerId, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            if (Database.GameSessions.Exists(gameSessionId))
                GameSessionId = gameSessionId;
            else
                throw new ArgumentException($"Игровая сессия {gameSessionId} не существует.");

            if (Database.Players.Exists(playerId))
                PlayerId = playerId;
            else
                throw new ArgumentException($"Игрок {playerId} не существует.");

            if (Database.Players.Get(playerId).EnableDataCollection)
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

        public override PlayerSession Clone() => new(GameSessionId, PlayerId, false) { Id = Id, IsFinished = IsFinished, IsWon = IsWon, TimeAlive = TimeAlive, PlayedAsEntity = PlayedAsEntity, EntityId = EntityId };
    }
}
