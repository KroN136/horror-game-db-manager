using HorrorGameDBManager.Models.Base;
using System.Text.Json.Serialization;

namespace HorrorGameDBManager.Models
{
    internal class RarityLevel : ModelWithByteId
    {
        private static readonly List<object> existingIds = new();

        public string AssetName { get; set; }
        public float Probability { get; set; }

        public RarityLevel(string assetName, float probability, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            AssetName = assetName;
            Probability = probability;
        }

        [JsonConstructor]
        public RarityLevel(object id, string assetName, float probability)
        {
            id = byte.Parse(id.ToString()!);
            Id = id;
            existingIds.Add(Id);

            AssetName = assetName;
            Probability = probability;
        }

        [JsonIgnore]
        public IEnumerable<Artifact> Artifacts => Database.Artifacts.Entries.Where(artifact => artifact.RarityLevelId.Equals(Id));

        public override RarityLevel Clone() => new(AssetName, Probability, false) { Id = Id };
    }
}
