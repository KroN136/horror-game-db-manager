using HorrorGameDBManager.Models.Base;

namespace HorrorGameDBManager.Models
{
    internal class AcquiredAbility : ModelWithULongId
    {
        private static readonly List<object> existingIds = new();

        public string PlayerId { get; }
        public byte AbilityId { get; }

        public AcquiredAbility(string playerId, byte abilityId)
        {
            Id = GenerateId(existingIds);
            existingIds.Add(Id);

            if (Database.Players.Exists(playerId))
                PlayerId = playerId;
            else
                throw new ArgumentException($"Игрок {playerId} не существует.");

            if (Database.Abilities.Exists(abilityId))
                AbilityId = abilityId;
            else
                throw new ArgumentException($"Способность {abilityId} не существует.");
        }
    }
}
