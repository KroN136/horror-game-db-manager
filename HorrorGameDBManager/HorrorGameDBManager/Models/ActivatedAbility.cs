namespace HorrorGameDBManager.Models
{
    internal class ActivatedAbility : Ability
    {
        public float Duration { get; set; }
        public float Cooldown { get; set; }

        public ActivatedAbility(string assetName, float duration, float cooldown) : base(assetName)
        {
            Duration = duration;
            Cooldown = cooldown;
        }
    }
}
