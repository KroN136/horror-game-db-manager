using HorrorGameDBManager.Models.Base;

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

        public IEnumerable<GameSession> GameSessions => Database.GameSessions.GetAll().Where(gameSession => gameSession.ServerId.HasValue && gameSession.ServerId.Value.Equals(Id));

        public override Server Clone() => new(IpAddress, PlayerCapacity, IsActive, false) { Id = Id, PlayerCount = PlayerCount };
    }
}
