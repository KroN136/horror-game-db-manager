namespace HorrorGameDBManager.Models
{
    internal class Entity
    {
        public string AssetName { get; set; }
        public float Health { get; set; }
        public float MovementSpeed { get; set; }
        public uint RequiredXp { get; set; }

        public Entity(string assetName, float health, float movementSpeed, uint requiredXp)
        {
            AssetName = assetName;
            Health = health;
            MovementSpeed = movementSpeed;
            RequiredXp = requiredXp;
        }
    }
}
