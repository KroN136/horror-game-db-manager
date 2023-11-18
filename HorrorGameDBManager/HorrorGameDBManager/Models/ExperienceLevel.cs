using HorrorGameDBManager.Models.Base;
using System.Text.Json.Serialization;

namespace HorrorGameDBManager.Models
{
    internal class ExperienceLevel : ModelWithByteId
    {
        private static readonly List<object> existingIds = new();

        public byte Number { get; }
        public ushort RequiredExperiencePoints { get; set; }

        public ExperienceLevel(byte number, ushort requiredExperiencePoints, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            Number = number;
            RequiredExperiencePoints = requiredExperiencePoints;
        }

        [JsonConstructor]
        public ExperienceLevel(object id, byte number, ushort requiredExperiencePoints)
        {
            id = byte.Parse(id.ToString()!);
            Id = id;
            existingIds.Add(Id);

            Number = number;
            RequiredExperiencePoints = requiredExperiencePoints;
        }

        [JsonIgnore]
        public IEnumerable<Entity> RequiringEntities => Database.Entities.Entries.Where(entity => entity.RequiredExperienceLevelId.Equals(Id));
        [JsonIgnore]
        public IEnumerable<Player> Players => Database.Players.Entries.Where(player => player.ExperienceLevelId.Equals(Id));

        public override ExperienceLevel Clone() => new(Number, RequiredExperiencePoints, false) { Id = Id };
    }
}
