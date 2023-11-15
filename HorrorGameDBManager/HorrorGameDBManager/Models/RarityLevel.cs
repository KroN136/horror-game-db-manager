using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class RarityLevel : ModelWithByteId
    {
        public string AssetName { get; set; }
        public float Probability { get; set; }

        public RarityLevel(string assetName, float probability)
        {
            AssetName = assetName;
            Probability = probability;
        }
    }
}
