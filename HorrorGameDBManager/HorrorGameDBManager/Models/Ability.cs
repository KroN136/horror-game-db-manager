namespace HorrorGameDBManager.Models
{
    internal class Ability
    {
        public byte Id { get; }
        public string AssetName { get; set; }

        public Ability(string assetName)
        {
            Id = Database.GenerateAbilityId();
            AssetName = assetName;
        }
    }
}
