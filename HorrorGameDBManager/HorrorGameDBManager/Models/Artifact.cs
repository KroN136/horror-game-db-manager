using HorrorGameDBManager.Models.Base;
using System.Text.Json.Serialization;

namespace HorrorGameDBManager.Models
{
    internal class Artifact : ModelWithByteId
    {
        private static readonly List<object> existingIds = new();

        public string AssetName { get; set; }
        public byte RarityLevelId { get; set; }

        public Artifact(string assetName, byte rarityLevelId, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            AssetName = assetName;

            if (Database.RarityLevels.Exists(rarityLevelId))
                RarityLevelId = rarityLevelId;
            else
                throw new ArgumentException($"Уровень редкости {rarityLevelId} не существует.");
        }

        [JsonConstructor]
        public Artifact(object id, string assetName, byte rarityLevelId)
        {
            id = byte.Parse(id.ToString()!);
            Id = id;
            existingIds.Add(Id);

            AssetName = assetName;
            RarityLevelId = rarityLevelId;
        }

        [JsonIgnore]
        public RarityLevel RarityLevel => Database.RarityLevels.Get(RarityLevelId);
        [JsonIgnore]
        public IEnumerable<CollectedArtifact> CollectedArtifacts => Database.CollectedArtifacts.Entries.Where(collectedArtifact => collectedArtifact.ArtifactId.Equals(Id));

        public override Artifact Clone() => new(AssetName, RarityLevelId, false) { Id = Id };
    }
}
