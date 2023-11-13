namespace HorrorGameDBManager.Models
{
    internal class Entity
    {
        public byte Id { get; }
        public string AssetName { get; set; }
        public float Health { get; set; }
        public float MovementSpeed { get; set; }
        public uint RequiredXp { get; set; }

        public Entity(string assetName, float health, float movementSpeed, uint requiredXp)
        {
            Id = Database.GenerateEntityId();
            AssetName = assetName;
            Health = health;
            MovementSpeed = movementSpeed;
            RequiredXp = requiredXp;
        }
    }
}
