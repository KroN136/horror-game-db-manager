using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class RarityLevel : ModelWithByteId
    {
        private static readonly List<object> existingIds = new();

        public string AssetName { get; set; }
        public float Probability { get; set; }

        public RarityLevel(string assetName, float probability)
        {
            Id = GenerateId(existingIds);
            existingIds.Add(Id);

            AssetName = assetName;
            Probability = probability;
        }
    }
}
