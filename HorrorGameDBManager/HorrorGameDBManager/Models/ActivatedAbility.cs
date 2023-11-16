namespace HorrorGameDBManager.Models
{
    internal class ActivatedAbility : Ability
    {
        public float Duration { get; set; }
        public float Cooldown { get; set; }

        public ActivatedAbility(string assetName, float duration, float cooldown, bool generateId = true) : base(assetName, generateId)
        {
            Duration = duration;
            Cooldown = cooldown;
        }

        public override ActivatedAbility Clone() => new(AssetName, Duration, Cooldown, false) { Id = Id };
    }
}
