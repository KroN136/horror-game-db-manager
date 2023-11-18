using HorrorGameDBManager.Models.Base;

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

        public IEnumerable<Entity> RequiringEntities => Database.Entities.GetAll().Where(entity => entity.RequiredExperienceLevelId.Equals(Id));
        public IEnumerable<Player> Players => Database.Players.GetAll().Where(player => player.ExperienceLevelId.Equals(Id));

        public override ExperienceLevel Clone() => new(Number, RequiredExperiencePoints, false) { Id = Id };
    }
}
