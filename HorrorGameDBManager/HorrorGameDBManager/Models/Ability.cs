using HorrorGameDBManager.Models.Base;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HorrorGameDBManager.Models
{
    internal class Ability : ModelWithByteId
    {
        private static readonly List<object> existingIds = new();

        public string AssetName { get; set; }

        public Ability(string assetName, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            AssetName = assetName;
        }

        [JsonConstructor]
        public Ability(object id, string assetName)
        {
            id = byte.Parse(id.ToString()!);
            Id = id;
            existingIds.Add(Id);

            AssetName = assetName;
        }

        [JsonIgnore]
        public IEnumerable<AcquiredAbility> AcquiredAbilities => Database.AcquiredAbilities.Entries.Where(acquiredAbility => acquiredAbility.AbilityId.Equals(Id));

        public override Ability Clone() => new(AssetName, false) { Id = Id };
    }
}
