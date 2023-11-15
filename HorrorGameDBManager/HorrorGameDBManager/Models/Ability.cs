using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class Ability : ModelWithByteId
    {
        private static readonly List<object> existingIds = new();

        public string AssetName { get; set; }

        public Ability(string assetName)
        {
            Id = GenerateId(existingIds);
            existingIds.Add(Id);

            AssetName = assetName;
        }
    }
}
