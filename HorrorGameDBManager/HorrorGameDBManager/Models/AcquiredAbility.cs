using System;

namespace HorrorGameDBManager.Models
{
    internal class AcquiredAbility
    {
        public string PlayerId { get; }
        public byte AbilityId { get; }

        public AcquiredAbility(string playerId, byte abilityId)
        {
            if (Database.PlayerExists(playerId))
                PlayerId = playerId;
            else
                throw new ArgumentException($"Игрок {playerId} не существует.");

            if (Database.AbilityExists(abilityId))
                AbilityId = abilityId;
            else
                throw new ArgumentException($"Способность {abilityId} не существует.");
        }
    }
}
