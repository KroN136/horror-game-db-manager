using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class GameSession : ModelWithULongId
    {
        public ushort ServerId { get; }
        public byte GameModeId { get; }
        public DateTime StartDateTime { get; }
        public DateTime? EndDateTime { get; set; }

        public GameSession(ushort serverId, byte gameModeId)
        {
            if (Database.ServerExists(serverId))
                ServerId = serverId;
            else
                throw new ArgumentException($"Сервер {serverId} не существует.");

            if (Database.GameModeExists(gameModeId))
                GameModeId = gameModeId;
            else
                throw new ArgumentException($"Режим игры {gameModeId} не существует.");

            StartDateTime = DateTime.UtcNow;
            EndDateTime = null;
        }
    }
}
