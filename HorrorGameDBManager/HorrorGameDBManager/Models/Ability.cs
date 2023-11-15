using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class Ability : ModelWithByteId
    {
        public string AssetName { get; set; }

        public Ability(string assetName)
        {
            AssetName = assetName;
        }
    }
}
