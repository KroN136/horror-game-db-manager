using HorrorGameDBManager.Models.Base;

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

        public IEnumerable<AcquiredAbility> AcquiredAbilities => Database.AcquiredAbilities.GetAll().Where(acquiredAbility => acquiredAbility.AbilityId.Equals(Id));

        public override Ability Clone() => new(AssetName, false) { Id = Id };
    }
}
