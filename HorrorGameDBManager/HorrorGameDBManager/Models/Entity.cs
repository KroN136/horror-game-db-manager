using HorrorGameDBManager.Models.Base;
using System.Text.Json.Serialization;

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

        [JsonConstructor]
        public Entity(object id, string assetName, float health, float movementSpeed, byte requiredExperienceLevelId)
        {
            id = byte.Parse(id.ToString()!);
            Id = id;
            existingIds.Add(Id);

            AssetName = assetName;
            Health = health;
            MovementSpeed = movementSpeed;
            RequiredExperienceLevelId = requiredExperienceLevelId;
        }

        [JsonIgnore]
        public ExperienceLevel RequiredExperienceLevel => Database.ExperienceLevels.Get(RequiredExperienceLevelId);
        [JsonIgnore]
        public IEnumerable<PlayerSession> PlayerSessions => Database.PlayerSessions.Entries.Where(playerSession => playerSession.UsedEntityId.HasValue && playerSession.UsedEntityId.Value.Equals(Id));

        public override Entity Clone() => new(AssetName, Health, MovementSpeed, RequiredExperienceLevelId, false) { Id = Id };
    }
}
