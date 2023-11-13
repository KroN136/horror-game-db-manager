namespace HorrorGameDBManager.Models
{
    internal class RarityLevel
    {
        public byte Id { get; }
        public string AssetName { get; set; }
        public float Probability { get; set; }
    }
}
