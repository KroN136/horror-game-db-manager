using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class GameSession : ModelWithULongId
    {
        private static readonly List<object> existingIds = new();

        public ushort? ServerId { get; set; }
        public byte? GameModeId { get; set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime? EndDateTime { get; set; }

        public GameSession(ushort? serverId, byte? gameModeId, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            if (serverId.HasValue == false || Database.Servers.Exists(serverId))
                ServerId = serverId;
            else
                throw new ArgumentException($"Сервер {serverId} не существует.");

            if (gameModeId.HasValue == false || Database.GameModes.Exists(gameModeId))
                GameModeId = gameModeId;
            else
                throw new ArgumentException($"Режим игры {gameModeId} не существует.");

            StartDateTime = DateTime.UtcNow;
            EndDateTime = null;
        }

        public override GameSession Clone() => new(ServerId, GameModeId, false) { Id = Id, StartDateTime = StartDateTime, EndDateTime = EndDateTime };
    }
}
