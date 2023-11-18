using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class PlayerSession : ModelWithULongId
    {
        private static readonly List<object> existingIds = new();

        public ulong? GameSessionId { get; set; }
        public string PlayerId { get; }
        public bool? IsFinished { get; set; }
        public bool? IsWon { get; set; }
        public float? TimeAlive { get; set; }
        public bool? PlayedAsEntity { get; set; }
        public byte? UsedEntityId { get; set; }

        public PlayerSession(ulong? gameSessionId, string playerId, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            if (gameSessionId.HasValue == false || Database.GameSessions.Exists(gameSessionId))
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

            UsedEntityId = null;
        }

        public GameSession? GameSession => GameSessionId.HasValue ? Database.GameSessions.Get(GameSessionId) : null;
        public Player Player => Database.Players.Get(PlayerId);
        public Entity? UsedEntity => UsedEntityId.HasValue ? Database.Entities.Get(UsedEntityId) : null;
        public IEnumerable<CollectedArtifact> CollectedArtifacts => Database.CollectedArtifacts.GetAll().Where(collectedArtifact => collectedArtifact.PlayerSessionId.Equals(Id));

        public override PlayerSession Clone() => new(GameSessionId, PlayerId, false) { Id = Id, IsFinished = IsFinished, IsWon = IsWon, TimeAlive = TimeAlive, PlayedAsEntity = PlayedAsEntity, UsedEntityId = UsedEntityId };
    }
}
