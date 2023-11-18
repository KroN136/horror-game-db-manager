using HorrorGameDBManager.Models.Base;
using System.Text.Json.Serialization;

namespace HorrorGameDBManager.Models
{
    internal class AcquiredAbility : ModelWithULongId
    {
        private static readonly List<object> existingIds = new();

        public string PlayerId { get; }
        public byte AbilityId { get; }

        public AcquiredAbility(string playerId, byte abilityId, bool generateId = true)
        {
            if (generateId)
            {
                Id = GenerateId(existingIds);
                existingIds.Add(Id);
            }

            if (Database.Players.Exists(playerId))
                PlayerId = playerId;
            else
                throw new ArgumentException($"Игрок {playerId} не существует.");

            if (Database.Abilities.Exists(abilityId))
                AbilityId = abilityId;
            else
                throw new ArgumentException($"Способность {abilityId} не существует.");
        }

        [JsonConstructor]
        public AcquiredAbility(object id, string playerId, byte abilityId)
        {
            id = ulong.Parse(id.ToString()!);
            Id = id;
            existingIds.Add(Id);

            PlayerId = playerId;
            AbilityId = abilityId;
        }

        [JsonIgnore]
        public Player Player => Database.Players.Get(PlayerId);
        [JsonIgnore]
        public Ability Ability => Database.Abilities.Get(AbilityId);

        public override AcquiredAbility Clone() => new(PlayerId, AbilityId, false) { Id = Id };
    }
}
