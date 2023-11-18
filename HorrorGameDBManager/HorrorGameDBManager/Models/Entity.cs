using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class Entity : ModelWithByteId
    {
        private static readonly List<object> existingIds = new();

        public string AssetName { get; set; }
        public float Health { get; set; }
        public float MovementSpeed { get; set; }
        public byte RequiredExperienceLevelId { get; set; }

        public Entity(string assetName, float health, float movementSpeed, byte requiredExperienceLevelId, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            AssetName = assetName;
            Health = health;
            MovementSpeed = movementSpeed;

            if (Database.ExperienceLevels.Exists(requiredExperienceLevelId))
                RequiredExperienceLevelId = requiredExperienceLevelId;
            else
                throw new ArgumentException($"Уровень опыта {requiredExperienceLevelId} не существует.");
        }

        public ExperienceLevel RequiredExperienceLevel => Database.ExperienceLevels.Get(RequiredExperienceLevelId);
        public IEnumerable<PlayerSession> PlayerSessions => Database.PlayerSessions.GetAll().Where(playerSession => playerSession.UsedEntityId.HasValue && playerSession.UsedEntityId.Value.Equals(Id));

        public override Entity Clone() => new(AssetName, Health, MovementSpeed, RequiredExperienceLevelId, false) { Id = Id };
    }
}
