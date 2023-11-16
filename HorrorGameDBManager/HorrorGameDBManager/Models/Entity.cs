using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class Entity : ModelWithByteId
    {
        private static readonly List<object> existingIds = new();

        public string AssetName { get; set; }
        public float Health { get; set; }
        public float MovementSpeed { get; set; }
        public uint RequiredXp { get; set; }

        public Entity(string assetName, float health, float movementSpeed, uint requiredXp, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            AssetName = assetName;
            Health = health;
            MovementSpeed = movementSpeed;
            RequiredXp = requiredXp;
        }

        public override Entity Clone() => new(AssetName, Health, MovementSpeed, RequiredXp, false) { Id = Id };
    }
}
