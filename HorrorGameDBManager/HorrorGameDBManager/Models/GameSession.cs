using HorrorGameDBManager.Models.Base;
using System.Text.Json.Serialization;

namespace HorrorGameDBManager.Models
{
    internal class GameSession : ModelWithULongId
    {
        private static readonly List<object> existingIds = new();

        public ushort? ServerId { get; set; }
        public byte GameModeId { get; set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime? EndDateTime { get; set; }

        public GameSession(ushort? serverId, byte gameModeId, bool generateId = true)
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

            if (Database.GameModes.Exists(gameModeId))
                GameModeId = gameModeId;
            else
                throw new ArgumentException($"Режим игры {gameModeId} не существует.");

            StartDateTime = DateTime.UtcNow;
            EndDateTime = null;
        }

        [JsonConstructor]
        public GameSession(object id, ushort? serverId, byte gameModeId, DateTime startDateTime, DateTime? endDateTime)
        {
            id = ulong.Parse(id.ToString()!);
            Id = id;
            existingIds.Add(Id);

            ServerId = serverId;
            GameModeId = gameModeId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

        [JsonIgnore]
        public Server? Server => ServerId.HasValue ? Database.Servers.Get(ServerId) : null;
        [JsonIgnore]
        public GameMode GameMode => Database.GameModes.Get(GameModeId);
        [JsonIgnore]
        public IEnumerable<PlayerSession> PlayerSessions => Database.PlayerSessions.Entries.Where(playerSession => playerSession.GameSessionId.Equals(Id));

        public override GameSession Clone() => new(ServerId, GameModeId, false) { Id = Id, StartDateTime = StartDateTime, EndDateTime = EndDateTime };
    }
}
