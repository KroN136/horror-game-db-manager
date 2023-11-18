using HorrorGameDBManager.Models.Base;
using System.Text.Json.Serialization;

namespace HorrorGameDBManager.Models
{
    internal class Server : ModelWithUShortId
    {
        private static readonly List<object> existingIds = new();

        public string IpAddress { get; set; }
        public ushort PlayerCapacity { get; set; }
        public bool IsActive { get; set; }
        public ushort PlayerCount { get; set; }

        public Server(string ipAddress, ushort playerCapacity, bool isActive, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            IpAddress = ipAddress;
            PlayerCapacity = playerCapacity;
            IsActive = isActive;
            PlayerCount = 0;
        }

        [JsonConstructor]
        public Server(object id, string ipAddress, ushort playerCapacity, bool isActive, ushort playerCount)
        {
            id = ushort.Parse(id.ToString()!);
            Id = id;
            existingIds.Add(Id);

            IpAddress = ipAddress;
            PlayerCapacity = playerCapacity;
            IsActive = isActive;
            PlayerCount = playerCount;
        }

        [JsonIgnore]
        public IEnumerable<GameSession> GameSessions => Database.GameSessions.Entries.Where(gameSession => gameSession.ServerId.HasValue && gameSession.ServerId.Value.Equals(Id));

        public override Server Clone() => new(IpAddress, PlayerCapacity, IsActive, false) { Id = Id, PlayerCount = PlayerCount };
    }
}
