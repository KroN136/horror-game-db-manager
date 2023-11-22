using HorrorGameDBManager.Models.Base;
using System.Text.Json.Serialization;

namespace HorrorGameDBManager.Models
{
    internal class GameMode : ModelWithByteId
    {
        private static readonly List<object> existingIds = new();

        public string AssetName { get; set; }
        public bool IsActive { get; set; }
        public byte PlayerCount { get; set; }
        public float? TimeLimit { get; set; }

        public GameMode(string assetName, bool isActive, byte playerCount, float? timeLimit, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            AssetName = assetName;
            IsActive = isActive;
            PlayerCount = playerCount;
            TimeLimit = timeLimit;
        }

        [JsonConstructor]
        public GameMode(object id, string assetName, bool isActive, byte playerCount, float? timeLimit)
        {
            id = byte.Parse(id.ToString()!);
            Id = id;
            existingIds.Add(Id);

            AssetName = assetName;
            IsActive = isActive;
            PlayerCount = playerCount;
            TimeLimit = timeLimit;
        }

        [JsonIgnore]
        public IEnumerable<GameSession> GameSessions => Database.GameSessions.Entries.Where(gameSession => gameSession.GameModeId.Equals(Id));

        public override GameMode Clone() => new(AssetName, IsActive, PlayerCount, TimeLimit, false) { Id = Id };
    }
}
