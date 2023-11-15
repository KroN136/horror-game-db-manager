using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class GameSession : ModelWithULongId
    {
        private static readonly List<object> existingIds = new();

        public ushort ServerId { get; }
        public byte GameModeId { get; }
        public DateTime StartDateTime { get; }
        public DateTime? EndDateTime { get; set; }

        public GameSession(ushort serverId, byte gameModeId)
        {
            Id = GenerateId(existingIds);
            existingIds.Add(Id);

            if (Database.Servers.Exists(serverId))
                ServerId = serverId;
            else
                throw new ArgumentException($"Сервер {serverId} не существует.");

            if (Database.GameModes.Exists(gameModeId))
                GameModeId = gameModeId;
            else
                throw new ArgumentException($"Режим игры {gameModeId} не существует.");

            StartDateTime = DateTime.UtcNow;
            EndDateTime = null;
        }
    }
}
