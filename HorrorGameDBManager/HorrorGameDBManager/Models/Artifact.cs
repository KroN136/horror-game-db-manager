using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class Artifact : ModelWithByteId
    {
        private static readonly List<object> existingIds = new();

        public string AssetName { get; set; }
        public byte RarityLevelId { get; }

        public Artifact(string assetName, byte rarityLevelId)
        {
            Id = GenerateId(existingIds);
            existingIds.Add(Id);

            AssetName = assetName;

            if (Database.RarityLevels.Exists(rarityLevelId))
                RarityLevelId = rarityLevelId;
            else
                throw new ArgumentException($"Уровень редкости {rarityLevelId} не существует.");
        }
    }
}
