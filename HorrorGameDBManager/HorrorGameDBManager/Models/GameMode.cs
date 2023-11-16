using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class GameMode : ModelWithByteId
    {
        private static readonly List<object> existingIds = new();

        public string AssetName { get; set; }
        public byte PlayerCount { get; set; }
        public float? TimeLimit { get; set; }

        public GameMode(string assetName, byte playerCount, float? timeLimit, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            AssetName = assetName;
            PlayerCount = playerCount;
            TimeLimit = timeLimit;
        }

        public override GameMode Clone() => new(AssetName, PlayerCount, TimeLimit, false) { Id = Id };
    }
}
